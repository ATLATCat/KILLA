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


    [System.Serializable]
    public struct DialogueEvent
    {
        public float delay;
        public DialogueSystem dialogueSystem;
        public List<UnityEvent> OnDialoguesEnd;
    }

    /* 대화 시스템 */
    public List<DialogueEvent> dialogueEvents_beforeThought;
    public List<DialogueEvent> dialogueEvents_afterThought;
    public List<DialogueEvent> dialogueEvents_afterCombine;


    /* 오디오 소스 */
    public AudioSource audioSourceBGM;

    public GameObject thoughtBubble;
    public List<ThoughtBubble> thoughtBubbles;
    public List<CombinableBubbleBubble> combinableBubbles;
    public GameObject combinedBubble;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        Init();

        foreach (var dialogueEvent in dialogueEvents_beforeThought)
        {
            if (dialogueEvent.delay > 0)
                yield return new WaitForSeconds(dialogueEvent.delay);
            if (dialogueEvent.dialogueSystem != null)
                yield return new WaitUntil(() => dialogueEvent.dialogueSystem.UpdateDialogue());
            foreach (var onDialobueEnd in dialogueEvent.OnDialoguesEnd)
            {
                onDialobueEnd?.Invoke();
            }
        }

        thoughtBubble.SetActive(true);
        ActiveThoughtBubble();

        yield return new WaitUntil(() => IsAllThoughtBubblePlayed());

        foreach (var dialogueEvent in dialogueEvents_afterThought)
        {
            if (dialogueEvent.delay > 0)
                yield return new WaitForSeconds(dialogueEvent.delay);
            if (dialogueEvent.dialogueSystem != null)
                yield return new WaitUntil(() => dialogueEvent.dialogueSystem.UpdateDialogue());
            foreach (var onDialobueEnd in dialogueEvent.OnDialoguesEnd)
            {
                onDialobueEnd?.Invoke();
            }
        }

        DeactiveThoughtBubble();
        thoughtBubble.SetActive(false);
        Aurora.GetComponent<BoxCollider2D>().enabled = true;

        foreach (var dialogueEvent in dialogueEvents_afterCombine)
        {
            if (dialogueEvent.delay > 0)
                yield return new WaitForSeconds(dialogueEvent.delay);
            if (dialogueEvent.dialogueSystem != null)
                yield return new WaitUntil(() => dialogueEvent.dialogueSystem.UpdateDialogue());
            foreach (var onDialobueEnd in dialogueEvent.OnDialoguesEnd)
            {
                onDialobueEnd?.Invoke();
            }
        }
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

    void ActiveCombinedBubble(Vector2 position)
    {
        combinedBubble.SetActive(true);
        combinedBubble.transform.position = position;
    }

    void PlayAudio(AudioClip clip)
    {
        if (clip == null) return;

        audioSourceBGM.clip = clip;
        audioSourceBGM.Play();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
