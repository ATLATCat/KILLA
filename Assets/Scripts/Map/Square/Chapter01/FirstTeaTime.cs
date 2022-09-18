using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems; 

public class FirstTeaTime : MonoBehaviour
{
    [SerializeField]
    private Speaker[] speakers; // ��ȭ�� �����ϴ� ĳ������ UI 
    [SerializeField]
    private DialogData[] dialogs; // ���� �б��� ��� ��� �迭
    [SerializeField]
    private bool isAutoStart = true; // �ڵ� ���� ����
    private bool isFirst = true; // ���� 1ȸ�� ȣ���ϱ� ���� ����
    private int currentDialogIndex = -1; // ���� ��� ����
    private int currentSpeakerIndex = 0; // ���� ���� �ϴ� ȭ���� speakers �迭 ���� 
    private float typingSpeed = 0.1f; // �ؽ�Ʈ Ÿ���� ȿ���� ��� �ӵ�
    private bool isTypingEffect = false; // �ؽ�Ʈ Ÿ���� ȿ���� ���������

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        // ��� ��ȭ ���� ���� ������Ʈ ��Ȱ��ȭ 
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
        }
        // smyInputField = speaker.textDialog.GetComponent<TextMeshProUGUI>();
    }

    public bool UpdateDialog()
    {
        // ��� �бⰡ ���۵� �� 1ȸ�� ����
        if (isFirst == true)
        {
            // �ʱ�ȭ, ĳ���� �̹��� Ȱ��ȭ, ��� ���� UI ��� ��Ȱ��ȭ
            Setup();

            // �ڵ� ������� �����Ǿ� ������ ù��° ��� ���
            if (isAutoStart) SetNextDialog();

            isFirst = false;

        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverUIObject(Input.mousePosition))
            {
                // �ؽ�Ʈ Ÿ���� ȿ���� ������� �� �ٽ� ������ Ÿ���� ȿ�� ����
                if (isTypingEffect)
                {
                    isTypingEffect = false;

                    // Ÿ���� ȿ���� �����ϰ�, ���� ��� ��ü�� ���
                    StopCoroutine("OnTypingText");
                    speakers[currentSpeakerIndex].textDialog.text = dialogs[currentDialogIndex].dialog;

                    // ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
                    speakers[currentSpeakerIndex].objectArrow.SetActive(true);

                    return false;
                }

                // ��簡 �������� ��� ���� ��� ����
                if (dialogs.Length > currentDialogIndex + 1)
                {
                    SetNextDialog();
                }

                // ��簡 �� �̻� ���� ��� ��� ������Ʈ�� ��Ȱ��ȭ�ϰ� true ��ȯ
                else
                {
                    for (int i = 0; i < speakers.Length; ++i)
                    {
                        SetActiveObjects(speakers[i], false);
                    }


                    return true;
                }
            }

        }

        return false;

    }
    public bool IsPointerOverUIObject(Vector2 touchPos)
    {
        PointerEventData eventDataCurrentPosition
            = new PointerEventData(EventSystem.current);

        eventDataCurrentPosition.position = touchPos;

        List<RaycastResult> results = new List<RaycastResult>();


        EventSystem.current
        .RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }


    private void SetNextDialog()
    {
        // ���� ȭ���� ��ȭ ���� ������Ʈ ��Ȱ��ȭ
        SetActiveObjects(speakers[currentSpeakerIndex], false);

        // ���� ��� ����
        currentDialogIndex++;

        // ���� ȭ�� ���� ����
        currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;

        // ���� ȭ���� ��ȭ ���� ������Ʈ Ȱ��ȭ
        SetActiveObjects(speakers[currentSpeakerIndex], true);

        // ���� ȭ���� ��� �ؽ�Ʈ ����
        speakers[currentSpeakerIndex].textDialog.text = dialogs[currentDialogIndex].dialog;
        
        StartCoroutine("OnTypingText");
    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.textDialog.gameObject.SetActive(visible);
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.charaName.gameObject.SetActive(visible);

        // ȭ��ǥ�� ��簡 ����Ǿ��� ���� Ȱ��ȭ�ϹǷ� �׻� false
        speaker.objectArrow.SetActive(false);
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;

        isTypingEffect = true;

        // �ؽ�Ʈ�� �ѱ��ھ� Ÿ����ġ�� ���
        while (index < dialogs[currentDialogIndex].dialog.Length)
        {
            speakers[currentSpeakerIndex].textDialog.text = dialogs[currentDialogIndex].dialog.Substring(0, index);
            index++;

            yield return new WaitForSeconds(typingSpeed);
        }

        isTypingEffect = false;

        // ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
        speakers[currentSpeakerIndex].objectArrow.SetActive(true);

    }

    // �ý��� ����ȭ 
    [System.Serializable]
    public struct Speaker
    {
        public Image imageDialog; // ��ȭâ Image UI
        public TextMeshProUGUI charaName; // ���� ���ϰ� �ִ� ĳ���� �̸�
        public TextMeshProUGUI textDialog; // ���� ��� ��� Text UI
        public GameObject objectArrow; // ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� ������Ʈ
    }

    [System.Serializable]
    public struct DialogData
    {
        public int speakerIndex; // �̸��� ��縦 ����� ���� DialogueSystem�� Speaker �迭 ����
        [TextArea(3,5)]
        public string dialog; // ���
    }
}
