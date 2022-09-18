using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aurora1 : MonoBehaviour
{
    /* 오로라 */
    public GameObject Aurora;

    /* 노티 애니메이션 */
    public Animation Ani_Noti;
    public Animation Ani_Aurora;

    /* 배경 애니메이션 */
    public Animation Background;

    /* 대화 시스템 */ 
    public DialogSystem01 DialogSystem1;
    public DialogSystem01 DialogSystem2;
    public DialogSystem01 DialogSystem3; 
    public DialogSystem01 DialogSystem4;

    /* 오디오 소스 */
    public AudioSource audioSourceBGM;

    /* 오디오 클립 */
    public AudioClip aurora_mystery;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        Ani_Noti.Play("Noti_Place");
        yield return new WaitForSeconds(3f);
        
        yield return new WaitUntil(() => DialogSystem1.UpdateDialog());

        // 오로라 등장
        Aurora.SetActive(true);
        Ani_Aurora.Play("Aurora_Come");
        yield return new WaitForSeconds(2f);
        yield return new WaitUntil(() => DialogSystem2.UpdateDialog());

        Ani_Aurora.Play("Aurora_Closer");
        Background.Play("Tree_Moving");
        yield return new WaitForSeconds(2f);

        // 속삭임
        PlayBGM("aurora_mystery");
        yield return new WaitUntil(() => DialogSystem3.UpdateDialog());

        // 속삭임 - 큰 텍스트 박스 
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
