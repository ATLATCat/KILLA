using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThoughtBubble : MonoBehaviour
{
    public System.Action OnCompleted;
    public System.Action OnStartPlay;

    [SerializeField]
    private DialogueSystem dialogueSystem = null;

    public bool IsAlreadyPlayed => isAlreadyPlayed;
    private bool isAlreadyPlayed = false;

    public void SetActive(bool value)
    {
        if (value == true)
        {
            GetComponent<Image>().enabled = true;
            if (GetComponent<Button>() is Button button)
                button.enabled = true;
        }

        else
        {
            GetComponent<Image>().enabled = false;
            if (GetComponent<Button>() is Button button)
                button.enabled = false;
        }
    }

    public void PlayDialogue()
    {
        if (dialogueSystem == null) return;

        StartCoroutine(CoPlayDialogue());
        OnStartPlay?.Invoke();
    }

    private IEnumerator CoPlayDialogue()
    {
        yield return new WaitUntil(() => dialogueSystem.UpdateDialogue());
        isAlreadyPlayed = true;
        OnCompleted?.Invoke();
    }
}
