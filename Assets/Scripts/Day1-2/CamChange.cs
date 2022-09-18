using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CamChange : MonoBehaviour
{
    public GameObject CM_All, CM_Micha, CM_Auro, CM_Hela, 
        CM_ML, CM_AL, CM_HL, CM_HB;

    public static bool isAll = true;
    //isQH1, isQH2, is1stEnd, is2ndEnd, is3rdEnd, isQA1, isQA2
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(CamChange.isAll && HelaQuestion.isQH1 && HelaQuestion.isQH2 && MichaQuestion.is1stEnd && MichaQuestion.is2ndEnd && MichaQuestion.is3rdEnd && AuroQuestion.isQA1 && AuroQuestion.isQA2)
        {
            SceneManager.LoadScene("Aurora1");
        }
        */

        /*
        //3명 다 있는 화면
        if(Input.GetKeyDown(KeyCode.Z))
        {
            CM_All.SetActive(true);
            CM_Micha.SetActive(false);
            CM_Auro.SetActive(false);
            CM_Hela.SetActive(false);
            CM_ML.SetActive(false);
            CM_AL.SetActive(false);
            CM_HL.SetActive(false);
            isAll = true;
        }

        //미카엘라 클로즈업
        if (Input.GetKeyDown(KeyCode.M))
        {
            CM_All.SetActive(false);
            CM_Micha.SetActive(true);
            CM_Auro.SetActive(false);
            CM_Hela.SetActive(false);
            CM_ML.SetActive(false);
            CM_AL.SetActive(false);
            CM_HL.SetActive(false);
            isAll = false;
        }

        //오로라 클로즈업
        if (Input.GetKeyDown(KeyCode.A))
        {
            CM_All.SetActive(false);
            CM_Micha.SetActive(false);
            CM_Auro.SetActive(true);
            CM_Hela.SetActive(false);
            CM_ML.SetActive(false);
            CM_AL.SetActive(false);
            CM_HL.SetActive(false);
            isAll = false;
        }

        //희라 클로즈업
        if (Input.GetKeyDown(KeyCode.H))
        {
            CM_All.SetActive(false);
            CM_Micha.SetActive(false);
            CM_Auro.SetActive(false);
            CM_Hela.SetActive(true);
            CM_ML.SetActive(false);
            CM_AL.SetActive(false);
            CM_HL.SetActive(false);
            isAll = false;
        }

        //미카엘라 질문
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CM_All.SetActive(false);
            CM_Micha.SetActive(false);
            CM_Auro.SetActive(false);
            CM_Hela.SetActive(false);
            CM_ML.SetActive(true);
            CM_AL.SetActive(false);
            CM_HL.SetActive(false);
            isAll = false;
        }

        //오로라 질문
        if (Input.GetKeyDown(KeyCode.W))
        {
            CM_All.SetActive(false);
            CM_Micha.SetActive(false);
            CM_Auro.SetActive(false);
            CM_Hela.SetActive(false);
            CM_ML.SetActive(false);
            CM_AL.SetActive(true);
            CM_HL.SetActive(false);
            isAll = false;
        }
        */
    }

    public void MichaClose()
    {
        
        CM_All.SetActive(false);
        CM_Micha.SetActive(true);
        CM_Auro.SetActive(false);
        CM_Hela.SetActive(false);
        CM_ML.SetActive(false);
        CM_AL.SetActive(false);
        CM_HL.SetActive(false);
        isAll = false;
        CM_HB.SetActive(false);
    }

    public void MichaQ()
    {
        CM_All.SetActive(false);
        CM_Micha.SetActive(false);
        CM_Auro.SetActive(false);
        CM_Hela.SetActive(false);
        CM_ML.SetActive(true);
        CM_AL.SetActive(false);
        CM_HL.SetActive(false);
        isAll = false;
        CM_HB.SetActive(false);
    }

    public void AuroClose()
    {
        CM_All.SetActive(false);
        CM_Micha.SetActive(false);
        CM_Auro.SetActive(true);
        CM_Hela.SetActive(false);
        CM_ML.SetActive(false);
        CM_AL.SetActive(false);
        CM_HL.SetActive(false);
        isAll = false;
        CM_HB.SetActive(false);
    }

    public void AuroQ()
    {
        CM_All.SetActive(false);
        CM_Micha.SetActive(false);
        CM_Auro.SetActive(false);
        CM_Hela.SetActive(false);
        CM_ML.SetActive(false);
        CM_AL.SetActive(true);
        CM_HL.SetActive(false);
        isAll = false;
        CM_HB.SetActive(false);
    }


    public void HelaClose()
    {
        CM_All.SetActive(false);
        CM_Micha.SetActive(false);
        CM_Auro.SetActive(false);
        CM_Hela.SetActive(true);
        CM_ML.SetActive(false);
        CM_AL.SetActive(false);
        CM_HL.SetActive(false);
        isAll = false;
        CM_HB.SetActive(false);
    }

    public void HelaQ()
    {
        CM_All.SetActive(false);
        CM_Micha.SetActive(false);
        CM_Auro.SetActive(false);
        CM_Hela.SetActive(false);
        CM_ML.SetActive(false);
        CM_AL.SetActive(false);
        CM_HL.SetActive(true);
        isAll = false;
        CM_HB.SetActive(false);
    }

    public void MBackBTN()
    {
        CM_All.SetActive(true);
        CM_Micha.SetActive(false);
        CM_Auro.SetActive(false);
        CM_Hela.SetActive(false);
        CM_ML.SetActive(false);
        CM_AL.SetActive(false);
        CM_HL.SetActive(false);
        isAll = true;
        CM_HB.SetActive(false);
        if (isAll && HelaQuestion.isQH1 && HelaQuestion.isQH2 && MichaQuestion.is1stEnd && MichaQuestion.is2ndEnd && MichaQuestion.is3rdEnd && AuroQuestion.isQA1 && AuroQuestion.isQA2)
        {
            SceneManager.LoadScene("Aurora1");
        }
    }

    public void ABackBTN()
    {
        CM_All.SetActive(true);
        CM_Micha.SetActive(false);
        CM_Auro.SetActive(false);
        CM_Hela.SetActive(false);
        CM_ML.SetActive(false);
        CM_AL.SetActive(false);
        CM_HL.SetActive(false);
        isAll = true;
        CM_HB.SetActive(false);
        if (isAll && HelaQuestion.isQH1 && HelaQuestion.isQH2 && MichaQuestion.is1stEnd && MichaQuestion.is2ndEnd && MichaQuestion.is3rdEnd && AuroQuestion.isQA1 && AuroQuestion.isQA2)
        {
            SceneManager.LoadScene("Aurora1");
        }
    }

    public void HBackBTN()
    {
        CM_All.SetActive(true);
        CM_Micha.SetActive(false);
        CM_Auro.SetActive(false);
        CM_Hela.SetActive(false);
        CM_ML.SetActive(false);
        CM_AL.SetActive(false);
        CM_HL.SetActive(false);
        isAll = true;
        CM_HB.SetActive(false);

        if (isAll && HelaQuestion.isQH1 && HelaQuestion.isQH2 && MichaQuestion.is1stEnd && MichaQuestion.is2ndEnd && MichaQuestion.is3rdEnd && AuroQuestion.isQA1 && AuroQuestion.isQA2)
        {
            SceneManager.LoadScene("Aurora1");
        }
    }

    public void HelaBig()
    {
        CM_All.SetActive(false);
        CM_Micha.SetActive(false);
        CM_Auro.SetActive(false);
        CM_Hela.SetActive(false);
        CM_ML.SetActive(false);
        CM_AL.SetActive(false);
        CM_HL.SetActive(false);
        isAll = false;
        CM_HB.SetActive(true);
    }
}
