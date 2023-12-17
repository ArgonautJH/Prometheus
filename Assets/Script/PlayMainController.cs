using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayMainController : MonoBehaviour
{
    private PointCloudManager pointCloudManager; // PointCloudManager 스크립트
    private UIMainController uiMainController; // UIMainController 스크립트

    void Awake()
    {
        pointCloudManager = GameObject.Find("PointCloudManager").GetComponent<PointCloudManager>(); // PointCloudManager 오브젝트의 PointCloudManager 스크립트를 가져옴
        uiMainController = GameObject.Find("UIMainController").GetComponent<UIMainController>(); // UIMainController 오브젝트의 UIMainController 스크립트를 가져옴
    }

    public void PlayStart()
    {
        Debug.Log("PlayStart");
        pointCloudManager.createFolders(); // 폴더 생성
        pointCloudManager.FileName = uiMainController.fileLoadWindow.GetComponentInChildren<TMP_InputField>().text; // 파일 이름 설정

        if(pointCloudManager.FileName == "") // 파일 이름이 비어있는 경우
        {
            Debug.Log("파일 이름이 비어있습니다.");
            return;
        }
        pointCloudManager.loadScene(); // 포인트 클라우드 생성 시작
        uiMainController.fileLoadWindow.SetActive(false); // 파일 로드 창 비활성화
    }

}
