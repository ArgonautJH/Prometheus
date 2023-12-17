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
    }

    // 클릭 시 현재 오브젝트의 부모 오브젝트를 비활성화
    public void OptionWindowCancel(){
        GameObject clickTarget = EventSystem.current.currentSelectedGameObject; // 클릭한 오브젝트를 가져옴

        clickTarget.transform.parent.gameObject.SetActive(false); // 클릭한 오브젝트의 부모 오브젝트를 비활성화

    }

    public void Home()
    {
        SceneManager.LoadScene("Menu 3D");
    }
}
