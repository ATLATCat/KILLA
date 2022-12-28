using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCount : MonoBehaviour
{
    int count = 0;
    public Button CraftButton;
    public CraftingTutorialTest GameManager;

    public void CountHowManyClicks()
    {
        count++;

        if(count == 5)
        {
            GameManager.StartCoroutine("FifthBranch");
            CraftButton.interactable = true;
        }
        else if(count > 5)
        {
            CraftButton.interactable = false;
        }

    }
}
