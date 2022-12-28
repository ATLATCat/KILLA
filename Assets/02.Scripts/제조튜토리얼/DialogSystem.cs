using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    [SerializeField]
    private Speaker speaker; // ��ȭ��
    [SerializeField]
    private DialogData[] dialogs; // ���� �б� ��� ��� 
    [SerializeField]
    private bool isAutoStart = true; // �ڵ� ����
    private bool isFirst = true; // ���� 1ȸ�� ���
    private int currentDialogIndex = -1; // ���� ��� ����
    private float typingSpeed = 0.1f; // Ÿ���� ȿ�� �ӵ�
    private bool isTypingEffect = false; // Ÿ���� ȿ�� ��� ����

    private void Setup()
    {
        //SetActiveObjects(speaker, false);
    }

    public bool UpdateDialog()
    {
        // ��� �бⰡ ���۵� �� 1ȸ�� ����
        if (isFirst == true)
        {
            // ĳ���� �̹��� ����, ��� ���� UI ��� ��Ȱ��ȭ
            Setup();

            // �ڵ� ��� -> ù��° ��� ���
            if (isAutoStart) SetNextDialog();

            isFirst = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(isTypingEffect == true)
            {
                isTypingEffect = false;

                // Ÿ���� ȿ�� ����, ��� ��ü ���
                StopCoroutine("OnTypingText");
                speaker.textDialog.text = dialogs[currentDialogIndex].dialog;

                // Ŀ�� Ȱ��ȭ
                speaker.objectArrow.SetActive(true);

                return false;
            }

            // ��簡 �������� ��� ���� ��� ����
            if (dialogs.Length > currentDialogIndex + 1) SetNextDialog();
            else return true;
        }

        return false;
    }
    
    private void SetNextDialog()
    {
        // ���� ��� ����
        currentDialogIndex++;
        //speaker.textDialog.text = dialogs[currentDialogIndex].dialog;
        StartCoroutine("OnTypingText");
    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.imageTextBox.gameObject.SetActive(visible);
        speaker.textDialog.gameObject.SetActive(visible);

        // ȭ��ǥ�� ��� ���� �ø� Ȱ��ȭ�ϰ� ��ҿ� false
        speaker.objectArrow.SetActive(false);
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;
        isTypingEffect = true;

        // �ؽ�Ʈ Ÿ���� ȿ�� 
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
        public Image imageTextBox; // ��ȭâ Image UI
        public TextMeshProUGUI textDialog; // ��� ��� Text UI
        public GameObject objectArrow; // ��� �Ϸ� Ŀ��
    }

    [System.Serializable]
    public struct DialogData
    {
        [TextArea(3,5)]
        public string dialog; // ��� 
    }
}
