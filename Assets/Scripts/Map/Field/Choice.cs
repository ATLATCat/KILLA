using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public GameObject choiceSystem;
    public GameObject poisonPlant;
    public GameObject Move_Canvas;


    public void choiceTrue()
    {
        choiceSystem.SetActive(false);
        Destroy(poisonPlant);
        Move_Canvas.SetActive(true);
    }

    public void choiceFalse()
    {      
        choiceSystem.SetActive(false);
        // PlayerMove.flag = 0;
    }


    

}
