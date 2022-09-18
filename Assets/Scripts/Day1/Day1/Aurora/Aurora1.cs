using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aurora1 : MonoBehaviour
{
    /* ���ζ� */
    public GameObject Aurora;

    /* ��Ƽ �ִϸ��̼� */
    public Animation Ani_Noti;
    public Animation Ani_Aurora;

    /* ��� �ִϸ��̼� */
    public Animation Background;

    /* ��ȭ �ý��� */ 
    public DialogSystem01 DialogSystem1;
    public DialogSystem01 DialogSystem2;
    public DialogSystem01 DialogSystem3; 
    public DialogSystem01 DialogSystem4;

    /* ����� �ҽ� */
    public AudioSource audioSourceBGM;

    /* ����� Ŭ�� */
    public AudioClip aurora_mystery;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        Ani_Noti.Play("Noti_Place");
        yield return new WaitForSeconds(3f);
        
        yield return new WaitUntil(() => DialogSystem1.UpdateDialog());

        // ���ζ� ����
        Aurora.SetActive(true);
        Ani_Aurora.Play("Aurora_Come");
        yield return new WaitForSeconds(2f);
        yield return new WaitUntil(() => DialogSystem2.UpdateDialog());

        Ani_Aurora.Play("Aurora_Closer");
        Background.Play("Tree_Moving");
        yield return new WaitForSeconds(2f);

        // �ӻ���
        PlayBGM("aurora_mystery");
        yield return new WaitUntil(() => DialogSystem3.UpdateDialog());

        // �ӻ��� - ū �ؽ�Ʈ �ڽ� 
        yield return new WaitUntil(() => DialogSystem4.UpdateDialog());
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("NightDiary01");
    }

    void PlayBGM(string action)
    {
        switch (action)
        {
            case "aurora_mystery":
                audioSourceBGM.clip = aurora_mystery;
                break;
        }

        audioSourceBGM.Play();

    }
}
