using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelaController : MonoBehaviour
{
    public GameObject Hela;
    public GameObject Hela_sign;

    CamChange theCam;
    public static bool isHelaNew = true; //새질문 있냐는 뜻 

    private void Start()
    {
        theCam = FindObjectOfType<CamChange>();
    }

    void OnMouseEnter()
    {
        if (CamChange.isAll && isHelaNew)
        {
            Debug.Log("마우스 들어옴");
            Hela_sign.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        if (CamChange.isAll)
        {
            Debug.Log("마우스 나감");
            Hela_sign.SetActive(false);
        }
    }


    private IEnumerator OnMouseUp()
    {
        if (CamChange.isAll)
        {
            Debug.Log("희라 클릭");

            theCam.HelaClose();
            Hela_sign.SetActive(false);
            yield return new WaitForSeconds(2f);
            theCam.HelaQ();
            //hitInfo.transform.GetComponent<InteractionEvent>().GetDialogue()
            //theDM.ShowDialogue(theIE.GetDialogue());
        }
    }
}
