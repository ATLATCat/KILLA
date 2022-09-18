using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspectBar : MonoBehaviour
{
    float fillAmount = 0f;
    float totalTime = 2f;

    public Image gauge;

    IEnumerator suspecting()
    {
        Debug.Log("��ī���� �ǽ��� .." );
        while(gauge.fillAmount <= 0.51f)
        {
            yield return new WaitForSeconds(0.01f);
            fillAmount = fillAmount + (Time.deltaTime / (totalTime + 1));
            gauge.fillAmount = fillAmount;

            if (fillAmount >= 0.51f)
            {
                StopCoroutine("suspecting");
            }
        }

        
    }

    IEnumerator understanding()
    {
        Debug.Log("��ī���� ������ ..");
        while (gauge.fillAmount >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            fillAmount = fillAmount - (Time.deltaTime / (totalTime + 1));
            gauge.fillAmount = fillAmount;

            if (fillAmount <= 0)
            {
                StopCoroutine("understanding");
            }
        }

        yield return null;
    }
}
