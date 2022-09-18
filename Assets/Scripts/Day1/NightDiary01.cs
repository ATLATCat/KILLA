using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightDiary01 : MonoBehaviour
{
    /* 노트 UI */ 
    public GameObject Image_Circle;
    public GameObject Button_Diary;

    /* 몇일차 & 목차 */
    public GameObject day;
    public GameObject index;

    /* 밤일기 타이틀 내용 */
    public GameObject main;

    /* 목차 1번 내용 */
    public GameObject index1;
    public GameObject index1Content1;
    public GameObject index1Content2;


    /* 목차 2번 내용 */
    public GameObject index2;
    public GameObject index2Panel;
    public GameObject index2ChoiceButton;
    public GameObject index2Positive;
    public GameObject index2Negative;


    /* 목차 3번 내용 */
    public GameObject index3;
    public GameObject index3Panel; 
    public GameObject index3ChoiceButton;
    public GameObject index3Positive;
    public GameObject index3Negative;

    /* 목차 4번 내용 */
    public GameObject index4;
    public GameObject index4Panel;
    public GameObject index4ChoiceButton;
    public GameObject index4Positive;
    public GameObject index4Negative;
    public GameObject index4Content1;
    public GameObject index4Content2;

    /* 선택지 점수 */
    int score;

    /* 선택지 개수 */
    int count;

    /* 느낌표 */
    public GameObject noticeIndex2;
    public GameObject noticeIndex3;
    public GameObject noticeIndex4;

    /* 일기 마치기 */
    public GameObject endDiaryButton;

    /* 천칭 */
    public GameObject chyeonchingPanel;

    /* 천칭 애니메이션 */
    public Animation ChyeonChing;

    /* 컷씬 */
    public GameObject CutScene;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        score = 0;
        count = 0;
        Image_Circle.SetActive(true);
        Button_Diary.SetActive(true);

        day.SetActive(false);
        index.SetActive(false);
        main.SetActive(false);
        index1.SetActive(false);
        index2.SetActive(false);
        index3.SetActive(false);
        index4.SetActive(false);
        endDiaryButton.SetActive(false);
        chyeonchingPanel.SetActive(false);



        yield return  new WaitForSeconds(5f);

        CutScene.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (count >= 3)
        {
            endDiaryButton.SetActive(true);
        }

        getScore(score);

    }

    void getScore(int score)
    {
        int nowScore = score;
    }

    public void clickDiary()
    {
        // 노트의 기본화면 사라짐
        Image_Circle.SetActive(false);
        Button_Diary.SetActive(false);

        Debug.Log("밤 일기 메인 화면");
        day.SetActive(true);
        index.SetActive(true);
        main.SetActive(true);
    }

    // 미카엘라에 대하여
    public void clickIndex1()
    {
        // 메인화면 setActive - false
        main.SetActive(false);

        // 미카엘라에 대하여 setActive - true
        index1.SetActive(true);
        preContentIndex1(); 

        // 오로라에 대하여 setActive - false
        index2.SetActive(false);

        // 희라에 대하여 setActive - false
        index3.SetActive(false);

        // 오로라와의 밀담 setActive - false
        index4.SetActive(false);
    }

    // 오로라에 대하여
    public void clickIndex2()
    {
        // 메인화면 setActive - false
        main.SetActive(false);

        // 미카엘라에 대하여 setActive - false
        index1.SetActive(false);

        // 오로라에 대하여 setActive - true
        index2.SetActive(true);

        // 희라에 대하여 setActive - false
        index3.SetActive(false);

        // 오로라와의 밀담 setActive - false
        index4.SetActive(false);
    }

    // 희라에 대하여
    public void clickIndex3()
    {
        // 메인화면 setActive - false
        main.SetActive(false);

        // 미카엘라에 대하여 setActive - false
        index1.SetActive(false);

        // 오로라에 대하여 setActive - false
        index2.SetActive(false);

        // 희라에 대하여 setActive - true
        index3.SetActive(true);

        // 오로라와의 밀담 setActive - false
        index4.SetActive(false);
    }

    // 오로라와의 밀담
     public void clickIndex4()
     {
        // 메인화면 setActive - false
        main.SetActive(false);

        // 미카엘라에 대하여 setActive - false
        index1.SetActive(false);

        // 오로라에 대하여 setActive - false
        index2.SetActive(false);

        // 희라에 대하여 setActive - false
        index3.SetActive(false);

        // 오로라와의 밀담 setActive - true
        index4.SetActive(true);
        preContentIndex4();
     }



    /* 2번 목차 선택창 */
    public void choiceIndex2()
    {
        index2Panel.SetActive(true);
    }

    public void choiceIndex2Positive()
    {
        index2Panel.SetActive(false);

        // 버튼 사라짐
        index2ChoiceButton.SetActive(false);

        // 내용 추가
        index2Positive.SetActive(true);

        // 긍정 점수
        score++;
        Debug.Log(score);

        // 선택지 개수 
        count++;

        noticeIndex2.SetActive(false);
    }

    public void choiceIndex2Negative()
    {
        index2Panel.SetActive(false);

        // 버튼 사라짐
        index2ChoiceButton.SetActive(false);

        // 내용 추가
        index2Negative.SetActive(true);

        // 부정 점수
        score--;
        Debug.Log(score);

        // 선택지 개수 
        count++;

        noticeIndex2.SetActive(false);
    }




    /* 3번 목차 선택창 */
    public void choiceIndex3()
    {
        index3Panel.SetActive(true);
    }

    public void choiceIndex3Positive()
    {
        index3Panel.SetActive(false);

        // 버튼 사라짐
        index3ChoiceButton.SetActive(false);

        // 내용 추가
        index3Positive.SetActive(true);

        // 긍정 점수
        score++;
        Debug.Log(score);

        // 선택지 개수 
        count++;

        noticeIndex3.SetActive(false);
    }

    public void choiceIndex3Negative()
    {
        index3Panel.SetActive(false);

        // 버튼 사라짐
        index3ChoiceButton.SetActive(false);
        // 내용 추가
        index3Negative.SetActive(true);

        // 부정 점수
        score--;
        Debug.Log(score);

        // 선택지 개수 
        count++;

        noticeIndex3.SetActive(false);
    }




    /* 4번 목차 선택창 */
    public void choiceIndex4()
    {
        index4Panel.SetActive(true);
    }

    public void choiceIndex4Positive()
    {
        index4Panel.SetActive(false);

        // 버튼 사라짐
        index4ChoiceButton.SetActive(false);

        // 내용 추가
        index4Positive.SetActive(true);

        // 긍정 점수
        score++;
        Debug.Log(score);

        // 선택지 개수 
        count++;

        noticeIndex4.SetActive(false);
    }

    public void choiceIndex4Negative()
    {
        index4Panel.SetActive(false);

        // 버튼 사라짐
        index4ChoiceButton.SetActive(false);

        // 내용 추가
        index4Negative.SetActive(true);

        // 부정 점수
        score--;
        Debug.Log(score);

        // 선택지 개수 
        count++;

        noticeIndex4.SetActive(false);
    }




    /* 화살표 */

    // 미카엘라에 대하여
    public void preContentIndex1()
    {
        index1Content1.SetActive(true);
        index1Content2.SetActive(false);
    }

    public void nextContentIndex1()
    {
        index1Content1.SetActive(false);
        index1Content2.SetActive(true);
    }

    // 희라에 대하여
    public void preContentIndex4()
    {
        index4Content1.SetActive(true);
        index4Content2.SetActive(false);
    }

    public void nextContentIndex4()
    {
        index4Content1.SetActive(false);
        index4Content2.SetActive(true);
    }

    /* 일기 마치기 */
    public void endDiary()
    {
        getScore(score);

        chyeonchingPanel.SetActive(true);

        if (score <= 0)
        {
            Debug.Log("부정");
            ChyeonChing.Play("Negative");
            StartCoroutine("nextScene");
        }
        else
        {
            Debug.Log("긍정");
            ChyeonChing.Play("Positive");
            StartCoroutine("nextScene");
        }

        // 천칭 이후에?
    }

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("ValhallaDeath");
    }
}
