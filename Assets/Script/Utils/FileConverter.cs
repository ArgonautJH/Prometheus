using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileConverter : MonoBehaviour
{
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
            Debug.Log(e.Message);
        }
    }
}
