using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftComplete : MonoBehaviour
{
    [SerializeField] CraftingTutorialTest craftingTutorialTest;

    void ServeResultItem()
    {
        craftingTutorialTest.StartCoroutine("SixthBranch");
    }
}
