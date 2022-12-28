using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicked : MonoBehaviour
{
    [SerializeField]
    private CraftingTutorialTest GameManager;
 
    void isDrawerClicked()
    {
        GameManager.StartCoroutine("SecondBranch");
    }
}
