using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainController : MonoBehaviour
{

    public Text modeText; // 현재 플레이어 모드 텍스트
    public GameObject optionWindow; // 옵션 창
    public GameObject fileLoadWindow; // 파일 로드 창
    public GameObject fileExportWindow; // 파일 내보내기 창

    public GameObject activeWindow; // 현재 활성화된 창

    public GameObject slider; // 슬라이더

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

    public void SetSliderValue(float value)
    {
        // 슬라이더의 값을 value로 설정
        slider.GetComponent<Slider>().value = value;
    }
}
