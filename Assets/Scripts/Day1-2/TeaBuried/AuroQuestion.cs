using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AuroQuestion : MonoBehaviour
{
    [SerializeField]
    private DialogueSystem dialogueSystemA1;
    [SerializeField]
    private DialogueSystem dialogueSystemA2;

    public GameObject Auro;
    public GameObject Check1;
    public GameObject Check2;

    public GameObject Mark1;
    public GameObject Mark2;

    public GameObject ABackBTN;

    public GameObject TopicBox;
    public GameObject TopicCheck;
    //public GameObject TopicText;
    private Text TopicText;

    public static bool isQA1 = false;
    public static bool isQA2 = false;

    public void Auro_Q1()
    {
        Debug.Log("첫번째 질문");
        TopicText.text = "섬에 대하여 물어본다.";
        TopicBox.SetActive(true);
        TopicCheck.SetActive(true);

        ABackBTN.SetActive(false);
        //StartCoroutine(AQ1());
        if (!isQA1)
        {
            StartCoroutine(AQ1());
        }

        if (isQA1)
        {
            ABackBTN.SetActive(true);
        }
    }

    private IEnumerator AQ1()
    {
        yield return new WaitUntil(() => dialogueSystemA1.UpdateDialogue());
        Auro.SetActive(true);
        Check1.SetActive(true);
        TopicBox.SetActive(false);
        TopicCheck.SetActive(false);
        TopicText.text = "";

        Mark1.SetActive(false);

        ABackBTN.SetActive(true);
        isQA1 = true;

        if(isQA1 && isQA2)
        {
            AuroController.isAuroNew = false;
        }
    }

    public void Auro_Q2()
    {
        Debug.Log("두 번째 질문");
        TopicText.text = "오로라에 대하여 물어본다.";
        TopicBox.SetActive(true);
        TopicCheck.SetActive(true);

        ABackBTN.SetActive(false);

        //StartCoroutine(AQ2());

        if (!isQA2)
        {
            StartCoroutine(AQ2());
        }

        if (isQA2)
        {
            ABackBTN.SetActive(true);
        }
    }

    private IEnumerator AQ2()
    {
        yield return new WaitUntil(() => dialogueSystemA2.UpdateDialogue());
        Auro.SetActive(true);
        Check2.SetActive(true);
        TopicBox.SetActive(false);
        TopicCheck.SetActive(false);
        TopicText.text = "";

        Mark2.SetActive(false);

        ABackBTN.SetActive(true);
        isQA2 = true;
        if (isQA1 && isQA2)
        {
            AuroController.isAuroNew = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TopicText = GameObject.Find("AuroTopic").GetComponent<Text>();
        TopicText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
