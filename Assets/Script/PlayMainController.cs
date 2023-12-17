using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayMainController : MonoBehaviour
{
    private PointCloudManager pointCloudManager; // PointCloudManager 스크립트
    private UIMainController uiMainController; // UIMainController 스크립트
    private PlayerController playerController; // PlayerController 스크립트

    private string loadFileName; // 로드 중인 파일 이름 [path+filename]

    private bool isPointCloudUpdated = false; // 포인트 클라우드 업데이트 여부를 나타내는 플래그

    void Awake()
    {
        pointCloudManager = GameObject.Find("PointCloudManager").GetComponent<PointCloudManager>(); // PointCloudManager 오브젝트의 PointCloudManager 스크립트를 가져옴
        uiMainController = GameObject.Find("UIMainController").GetComponent<UIMainController>(); // UIMainController 오브젝트의 UIMainController 스크립트를 가져옴
        playerController = GameObject.Find("Player").GetComponent<PlayerController>(); // Player 오브젝트의 PlayerController 스크립트를 가져옴

        uiMainController.fileLoadWindow.SetActive(true); // 파일 로드 창 비활성화
        uiMainController.fileExportWindow.SetActive(false); // 파일 내보내기 창 비활성화
        uiMainController.optionWindow.SetActive(false); // 옵션 창 비활성화

        uiMainController.activeWindow = uiMainController.fileLoadWindow; // 현재 활성화된 창 설정
    }

    void Update()
    {
        if (playerController.CurrentMode == PlayerController.PlayerMode.Cam)
        {
            // 포인트 클라우드가 업데이트되지 않았을 때만 처리
            if (!isPointCloudUpdated)
            {
                int count = pointCloudManager.PointTarget.transform.childCount; // 포인트 클라우드의 자식 오브젝트 개수

                uiMainController.slider.GetComponent<Slider>().maxValue = count; // 슬라이더의 최대값 설정

                uiMainController.slider.GetComponent<Slider>().onValueChanged.AddListener(OnSliderValueChanged); // 슬라이더 값 변경 이벤트 추가

                isPointCloudUpdated = true; // 업데이트가 실행되었음을 표시
            }
        }
        else
        {
            // 플레이어 모드가 Cam이 아닌 경우 포인트 클라우드 업데이트 플래그 초기화
            isPointCloudUpdated = false;
        }
    }

     // 슬라이더 값이 변경될 때 호출되는 이벤트 핸들러
    void OnSliderValueChanged(float value)
    {
        // 슬라이더 값을 반올림하여 정수로 변환
        int roundedValue = Mathf.RoundToInt(value);

        // 자식의 수 가져오기
        int childCount = pointCloudManager.PointTarget.transform.childCount;

        // 슬라이더 값이 자식의 수를 초과하지 않도록 보정
        roundedValue = Mathf.Clamp(roundedValue, 0, childCount);

        // 슬라이더 값에 따라 자식의 활성화 상태 변경
        SetChildrenActive(roundedValue);
    }

    // 슬라이더 값에 따라 자식의 활성화 상태를 변경하는 메서드
    void SetChildrenActive(int count)
    {
        // 모든 자식의 활성화 상태 초기화
        for (int i = 0; i < pointCloudManager.PointTarget.transform.childCount; i++)
        {
            pointCloudManager.PointTarget.transform.GetChild(i).gameObject.SetActive(false);
        }

        // count만큼의 자식을 활성화
        for (int i = 0; i < count; i++)
        {
            pointCloudManager.PointTarget.transform.GetChild(i).gameObject.SetActive(true);
        }
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

        loadFileName = uiMainController.fileLoadWindow.GetComponentInChildren<TMP_InputField>().text; // 로드 중인 파일 이름 설정
        // loadFileName = pointCloudManager.FileName; // 로드 중인 파일 이름 설정
        
    }

    public void FileExport()
    {
        Debug.Log("FileExport");
        
        string file = uiMainController.fileExportWindow.GetComponentInChildren<TMP_InputField>().text; // 파일 이름 설정
        string extension = uiMainController.fileExportWindow.GetComponentInChildren<TMP_Dropdown>().captionText.text; // 확장자 설정
        
        if(file == "") // 파일 이름이 비어있는 경우
        {
            Debug.Log("파일 이름이 비어있습니다.");
            return;
        }

        if(loadFileName == "") // 로드 중인 파일 이름이 비어있는 경우
        {
            Debug.Log("로드 중인 파일이 없습니다.");
            return;
        }

        switch(extension){
            case "xyz":
                FileConverter.ConvertOFFtoXYZ(loadFileName, file+".xyz");
                break;
            case "off":
                FileConverter.ConvertXYZtoOFF(loadFileName, file+".off");
                break;
        }

        uiMainController.fileExportWindow.SetActive(false); // 파일 내보내기 창 비활성화
    }

}
