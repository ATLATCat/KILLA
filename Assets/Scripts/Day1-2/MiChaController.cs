using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiChaController : MonoBehaviour
{
    public GameObject Micha;
    public GameObject Micha_sign;
    //public CamChange theCam = new theCam();
    //public GameObject theCam;
    DialogueManager theDM;
    InteractionEvent theIE;
    CamChange theCam;

    public static bool isMichaNew = true; //������ �ֳĴ� �� 
    private void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theIE = FindObjectOfType<InteractionEvent>();
        theCam = FindObjectOfType<CamChange>();
    }

    void OnMouseEnter()
    {
        //CamChange.isAll && TeaCoffeeManager.isBuried
        if (CamChange.isAll && isMichaNew)
        {
            Debug.Log("���콺 ����");
            Micha_sign.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        if (CamChange.isAll)
        {
            Debug.Log("���콺 ����");
            Micha_sign.SetActive(false);
        }
    }

    private IEnumerator OnMouseUp()
    {
        if (CamChange.isAll)
        {
            Debug.Log("��ī���� Ŭ��");

            theCam.MichaClose();
            Micha_sign.SetActive(false);
            yield return new WaitForSeconds(2f);
            theCam.MichaQ();


            //hitInfo.transform.GetComponent<InteractionEvent>().GetDialogue()
            //theDM.ShowDialogue(theIE.GetDialogue());
        }
    }
}
