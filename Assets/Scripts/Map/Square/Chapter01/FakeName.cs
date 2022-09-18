using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeName : MonoBehaviour
{ 
    public GameObject ChoiceSystem;
    public GameObject Canvas_Choice;
    public FTT_Test _fft_Test;

    AudioSource audioSource;
    public AudioClip Choice;

    private void Start()
    {
        audioSource = ChoiceSystem.GetComponent<AudioSource>();
    }

    public void Kelsi()
    {
        _fft_Test.StopCoroutine("TeaTime");
        audioSource.clip = Choice;
        audioSource.Play();
        Canvas_Choice.SetActive(false);
 
        _fft_Test.StartCoroutine("Kelsi");
    }

    public void Amiya()
    {
        _fft_Test.StopCoroutine("TeaTime");
        audioSource.clip = Choice;
        audioSource.Play();
        Canvas_Choice.SetActive(false);

        _fft_Test.StartCoroutine("Amiya");
    }
}
