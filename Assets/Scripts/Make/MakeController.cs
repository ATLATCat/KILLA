using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//여기서 말하는 아이템은 make의 재료가 되는 약초 입니다

//FieldItems 스크립트의 응용
public class MakeController : MonoBehaviour
{
    public GameObject EndBlackBox;
    public GameObject EndBlackBox2;

    public GameObject Making_IMG1;
    public GameObject Making_IMG2;
    public GameObject Making_IMG3;

    public GameObject madecassol;

    //개수를 나타내는 텍스트
    private Text lily;
    private Text stock; //스토크라는 꽃 이름 입니다(우리말: 비단향꽃무)
    private Text Medecine_Name;
    public int numlily;
    public int numstock;

    //이미지
    //말풍선용
    public Sprite lily_img;
    public Sprite stock_img;
    public Sprite serve_img; //제공 손바닥 
    public Sprite play_img; //화살표
    public Sprite lily_making_img;
    public Sprite stock_making_img;

    public GameObject Buttonlily;
    public GameObject Buttonstock;

    private int numClick=0; //몇번째 아이템 선택인지

    bool serve;//false일때는 아이템 만드는 함수, true가 되면 제공하는 기능

    //!!!여기서부터 수정한 것!!!
    public int index_lily = 2;
    public int index_stock = 3;
    public int temp = 1;
    //굳이 필요없을듯?
    public int ans = 1;
    int[] medicine_name = new int[3]{ 8, 27,0 }; 

    //public GameObject logImage1;

    private void Start()
    {
        //sgm 빌드 때문에 추가
        Buttonstock.GetComponent<Button>().interactable = false;

        lily = GameObject.Find("Material_Name_Lily").GetComponent<Text>();
        stock = GameObject.Find("Material_Name_Stock").GetComponent<Text>();

        Medecine_Name = GameObject.Find("Make_CompletionName").GetComponent<Text>();

        numlily = 9;
        numstock = 9;
        lily.text = numlily.ToString() + "개";
        stock.text = numlily.ToString() + "개";

        serve = false;
    }

    void Update()
    {
        

    }

    public void Onclicklily()
    {
        //몇번째 선택인지 변수 증가
        numClick++;
        //아이템 수량 변수 감소, 텍스트 반영
        numlily -= 1;
        lily.text = numlily.ToString() + "개";

        if (numClick == 1)
        {
            GameObject.Find("InMaterial_LogImage1").GetComponent<logImage1>().Change_lily();
        }
        else if (numClick == 2)
        {
            GameObject.Find("InMaterial_LogImage2").GetComponent<logImage1>().Change_lily();
        }
        else if (numClick == 3)
        {
            GameObject.Find("InMaterial_LogImage3").GetComponent<logImage1>().Change_lily();
            choiceEnd();
        }

        //!!!여기서부터 신 코드!!!
        temp *= index_lily;
    }

    public void Onclickstock()
    {
        numClick++;
        numstock -= 1;
        stock.text = numstock.ToString() + "개";

        if (numClick == 1)
        {
            GameObject.Find("InMaterial_LogImage1").GetComponent<logImage1>().Change_stock();
        }
        else if (numClick == 2)
        {
            GameObject.Find("InMaterial_LogImage2").GetComponent<logImage1>().Change_stock();
        }
        else if (numClick == 3)
        {
            GameObject.Find("InMaterial_LogImage3").GetComponent<logImage1>().Change_stock();
            choiceEnd();
        }
        temp *= index_stock;
    }
    
    //3번 눌러서 선택 끝났을때
    public void choiceEnd()
    {
        GameObject PlayButton = GameObject.Find("Play_Button");

        //개선할 부분: 버튼에 숫자로 태그해서 반복문 돌리기
        Buttonlily.GetComponent<Button>().interactable = false;
        Buttonstock.GetComponent<Button>().interactable = false;
            
        PlayButton.GetComponent<Button>().interactable = true;     
    }

    public void OnclickRetry()
    {
        //전부 초기화
        GameObject PlayButton = GameObject.Find("Play_Button");
        Buttonlily.GetComponent<Button>().interactable = true;
        //Buttonstock.GetComponent<Button>().interactable = true;

        PlayButton.GetComponent<Image>().sprite = play_img;
        PlayButton.GetComponent<Button>().interactable = false;

        numClick = 0;
        numlily = 9;
        numstock = 9;
        lily.text = numlily.ToString() + "개";
        stock.text = numlily.ToString() + "개";

        GameObject.Find("InMaterial_LogImage1").GetComponent<logImage1>().Change_Retry();
        GameObject.Find("InMaterial_LogImage2").GetComponent<logImage1>().Change_Retry();
        GameObject.Find("InMaterial_LogImage3").GetComponent<logImage1>().Change_Retry();

        serve = false;
        temp = 1;

        EndBlackBox.SetActive(false);
    }

    public void OnclickPlay()
    {
        //false일때는 아이템 만드는 함수, true가 되면 제공하는 기능
        if (serve == false)
        {
            GameObject PlayButton = GameObject.Find("Play_Button");
            PlayButton.GetComponent<Button>().interactable = false;

            EndBlackBox.SetActive(true);
            serve = true;
            StartCoroutine(EndAnimate());
            
        }
        else if(serve == true)
        {
            //제공하는 씬 호출
            SceneManager.LoadScene("Day1-2");
        }
    }

    //어떤 약초인지 판단
    private IEnumerator EndAnimate()
    {
        yield return new WaitForSeconds(1f);
        //calculate();
        if (temp == 8)
        {
            StartCoroutine(LilyEnd());       
        }
        else if (temp == 27)
        {
            StartCoroutine(StockEnd());
        }
        temp = 1;
    }

    private IEnumerator LilyEnd()
    {
        Making_IMG1.GetComponent<Image>().sprite = lily_making_img;
        Making_IMG2.GetComponent<Image>().sprite = lily_making_img;
        Making_IMG3.GetComponent<Image>().sprite = lily_making_img;

        yield return new WaitForSeconds(1f);
        Making_IMG1.SetActive(true);
        yield return new WaitForSeconds(1f);
        Making_IMG2.SetActive(true);
        yield return new WaitForSeconds(1f);
        Making_IMG3.SetActive(true);

        yield return new WaitForSeconds(2f);
        Making_IMG1.SetActive(false);
        Making_IMG2.SetActive(false);
        Making_IMG3.SetActive(false);

        EndBlackBox2.SetActive(true);

        GameObject PlayButton = GameObject.Find("Play_Button");
        PlayButton.GetComponent<Image>().sprite = serve_img;
        PlayButton.GetComponent<Button>().interactable = true;
        Medecine_Name.text = "~마데카솔~";
        madecassol.SetActive(true);
        Debug.Log("lilyend");
    }

    private IEnumerator StockEnd()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("stockend");
    }


   
    /*
    public void calculate()
    {
        if (numClick == 3)
        {
            //for문 돌려서 list 속에서 해당하는 값 찾기
            for (int i = 0; i < medicine_name.Length; i++)
            {
                if (medicine_name[i] == temp)
                {
                    ans = i; 
                }
            }

        }
    }
    */
}