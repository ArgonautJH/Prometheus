using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class UIButtonEvent : MonoBehaviour
{

    private UIMainController uiMainController; // UIMainController 스크립트

    void Awake()
    {
        uiMainController = GameObject.Find("UIMainController").GetComponent<UIMainController>(); // UIMainController 오브젝트의 UIMainController 스크립트를 가져옴
    }

    // 클릭한 오브젝트의 자식 오브젝트 중 Text 컴포넌트를 가진 오브젝트의 text를 가져옴
    public void PrintText()
    {
        GameObject clickTarget = EventSystem.current.currentSelectedGameObject; // 클릭한 오브젝트를 가져옴
        
        Transform[] children = clickTarget.GetComponentsInChildren<Transform>(); // 클릭한 오브젝트의 자식 오브젝트들을 가져옴

        foreach(Transform child in children)
        {
            if(child.name == "Label")
            {
                Debug.Log(child.GetComponent<Text>().text); // 클릭한 오브젝트의 자식 오브젝트 중 Text 컴포넌트를 가진 오브젝트의 text를 가져옴
            }
        }

    }

    // 클릭시 형제 노드 중 Window 오브젝트를 찾아서 활성화
    public void OpenWindow()
    {
        uiMainController.OpenOptionWindow(); // UIMainController 스크립트의 OpenWindow 함수 호출

        uiMainController.activeWindow = uiMainController.optionWindow; // 현재 활성화된 창 설정
    }

    // 클릭 시 현재 오브젝트의 부모 오브젝트를 비활성화
    public void WindowCancel(){
        GameObject clickTarget = EventSystem.current.currentSelectedGameObject; // 클릭한 오브젝트를 가져옴

        clickTarget.transform.parent.gameObject.SetActive(false); // 클릭한 오브젝트의 부모 오브젝트를 비활성화

        uiMainController.activeWindow = null; // 현재 활성화된 창 초기화

    }

    // 메인 홈으로 이동
    public void Home()
    {
        SceneManager.LoadScene("Menu 3D");
    }

    // 파일 주소를 받아서 포인트 클라우드를 생성 시작
    public void PlayStart()
    {
        //PloyMainController에 신호를 전달
        GameObject.Find("PlayMainController").GetComponent<PlayMainController>().PlayStart();
    }

    // importFileWindow 창을 활성화
    public void OpenImportFileWindow()
    {
        uiMainController.optionWindow.SetActive(false); // 옵션 창 비활성화
        uiMainController.fileLoadWindow.SetActive(true); // 파일 로드 창 활성화

        uiMainController.activeWindow = uiMainController.fileLoadWindow; // 현재 활성화된 창 설정
    }

    public void OpenExportFileWindow()
    {
        uiMainController.optionWindow.SetActive(false); // 옵션 창 비활성화
        uiMainController.fileExportWindow.SetActive(true); // 파일 내보내기 창 활성화.

        uiMainController.activeWindow = uiMainController.fileExportWindow; // 현재 활성화된 창 설정
    }
}
