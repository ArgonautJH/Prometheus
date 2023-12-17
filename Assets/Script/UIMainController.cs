using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainController : MonoBehaviour
{

    public Text modeText; // 현재 플레이어 모드 텍스트
    public GameObject fileLoadWindow; // 파일 로드 창

    [SerializeField]
    private GameObject optionWindow; // 옵션 창

    void Awake()
    {
        optionWindow.SetActive(false); // 옵션 창 비활성화
    }

    public void SetModeText(string mode)
    {
        // 예외 처리: 텍스트 컴포넌트가 없는 경우 에러 출력
        if (modeText == null)
        {
            Debug.LogError("텍스트 컴포넌트가 없음!");
            return;
        }

        // 텍스트 컴포넌트의 텍스트 변경
        modeText.text = mode;
    }

    public void OpenOptionWindow()
    {
        // 옵션 창 활성화
        optionWindow.SetActive(true);
    }
}
