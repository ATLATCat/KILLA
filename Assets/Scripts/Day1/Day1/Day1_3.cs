using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Day1_3 : MonoBehaviour
{
    /* 대화 시스템 */
    [SerializeField]
    private DialogueSystem dialogueSystem1;
    [SerializeField]
    private DialogueSystem dialogueSystem2;
    [SerializeField]
    private DialogueSystem dialogueSystem3;
    [SerializeField]
    private DialogueSystem dialogueSystem4;
    [SerializeField]
    private DialogueSystem dialogueSystem5;

    /* 페이드인 */
    public Animation Fade_Effect;

    /* 발할라 사망 장면 */
    public GameObject ValhallaDeath1;
    public GameObject ValhallaDeath2;
    public GameObject ValhallaDeath3;

    /* NPC */
    public GameObject Kimera;
    public GameObject Michaella;

    /* 오디오 소스 */
    public AudioSource audioSourceBGM;
    public AudioSource audioSourceEffect;

    /* BGM */
    public AudioClip michaella_come;
    public AudioClip heart_beating;

    /* Effect */
    public AudioClip meow;
    public AudioClip michaella_walking;
    public AudioClip beep;

    private IEnumerator Start()
    {
        ValhallaDeath1.SetActive(false);
        ValhallaDeath2.SetActive(false);
        ValhallaDeath3.SetActive(false);

        Kimera.SetActive(false);
        Michaella.SetActive(false);

        Fade_Effect.Play("FadeIn");
        yield return new WaitForSeconds(4);

        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => dialogueSystem1.UpdateDialogue());

        // 고양이 울음 소리
        PlayEffect("meow");
        Kimera.SetActive(true);
        yield return new WaitForSeconds(2f);

        // 두번째 대사 분기 시작
        yield return new WaitUntil(() => dialogueSystem2.UpdateDialogue());
        yield return new WaitForSeconds(2f);
        Kimera.SetActive(false);

        // 세번째 대사 분기 시작
        yield return new WaitUntil(() => dialogueSystem3.UpdateDialogue());
        yield return new WaitForSeconds(1f);

        // 네번째 대사 분기 시작 - 미카엘라 등장
        PlayEffect("michaella_walking");
        yield return new WaitForSeconds(3f);
        audioSourceEffect.Pause(); 
        PlayBGM("michaella_come");
        yield return new WaitUntil(() => dialogueSystem4.UpdateDialogue());
        

        // 발할라 사망 장면 연출
        ValhallaDeath1.SetActive(true);
        audioSourceBGM.Pause();
        PlayEffect("beep");
        yield return new WaitForSeconds(0.2f);
        ValhallaDeath2.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        ValhallaDeath3.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        ValhallaDeath1.SetActive(false);
        ValhallaDeath2.SetActive(false);
        ValhallaDeath3.SetActive(false);
        audioSourceEffect.Pause();
        audioSourceBGM.Pause();
        PlayBGM("heart_beating");
        Michaella.SetActive(true);
        yield return new WaitForSeconds(3f);

        // 네번째 대사 분기 시작
        yield return new WaitUntil(() => dialogueSystem5.UpdateDialogue());

        // 페이드 아웃
        Fade_Effect.Play("FadeOut");
        yield return new WaitForSeconds(2f);

        // 씬 전환 (마지막)
        SceneManager.LoadScene("ThanksPlaying");
    }

    void PlayBGM(string action)
    {
        switch (action)
        {
            case "michaella_come":
                audioSourceBGM.clip = michaella_come;
                break;

            case "heart_beating":
                audioSourceBGM.clip = heart_beating;
                break;
        }

        audioSourceBGM.Play();

    }

    void PlayEffect(string action)
    {
        switch (action)
        {
            case "meow":
                audioSourceEffect.clip = meow;
                break;

            case "michaella_walking":
                audioSourceEffect.clip = michaella_walking;
                break;

            case "beep":
                audioSourceEffect.clip = beep;
                break;
        }

        audioSourceEffect.Play();
    }
}
