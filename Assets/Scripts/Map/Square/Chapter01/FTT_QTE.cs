using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FTT_QTE : MonoBehaviour
{
    public Image image_L;
    public Image image_R;
    public FTT_Test _fft_Test;
    

    float fillAmount = 0f;
    float totalTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        image_L.fillAmount = 0;
        image_R.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (fillAmount >= 0)
        {
            Debug.Log("시간 가는중..");
            fillAmount = fillAmount + (Time.deltaTime / (totalTime + 1));
            image_L.fillAmount = fillAmount;
            image_R.fillAmount = fillAmount;
        }

        if(image_L.fillAmount >= 1 && image_R.fillAmount >= 1)
        {
            _fft_Test.QuickTextEvent.SetActive(false);
            _fft_Test.StartCoroutine("TeaTime1_2");

        }
    }

}
