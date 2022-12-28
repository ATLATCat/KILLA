using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    [SerializeField]
    private Speaker speaker; // 발화자
    [SerializeField]
    private DialogData[] dialogs; // 현재 분기 대사 목록 
    [SerializeField]
    private bool isAutoStart = true; // 자동 시작
    private bool isFirst = true; // 최초 1회만 재생
    private int currentDialogIndex = -1; // 현재 대사 순번
    private float typingSpeed = 0.1f; // 타이핑 효과 속도
    private bool isTypingEffect = false; // 타이핑 효과 재생 상태

    private void Setup()
    {
        //SetActiveObjects(speaker, false);
    }

    public bool UpdateDialog()
    {
        // 대사 분기가 시작될 때 1회만 노출
        if (isFirst == true)
        {
            // 캐릭터 이미지 제외, 대사 관련 UI 모두 비활성화
            Setup();

            // 자동 재생 -> 첫번째 대사 재생
            if (isAutoStart) SetNextDialog();

            isFirst = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(isTypingEffect == true)
            {
                isTypingEffect = false;

                // 타이핑 효과 중지, 대사 전체 출력
                StopCoroutine("OnTypingText");
                speaker.textDialog.text = dialogs[currentDialogIndex].dialog;

                // 커서 활성화
                speaker.objectArrow.SetActive(true);

                return false;
            }

            // 대사가 남아있을 경우 다음 대사 진행
            if (dialogs.Length > currentDialogIndex + 1) SetNextDialog();
            else return true;
        }

        return false;
    }
    
    private void SetNextDialog()
    {
        // 다음 대사 진행
        currentDialogIndex++;
        //speaker.textDialog.text = dialogs[currentDialogIndex].dialog;
        StartCoroutine("OnTypingText");
    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.imageTextBox.gameObject.SetActive(visible);
        speaker.textDialog.gameObject.SetActive(visible);

        // 화살표는 대사 종료 시만 활성화하고 평소엔 false
        speaker.objectArrow.SetActive(false);
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;
        isTypingEffect = true;

        // 텍스트 타이핑 효과 
        while(index < dialogs[currentDialogIndex].dialog.Length)
        {
            index++;
            speaker.textDialog.text = dialogs[currentDialogIndex].dialog.Substring(0, index);


            yield return new WaitForSeconds(typingSpeed);
        }

        isTypingEffect = false;
        speaker.objectArrow.SetActive(true);
    }


    [System.Serializable]
   public struct Speaker
    {
        public Image imageTextBox; // 대화창 Image UI
        public TextMeshProUGUI textDialog; // 대사 출력 Text UI
        public GameObject objectArrow; // 대사 완료 커서
    }

    [System.Serializable]
    public struct DialogData
    {
        [TextArea(3,5)]
        public string dialog; // 대사 
    }
}
