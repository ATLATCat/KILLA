using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelaQuestion : MonoBehaviour
{
    [SerializeField]
    private DialogueSystem dialogueSystemH1;
    [SerializeField]
    private DialogueSystem dialogueSystemH2;
    [SerializeField]
    private DialogueSystem dialogueSystemH3;

    //BuriedFade theFade;

    public GameObject Hela;
    public GameObject Check1;
    public GameObject Check2;

    public GameObject HBackBTN;

    public GameObject TopicBox;
    public GameObject TopicCheck;
    
    private Text TopicText;
    public GameObject FadeImage;
    public GameObject HelaPaper;
    public GameObject HelaTemp;

    public GameObject Scream1;
    public GameObject Scream2;

    public GameObject Mark1;
    public GameObject Mark2;

    public static bool isQH1 = false;
    public static bool isQH2 = false;

    CamChange theCam;

    //���̵�
    /*
    public float animTime = 2f;         // Fade �ִϸ��̼� ��� �ð� (����:��).  
    public Image fadeImage;            // UGUI�� Image������Ʈ ���� ����.  

    private float start = 1f;           // Mathf.Lerp �޼ҵ��� ù��° ��.  
    private float end = 0f;             // Mathf.Lerp �޼ҵ��� �ι�° ��.  
    private float time = 0f;            // Mathf.Lerp �޼ҵ��� �ð� ��.  


    public bool stopIn = false; //false�϶� ����Ǵ°ǵ�, �ʱⰪ�� false�� �� ������ ���� �����Ҷ� ���̵������� ������...�װ� ������ true�� �ϸ��.
    public bool stopOut = true;
    */

    [Header("���� ȭ��(����X) ���̵���")]
    public Image NT_background;
    Color alpha;

    // ���̵��� �ð� ����
    float time = 0f;
    float F_time = 1.5f;

    void Start()
    {
        theCam = FindObjectOfType<CamChange>();
        TopicText = GameObject.Find("HelaTopic").GetComponent<Text>();
        TopicText.text = "";
        //theFade = FindObjectOfType<BuriedFade>();

    }

    void Awake()
    {
        // Image ������Ʈ�� �˻��ؼ� ���� ���� �� ����.  
        //fadeImage = GetComponent<Image>();
    }

    public void Hela_Q1()
    {
        Debug.Log("ù��° ����");

        TopicText.text = "��� ���Ͽ� �����. ";
        TopicBox.SetActive(true);
        TopicCheck.SetActive(true);

        HBackBTN.SetActive(false);

        if (!isQH1)
        {
            StartCoroutine(HQ1());
        }

        if (isQH1)
        {
            HBackBTN.SetActive(true);
        }
        
    }

    private IEnumerator HQ1()
    {
        yield return new WaitUntil(() => dialogueSystemH1.UpdateDialogue());
        Hela.SetActive(true);
        Check1.SetActive(true);
        TopicBox.SetActive(false);
        TopicCheck.SetActive(false);
        TopicText.text = "";

        Mark1.SetActive(false);

        HBackBTN.SetActive(true);
        isQH1 = true;

        if (isQH1 && isQH2)
        {
            HelaController.isHelaNew = false;
        }
    }

    public void Hela_Q2()
    {
        Debug.Log("�� ��° ����");
        TopicText.text = "���̿� ���� �� �����.";
        TopicBox.SetActive(true);
        TopicCheck.SetActive(true);

        HBackBTN.SetActive(false);
        if (!isQH2)
        { 
            StartCoroutine(HQ2()); 
        }
        //���� �ڷ�ƾ

        //���� ��ȭ �ڷ�ƾ
        //

        if (isQH2)
        {
            HBackBTN.SetActive(true);
        }
        Debug.Log("��� Q2");
    }

    private IEnumerator HQ2()
    {
        yield return new WaitUntil(() => dialogueSystemH2.UpdateDialogue());
        Hela.SetActive(true);
        Check2.SetActive(true);
        TopicBox.SetActive(false);
        TopicCheck.SetActive(false);
        TopicText.text = "";

        Mark2.SetActive(false);

        HBackBTN.SetActive(true);
        isQH2 = true;
        if (isQH1 && isQH2)
        {
            HelaController.isHelaNew = false;
        }
        yield return new WaitForSeconds(1f);

        /*
        FadeImage.SetActive(true);
        PlayFadeOut();
        yield return new WaitForSeconds(1f);
        PlayFadeIn();
        yield return new WaitForSeconds(1f);
        FadeImage.SetActive(false);
        Debug.Log("��� ����");
        */
        //NT_background.SetActive(true);
        StartCoroutine(NT_FadeCoroutine());
        Debug.Log("��� ����");
        yield return new WaitForSeconds(2f);
        Debug.Log("��� ���� 2");
        HelaTemp.SetActive(true);
        yield return new WaitForSeconds(1f);
        //���ƾ�
        Scream1.SetActive(true);

        yield return new WaitForSeconds(1f);
        //��
        Scream1.SetActive(false);
        Scream2.SetActive(true);
        yield return new WaitForSeconds(1f);
        Debug.Log("��� ���� 3");
        //
        StartCoroutine(NT_FadeCoroutine());
        yield return new WaitForSeconds(1f);
        Scream2.SetActive(false);
        HelaTemp.SetActive(false);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => dialogueSystemH3.UpdateDialogue());
        Hela.SetActive(true);
    }

    IEnumerator NT_FadeCoroutine()
    {
        NT_background.gameObject.SetActive(true);
        alpha = NT_background.color;

        while (alpha.a < 3f) //1f
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 3, time);
            //alpha.a = Mathf.Lerp(0, 3, time);
            NT_background.color = alpha;
            yield return null;
        }

        time = 0f;
        
        //HelaPaper.SetActive(true);
        //theCam.HelaBig();

        yield return new WaitForSeconds(1f);

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            NT_background.color = alpha;
            yield return null;
        }

        NT_background.gameObject.SetActive(false);
        yield return null;

    }

    // Start is called before the first frame update
    

    /*
    public void PlayFadeIn()
    {
        // ��� �ð� ���.  
        // 2��(animTime)���� ����� �� �ֵ��� animTime���� ������.  
        time += Time.deltaTime / animTime;

        // Image ������Ʈ�� ���� �� �о����.  
        Color color = fadeImage.color;
        // ���� �� ���.  
        color.a = Mathf.Lerp(start, end, time);
        // ����� ���� �� �ٽ� ����.  
        fadeImage.color = color;
        // Debug.Log(time);
    }

    // ����->���
    public void PlayFadeOut()
    {
        // ��� �ð� ���.  
        // 2��(animTime)���� ����� �� �ֵ��� animTime���� ������.  
        time += Time.deltaTime / animTime;

        // Image ������Ʈ�� ���� �� �о����.  
        Color color = fadeImage.color;
        // ���� �� ���.  
        color.a = Mathf.Lerp(end, start, time);  //FadeIn���� �޸� start, end�� �ݴ��.
        // ����� ���� �� �ٽ� ����.  
        fadeImage.color = color;
    }
    */
}
