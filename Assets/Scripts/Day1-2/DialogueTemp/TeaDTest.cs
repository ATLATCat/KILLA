using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeaDTest : MonoBehaviour
{
    [SerializeField]
    private DialogueSystem dialogueSystem01;
    [SerializeField]
    private DialogueSystem dialogueSystem02;
    [SerializeField]
    private DialogueSystem dialogueSystem03;

    public GameObject Micha;
    public GameObject Auro;
    public GameObject Hela;

    public GameObject Black;
    public GameObject People;
    public GameObject Hand;
    public GameObject KillTheLa;

    public GameObject AI;
    public GameObject AN;
    public GameObject AT;

    public GameObject MI;
    public GameObject MN;
    public GameObject MT;

    public GameObject HI;
    public GameObject HN;
    public GameObject HT;

    /*
    private Text tAT;
    private Text tMT;
    private Text tHT;
    */

    [Header("검은 화면(투명X) 페이드인")]
    public Image NT_background;
    Color alpha;

    // 페이드인 시간 조절
    float time = 0f;
    float F_time = 1.5f;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        
        //커피토크식 대화
        yield return new WaitUntil(() => dialogueSystem01.UpdateDialogue());
        Micha.SetActive(true);
        Auro.SetActive(true);
        Hela.SetActive(true);
        //3명있는 베스타
        //TeaCoffeeManager.isBuried = true;
        //StartCoroutine(MichaClose());
        //StartCoroutine(buried());
        StartCoroutine(NT_FadeCoroutine());
        
        yield return new WaitForSeconds(1f);
        Black.SetActive(true);
        yield return new WaitForSeconds(1f);
        People.SetActive(true);
        Hand.SetActive(true);
        yield return new WaitForSeconds(3f);
        People.SetActive(false);
        Hand.SetActive(false);
        KillTheLa.SetActive(true);
        yield return new WaitForSeconds(3f);
        KillTheLa.SetActive(false);
        Black.SetActive(false);
        //
        yield return new WaitUntil(() => dialogueSystem02.UpdateDialogue());
        AI.SetActive(true);
        AN.SetActive(true);
        AT.SetActive(true);

        HI.SetActive(true);
        HN.SetActive(true);
        HT.SetActive(true);

        MI.SetActive(true);
        MN.SetActive(true);
        MT.SetActive(true);

        /*
        tAT = GameObject.Find("Auro_Text").GetComponent<Text>();
        tMT = GameObject.Find("Micha_Text").GetComponent<Text>();
        tHT = GameObject.Find("Hera_Text").GetComponent<Text>();

        tAT.text = "!";
        tMT.text = "!";
        tHT.text = "!";
        */

        yield return new WaitForSeconds(2f);
        AI.SetActive(false);
        AN.SetActive(false);
        AT.SetActive(false);

        HI.SetActive(false);
        HN.SetActive(false);
        HT.SetActive(false);

        MI.SetActive(false);
        MN.SetActive(false);
        MT.SetActive(false);
        yield return new WaitForSeconds(2f);

        yield return new WaitUntil(() => dialogueSystem03.UpdateDialogue());
        Micha.SetActive(true);
        Auro.SetActive(true);
        Hela.SetActive(true);

        SceneManager.LoadScene("TeaCoffee");
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

    /*
    private IEnumerator MichaClose()
    {
        yield return new WaitForSeconds(1f);
        CM_All.SetActive(false);
        CM_Micha.SetActive(true);
        CM_Auro.SetActive(false);
        CM_Hela.SetActive(false);
        CM_ML.SetActive(false);
        CM_AL.SetActive(false);
        isAll = false;
        Debug.Log("미카엘라 클로즈업");

    }
    */

    /*
private IEnumerator buried()
{
    yield return new WaitForSeconds(2f);
    Debug.Log("stockend");

}
*/



}
