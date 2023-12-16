using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileConverter : MonoBehaviour
{

    /// <summary>
    /// xyz파일을 OFF파일로 변환하는 함수
    /// </summary>
    /// <param name="inputFilePath"> xyz파일을 받아오는 변수</param>
    /// <param name="outputFilePath"> xyz파일을 off파일로 변환 후 해당 파일을 저장하기위한 위치 변수</param>
    /// <example> ConvertXYZtoOFF("Assets/Resources/PointClouds/Untitled.xyz", "Assets/Resources/PointClouds/pointcloud.off"); </example>
    public static void ConvertXYZtoOFF(string inputFilePath, string outputFilePath)
    {
        try{
            string[] lines = File.ReadAllLines(inputFilePath);      // xyz파일의 모든 라인을 읽어옴

            using(StreamWriter outputFile = new StreamWriter(outputFilePath))
            {
                outputFile.WriteLine("OFF");                        // OFF파일의 첫 라인에 OFF를 씀
                outputFile.WriteLine(lines.Length + " 0 0");        // OFF파일의 두번째 라인에 xyz파일의 라인 수를 씀
                foreach(string line in lines)                       // xyz파일의 모든 라인을 OFF파일에 씀
                {
                    string[] coordinates = line.Split(' ');
                    outputFile.WriteLine($"{coordinates[0]} {coordinates[1]} {coordinates[2]}");
                }
            }
        }catch(IOException e){
            Debug.Log($"XYZ파일을 OFF로 변환하는 과정에서 오류 발생: {e.Message}");
        }
    }

    public static void ConvertOFFtoXYZ(string inputFilePath, string outputFilePath)
    {
        try{
            string[] lines = File.ReadAllLines(inputFilePath);    // OFF파일의 모든 라인을 읽어옴

            using(StreamWriter outputFile = new StreamWriter(outputFilePath))
            {
                int numVertices = int.Parse(lines[1].Split(' ')[0]);    // 첫번째 줄은 건너뛰고 2번쨰 라인부터 읽어옴
                
                for(int i = 2; i < numVertices + 2; i++)                // OFF파일의 라인 수만큼 반복
                {
                    string[] coordinates = lines[i].Split(' ');         // OFF파일의 라인을 공백으로 나눔
                    outputFile.WriteLine($"{coordinates[0]} {coordinates[1]} {coordinates[2]}"); // xyz파일에 씀
                }
            }
        }
        catch(IOException e){
            Debug.Log($"OFF파일을 XYZ로 변환하는 과정에서 오류 발생: {e.Message}");
        }
    }
}
