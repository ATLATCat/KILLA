using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroController : MonoBehaviour
{
    public GameObject Auro;
    public GameObject Auro_sign;

    CamChange theCam;
    public static bool isAuroNew = true; //������ �ֳĴ� �� 

    private void Start()
    {
        theCam = FindObjectOfType<CamChange>();
    }
    void OnMouseEnter()
    {
        if (CamChange.isAll && isAuroNew)
        {
            Debug.Log("���콺 ����");
            Auro_sign.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        if (CamChange.isAll)
        {
            Debug.Log("���콺 ����");
            Auro_sign.SetActive(false);
        }
    }
    private IEnumerator OnMouseUp()
    {
        if (CamChange.isAll)
        {
            Debug.Log("���ζ� Ŭ��");

            theCam.AuroClose();
            Auro_sign.SetActive(false);
            yield return new WaitForSeconds(2f);
            theCam.AuroQ();
            //hitInfo.transform.GetComponent<InteractionEvent>().GetDialogue()
            //theDM.ShowDialogue(theIE.GetDialogue());
        }
    }
}
