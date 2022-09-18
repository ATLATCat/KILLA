using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MichaQuestion : MonoBehaviour
{
    [SerializeField]
    private DialogueSystem dialogueSystemM1;
    [SerializeField]
    private DialogueSystem dialogueSystemM2;
    [SerializeField]
    private DialogueSystem dialogueSystemM3;

    public GameObject Micha;
    public GameObject Check1;
    public GameObject Check2;
    public GameObject Check3;
    public GameObject Btn3;

    public GameObject Mark1;
    public GameObject Mark2;
    public GameObject Mark3;

    public GameObject MBackBTN;

    public GameObject TopicBox;
    public GameObject TopicCheck;
    //public GameObject TopicText;
    private Text TopicText;

    public static bool is1stEnd = false;
    public static bool is2ndEnd = false;
    public static bool is3rdEnd = false;

    //private IEnumerator Micha_Q1()
    public void Micha_Q1()
    {
        Debug.Log("첫번째 질문");
        //dialogueSystemM1.UpdateDialogue();
        TopicText.text = "섬에 대하여 물어본다.";
        TopicBox.SetActive(true);
        TopicCheck.SetActive(true);

        MBackBTN.SetActive(false);

        //StartCoroutine(MQ1());

        if (!is1stEnd)
        {
            StartCoroutine(MQ1());
        }

        if (is1stEnd)
        {
            MBackBTN.SetActive(true);
        }

        Debug.Log("첫번째 질문 끝");     
    }
    private IEnumerator MQ1()
    {
        yield return new WaitUntil(() => dialogueSystemM1.UpdateDialogue());
        Micha.SetActive(true);
        Check1.SetActive(true);
        TopicBox.SetActive(false);
        TopicCheck.SetActive(false);
        TopicText.text = "";

        Mark1.SetActive(false);

        MBackBTN.SetActive(true);

        is1stEnd = true;
        if (is1stEnd && is2ndEnd)
        {
            Debug.Log("세번째 질문");
            Btn3.SetActive(true);
        }
    }

    public void Micha_Q2()
    {
        Debug.Log("두 번째 질문");

        TopicText.text = "상처에 대하여 물어본다.";
        TopicBox.SetActive(true);
        TopicCheck.SetActive(true);

        MBackBTN.SetActive(false);

        //StartCoroutine(MQ2());

        if (!is2ndEnd)
        {
            StartCoroutine(MQ2());
        }

        if (is2ndEnd)
        {
            MBackBTN.SetActive(true);
        }

        Debug.Log("두 번째 질문 끝");
    }

    private IEnumerator MQ2()
    {
        yield return new WaitUntil(() => dialogueSystemM2.UpdateDialogue());
        Micha.SetActive(true);
        Check2.SetActive(true);

        TopicBox.SetActive(false);
        TopicCheck.SetActive(false);
        TopicText.text = "";

        Mark2.SetActive(false);

        MBackBTN.SetActive(true);

        is2ndEnd = true;
        if (is1stEnd && is2ndEnd)
        {
            Debug.Log("세번째 질문");
            Btn3.SetActive(true);
        }
    }

    public void Micha_Q3()
    {
        Debug.Log("3 번째 질문");

        TopicText.text = "숨기는 것이 있는지 물어본다. ";
        TopicBox.SetActive(true);
        TopicCheck.SetActive(true);

        MBackBTN.SetActive(false);

        //StartCoroutine(MQ3());

        if (!is3rdEnd)
        {
            StartCoroutine(MQ3());
        }

        if (is3rdEnd)
        {
            MBackBTN.SetActive(true);
        }

        Debug.Log("3 번째 질문 끝");
    }

    private IEnumerator MQ3()
    {
        yield return new WaitUntil(() => dialogueSystemM3.UpdateDialogue());
        Micha.SetActive(true);
        Check3.SetActive(true);

        TopicBox.SetActive(false);
        TopicCheck.SetActive(false);
        TopicText.text = "";

        Mark3.SetActive(false);

        MBackBTN.SetActive(true);

        MiChaController.isMichaNew = false;
        is3rdEnd = true;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        TopicText = GameObject.Find("MichaTopic").GetComponent<Text>();
        TopicText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
