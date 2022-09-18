using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ValhallaDeath1 : MonoBehaviour
{
    /* 발할라 독백 */
    public DialogueSystem1 DialogueSystem1;

    /* 미카엘라 독백 */
    public DialogueSystem1 DialogueSystem2;
    public DialogueSystem1 DialogueSystem3;

    /* 조명 */
    public Animation Panel_Light_Ani;

    /* 오디오 소스 */
    public AudioSource audioSourceBGM; // BGM
    public AudioSource audioSourceEffect; // 이펙트

    /* 오디오 클립 - BGM */
    public AudioClip amb_roomtone; // 배경 음악
    public AudioClip kill_amb; // 미카엘라 살인 배경 음악

    /* 오디오 클립 - Effect */
    public AudioClip footstep_axedrag; // 미카엘라 도끼끄는 소리
    public AudioClip axeKill_01; // 도끼 휘두르는 소리
    public AudioClip pen_redline_01; // 목 절취선 소리
    public AudioClip pen_redline_02;
    public AudioClip pen_redline_03; 
    public AudioClip pen_redline_04;
    public AudioClip pen_redline_05;
    public AudioClip neck_tear; // 빨간선 찢어지는 소리
    public AudioClip neck_blood; // 찢은 후 피 떨어지는 소리
    public AudioClip tiktok;

    /* 텍스트창 */
    public GameObject Canvas_Text;

    /* 발할라 사망 */
    public Animation AxeLine; // 발할라 목 절취선 
    public GameObject Panel_BlackOut;
    public GameObject Panel_BlackOut2;
    public Animation Image_Blood;
    public GameObject Canvas_Death1;
    public GameObject Canvas_Death2;



    private void Awake()
    {
        Setup();
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        PlayBGM("amb_roomtone");
        Panel_Light_Ani.Play("LightOff");
        yield return new WaitForSeconds(3f);
        yield return new WaitUntil(() => DialogueSystem1.UpdateDialog());

        Panel_Light_Ani.Play("BlackOut");
  
        yield return new WaitForSeconds(5f);

        PlayBGM("kill_amb");
        PlayEffect("footstep_axedrag");
        yield return new WaitUntil(() => DialogueSystem2.UpdateDialog());
 
        yield return new WaitForSeconds(2f);

        yield return new WaitUntil(() => DialogueSystem3.UpdateDialog());
        yield return new WaitForSeconds(1.5f);
        PlayEffect("axeKill_01");
        yield return new WaitForSeconds(2.7f);
        Panel_Light_Ani.Play("BlackOut2");

        yield return new WaitForSeconds(2f);
        Canvas_Text.SetActive(false);

        PlayBGM("amb_roomtone");
        yield return new WaitForSeconds(1f);
        Canvas_Death1.SetActive(true);
        AxeLine.Play("AxeLine");

        // 목 찢어지는 소리 - 추후 수정 예정 
        PlayEffect("pen_redline_01");
        yield return new WaitForSeconds(0.3f);
        PlayEffect("pen_redline_02");
        yield return new WaitForSeconds(0.3f);
        PlayEffect("pen_redline_03");
        yield return new WaitForSeconds(0.3f);
        PlayEffect("pen_redline_04");
        yield return new WaitForSeconds(0.3f);
        PlayEffect("pen_redline_05");
        yield return new WaitForSeconds(0.3f);
        PlayEffect("pen_redline_03");
        yield return new WaitForSeconds(0.3f);
        PlayEffect("pen_redline_01");
        yield return new WaitForSeconds(0.4f);
        PlayEffect("pen_redline_04");
        yield return new WaitForSeconds(0.3f);
        PlayEffect("pen_redline_01");
        yield return new WaitForSeconds(0.3f);
        PlayEffect("pen_redline_02");
        yield return new WaitForSeconds(1f);


        Panel_BlackOut.SetActive(true);
        PlayEffect("neck_tear");
        yield return new WaitForSeconds(4f);
        
        Canvas_Death2.SetActive(true);
        Image_Blood.Play("Blood");
        PlayEffect("neck_blood");
        yield return new WaitForSeconds(3f);
        audioSourceEffect.Pause();
        // 암전
        Panel_BlackOut2.SetActive(true);
        yield return new WaitForSeconds(4f);
        PlayEffect("tiktok");
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("Day1-3");
    }

    void Setup()
    {
        Canvas_Text.SetActive(true);
        Panel_BlackOut.SetActive(false);
        Panel_BlackOut2.SetActive(false);
        Canvas_Death1.SetActive(false);
        Canvas_Death2.SetActive(false);
    }

    void PlayBGM(string action)
    {
        switch (action)
        {
            case "amb_roomtone":
                audioSourceBGM.clip = amb_roomtone;
                break;

            case "kill_amb":
                audioSourceBGM.clip = kill_amb;
                break;
        }

        audioSourceBGM.Play();
    }

    void PlayEffect(string action)
    {
        switch (action)
        {
            case "footstep_axedrag":
                audioSourceEffect.clip = footstep_axedrag;
                break;

            case "axeKill_01":
                audioSourceEffect.clip = axeKill_01;
                break;

            case "pen_redline_01":
                audioSourceEffect.clip = pen_redline_01;
                break;

            case "pen_redline_02":
                audioSourceEffect.clip = pen_redline_02;
                break;

            case "pen_redline_03":
                audioSourceEffect.clip = pen_redline_03;
                break;

            case "pen_redline_04":
                audioSourceEffect.clip = pen_redline_04;
                break;

            case "pen_redline_05":
                audioSourceEffect.clip = pen_redline_05;
                break;

            case "neck_tear":
                audioSourceEffect.clip = neck_tear;
                break;

            case "neck_blood":
                audioSourceEffect.clip = neck_blood;
                break;

            case "tiktok":
                audioSourceEffect.clip = tiktok;
                break;
        }

        audioSourceEffect.Play();

    }
}
