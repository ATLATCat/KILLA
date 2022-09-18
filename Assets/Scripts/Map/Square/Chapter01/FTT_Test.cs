using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FTT_Test : MonoBehaviour
{
    [SerializeField]
    private FirstTeaTime DialogSystem01;
    [SerializeField]
    private FirstTeaTime DialogSystem02;
    [SerializeField]
    private FirstTeaTime DialogSystem03;
    [SerializeField]
    private FirstTeaTime DialogSystem04;
    [SerializeField]
    private FirstTeaTime DialogSystem05;
    [SerializeField]
    private FirstTeaTime DialogSystem06;
    [SerializeField]
    private FirstTeaTime DialogSystem07;
    [SerializeField]
    private FirstTeaTime DialogSystem08;
    [SerializeField]
    private FirstTeaTime DialogSystem09;
    [SerializeField]
    private FirstTeaTime DialogSystem10;

    public Camera cam;

    public GameObject TeaCup;

    public GameObject ChoiceSystem;
    public GameObject QuickTextEvent;
    public GameObject SuspectSystem;

    public GameObject Curtain;
    public GameObject L_Curtain;
    public GameObject R_Curtain;

    public GameObject Wheel1;
    public GameObject Wheel2;
    public GameObject Wheel3;

    public GameObject Title;

    public static int nameFlag = 0;

    public SuspectBar suspectBar;

    Animation cup;

    Animator wheel1Ani;
    Animator wheel2Ani;
    Animator wheel3Ani;

    Animator LCurtainAni;
    Animator RCurtainAni;

    AudioSource CupAudioSource;
    AudioSource CurtainAudioSource;

    public AudioClip curtainOpen;
    public AudioClip curtainClose;

    public AudioClip cupSlide;
    public AudioClip cupClear;

    void Start()
    {
        Setup();
        StartCoroutine("TeaTime1");
    }

    public IEnumerator TeaTime1()
    {
        Setup();

        yield return new WaitForSeconds(2f);

        // ���� �ִϸ��̼�
        wheel1Ani.SetBool("isStart", true);
        wheel2Ani.SetBool("isStart", true);
        wheel3Ani.SetBool("isStart", true);

        // Ŀư �ִϸ��̼� ����

        CurtainAudioSource.clip = curtainOpen;
        CurtainAudioSource.Play();

        RCurtainAni.SetBool("isStart", true);
        LCurtainAni.SetBool("isStart", true);

        // Ŀư ����
        RCurtainAni.SetBool("isOpen", true);
        LCurtainAni.SetBool("isOpen", true);

        yield return new WaitForSeconds(2f);

        // Ÿ��Ʋ set active false
        Title.SetActive(false);

        // ù��° ��� �б� ����
        yield return new WaitUntil(() => DialogSystem01.UpdateDialog());

        // Ŀư ����
        CurtainAudioSource.clip = curtainClose;
        CurtainAudioSource.Play();

        LCurtainAni.SetBool("isOpen", false);
        RCurtainAni.SetBool("isOpen", false);

        LCurtainAni.SetBool("isClose", true);
        RCurtainAni.SetBool("isClose", true);

        yield return new WaitForSeconds(2f);

        // ī�޶� ��ŷ (Ȯ��)
        cam.orthographicSize = 3.2f;
        cam.transform.position = new Vector3(1, -1.56f, -10);

        // Ŀư ���� 
        CurtainAudioSource.clip = curtainOpen;
        CurtainAudioSource.Play();

        LCurtainAni.SetBool("isClose", false);
        RCurtainAni.SetBool("isClose", false);

        RCurtainAni.SetBool("isOpen", true);
        LCurtainAni.SetBool("isOpen", true); // idle ����

        yield return new WaitForSeconds(2f);

        // 2��° �б�
        yield return new WaitUntil(() => DialogSystem02.UpdateDialog());

        // ���� ������ �̵�
        CupAudioSource.clip = cupSlide;
        CupAudioSource.Play();
        cup.Play("Cup_Moving");
        yield return new WaitForSeconds(1f);

        // 3��° �б� 
        yield return new WaitUntil(() => DialogSystem03.UpdateDialog());

        // ���Ҷ� ���� ����
        cup.Play("Cup_Drinking");
        yield return new WaitForSeconds(1f);
        CupAudioSource.clip = cupClear;
        CupAudioSource.Play();
        yield return new WaitForSeconds(2f);

        // Ŀư ����
        CurtainAudioSource.clip = curtainClose;
        CurtainAudioSource.Play();

        LCurtainAni.SetBool("isOpen", false);
        RCurtainAni.SetBool("isOpen", false);

        LCurtainAni.SetBool("isClose", true);
        RCurtainAni.SetBool("isClose", true);
        
        yield return new WaitForSeconds(1f);

        cam.orthographicSize = 5f;
        cam.transform.position = new Vector3(0, 0, -10);

        LCurtainAni.SetBool("isClose", false);
        RCurtainAni.SetBool("isClose", false);

        RCurtainAni.SetBool("isOpen", true);
        LCurtainAni.SetBool("isOpen", true); // idle ����

        yield return new WaitForSeconds(1f);

        // 4��° �б� 
        yield return new WaitUntil(() => DialogSystem04.UpdateDialog());

        // ���Ҷ��� ��¥ �̸� ������ 
        ChoiceSystem.SetActive(true);

        // �Է��� ���� ������ ���
    }

    IEnumerator Kelsi()
    {
        yield return new WaitForSeconds(1f);

        yield return new WaitUntil(() => DialogSystem05.UpdateDialog());

        // 7��° �б�
        yield return new WaitUntil(() => DialogSystem07.UpdateDialog());

        // QTE �̺�Ʈ �߻� 
        QuickTextEvent.SetActive(true);     
    }

    IEnumerator Amiya()
    {
        yield return new WaitForSeconds(1f);

        yield return new WaitUntil(() => DialogSystem06.UpdateDialog());

        // 7��° �б�
        yield return new WaitUntil(() => DialogSystem07.UpdateDialog());

        // QTE �̺�Ʈ �߻� 
        QuickTextEvent.SetActive(true);
    }

    public IEnumerator TeaTime1_2()
    {

        yield return new WaitForSeconds(1f);

        // 8��° �б�
        yield return new WaitUntil(() => DialogSystem08.UpdateDialog());

        // �ǽɵ� ���� & ������ ���
        SuspectSystem.SetActive(true);
        suspectBar.StartCoroutine("suspecting");

        yield return new WaitForSeconds(2.5f);

        // 9��° �б�
        yield return new WaitUntil(() => DialogSystem09.UpdateDialog());

        // �ǽɵ� ����� & ������ �ϰ�
        suspectBar.StartCoroutine("understanding");

        yield return new WaitForSeconds(2.5f);
        SuspectSystem.SetActive(false);


        // 10��° �б�
        yield return new WaitUntil(() => DialogSystem10.UpdateDialog());

        // Ŀư ����
        CurtainAudioSource.clip = curtainClose;
        CurtainAudioSource.Play();

        RCurtainAni.SetBool("isOpen", false);
        LCurtainAni.SetBool("isOpen", false);

        yield return new WaitForSeconds(1f);

        // ��ü ������ �̵�
        SceneManager.LoadScene("Map");
    }

    void Setup()
    {
        wheel1Ani = Wheel1.GetComponent<Animator>();
        wheel2Ani = Wheel2.GetComponent<Animator>();
        wheel3Ani = Wheel3.GetComponent<Animator>();

        LCurtainAni = L_Curtain.GetComponent<Animator>();
        RCurtainAni = R_Curtain.GetComponent<Animator>();

        cup = TeaCup.GetComponent<Animation>();

        CupAudioSource = TeaCup.GetComponent<AudioSource>();
        CurtainAudioSource = Curtain.GetComponent<AudioSource>();
    }
}
