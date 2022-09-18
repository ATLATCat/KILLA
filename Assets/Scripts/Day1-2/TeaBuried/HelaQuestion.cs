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

    //페이드
    /*
    public float animTime = 2f;         // Fade 애니메이션 재생 시간 (단위:초).  
    public Image fadeImage;            // UGUI의 Image컴포넌트 참조 변수.  

    private float start = 1f;           // Mathf.Lerp 메소드의 첫번째 값.  
    private float end = 0f;             // Mathf.Lerp 메소드의 두번째 값.  
    private float time = 0f;            // Mathf.Lerp 메소드의 시간 값.  


    public bool stopIn = false; //false일때 실행되는건데, 초기값을 false로 한 이유는 게임 시작할때 페이드인으로 들어가려고...그게 싫으면 true로 하면됨.
    public bool stopOut = true;
    */

    [Header("검은 화면(투명X) 페이드인")]
    public Image NT_background;
    Color alpha;

    // 페이드인 시간 조절
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
        // Image 컴포넌트를 검색해서 참조 변수 값 설정.  
        //fadeImage = GetComponent<Image>();
    }

    public void Hela_Q1()
    {
        Debug.Log("첫번째 질문");

        TopicText.text = "희라에 대하여 물어본다. ";
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
        Debug.Log("두 번째 질문");
        TopicText.text = "나이에 대한 걸 물어본다.";
        TopicBox.SetActive(true);
        TopicCheck.SetActive(true);

        HBackBTN.SetActive(false);
        if (!isQH2)
        { 
            StartCoroutine(HQ2()); 
        }
        //연출 코루틴

        //남은 대화 코루틴
        //

        if (isQH2)
        {
            HBackBTN.SetActive(true);
        }
        Debug.Log("희라 Q2");
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
        Debug.Log("희라 연출");
        */
        //NT_background.SetActive(true);
        StartCoroutine(NT_FadeCoroutine());
        Debug.Log("희라 연출");
        yield return new WaitForSeconds(2f);
        Debug.Log("희라 연출 2");
        HelaTemp.SetActive(true);
        yield return new WaitForSeconds(1f);
        //꺄아악
        Scream1.SetActive(true);

        yield return new WaitForSeconds(1f);
        //꺅
        Scream1.SetActive(false);
        Scream2.SetActive(true);
        yield return new WaitForSeconds(1f);
        Debug.Log("희라 연출 3");
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
        // 경과 시간 계산.  
        // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기.  
        time += Time.deltaTime / animTime;

        // Image 컴포넌트의 색상 값 읽어오기.  
        Color color = fadeImage.color;
        // 알파 값 계산.  
        color.a = Mathf.Lerp(start, end, time);
        // 계산한 알파 값 다시 설정.  
        fadeImage.color = color;
        // Debug.Log(time);
    }

    // 투명->흰색
    public void PlayFadeOut()
    {
        // 경과 시간 계산.  
        // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기.  
        time += Time.deltaTime / animTime;

        // Image 컴포넌트의 색상 값 읽어오기.  
        Color color = fadeImage.color;
        // 알파 값 계산.  
        color.a = Mathf.Lerp(end, start, time);  //FadeIn과는 달리 start, end가 반대다.
        // 계산한 알파 값 다시 설정.  
        fadeImage.color = color;
    }
    */
}
