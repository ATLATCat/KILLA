using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AfterTeatime : MonoBehaviour
{
    public string nextSceneName;

    /* 오로라 */
    public GameObject Aurora;
    public GameObject Mechaela;

    /* 노티 애니메이션 */
    public Animation Ani_Noti;
    public Animation Ani_Aurora;

    /* 배경 애니메이션 */
    public Animation Background;

    /* 대화 시스템 */ 
    public DialogueSystem DialogSystem1;
    public DialogueSystem DialogSystem2;
    public DialogueSystem DialogSystem3; 
    public DialogueSystem DialogSystem4;
    public DialogueSystem DialogSystem5;

    public UnityEvent OnDialog1End;
    public UnityEvent OnDialog2End;
    public UnityEvent OnDialog3End;
    public UnityEvent OnDialog4End;
    public UnityEvent OnDialog5End;

    /* 오디오 소스 */
    public AudioSource audioSourceBGM;

    /* 오디오 클립 */
    public AudioClip audioClip_chair;
    public AudioClip audioClip_bleak;
    public AudioClip audioClip_click;

    public GameObject thoughtBubble;
    public List<ThoughtBubble> thoughtBubbles;
    public List<CombinableBubbleBubble> combinableBubbles;
    public GameObject combinedBubble;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        Init();

        yield return new WaitUntil(() => DialogSystem1.UpdateDialogue());

        PlayAudio(audioClip_chair);
        Mechaela.SetActive(false);
        OnDialog1End?.Invoke();

        yield return new WaitUntil(() => DialogSystem2.UpdateDialogue());

        PlayAudio(audioClip_bleak);
        OnDialog2End?.Invoke();

        yield return new WaitUntil(() => DialogSystem3.UpdateDialogue());

        OnDialog3End?.Invoke();

        yield return new WaitUntil(() => DialogSystem4.UpdateDialogue());

        PlayAudio(audioClip_click);
        OnDialog4End?.Invoke();

        yield return new WaitUntil(() => DialogSystem5.UpdateDialogue());

        thoughtBubble.SetActive(true);
        ActiveThoughtBubble();
        OnDialog5End?.Invoke();

        yield return new WaitUntil(() => IsAllThoughtBubblePlayed());
        
        DeactiveThoughtBubble();
        thoughtBubble.SetActive(false);
        Aurora.GetComponent<BoxCollider2D>().enabled = true;
    }

    void Init()
    {
        foreach (var thoughtBubble in thoughtBubbles)
        {
            thoughtBubble.OnStartPlay += () => DeactiveThoughtBubble();
            thoughtBubble.OnCompleted += () => ActiveThoughtBubble();
        }
        foreach (var combinableBubble in combinableBubbles)
        {
            combinableBubble.OnCombine += ActiveCombinedBubble;
        }

        DeactiveThoughtBubble();
        thoughtBubble.SetActive(false);
    }

    public void ActiveThoughtBubble()
    {
        foreach (var thoughtBuble in thoughtBubbles)
        {
            if (thoughtBuble.IsAlreadyPlayed == false)
            {
                thoughtBuble.SetActive(true);
            }
        }
    }

    public void DeactiveThoughtBubble()
    {
        foreach (var thoughtBuble in thoughtBubbles)
        {
            thoughtBuble.SetActive(false);
        }
    }

    bool IsAllThoughtBubblePlayed()
    {
        Aurora.SetActive(true);
        foreach (var thoughtBuble in thoughtBubbles)
        {
            if (thoughtBuble.IsAlreadyPlayed == false)
                return false;
        }
        return true;
    }

    void ActiveCombinedBubble()
    {
        combinedBubble.SetActive(true);
    }

    void PlayAudio(AudioClip clip)
    {
        if (clip == null) return;

        audioSourceBGM.clip = clip;
        audioSourceBGM.Play();
    }
}
