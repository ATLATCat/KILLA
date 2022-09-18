using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Collect : MonoBehaviour
{
    public GameObject choiceSystem;
    public GameObject NoticeSystem;

    public GameObject effect;
    public Button button;
    Image image;
    public GameObject Herb;
    Animation notiAni;
    bool click;

    // Start is called before the first frame update
    void Start()
    {
        image = button.GetComponent<Image>();
        notiAni = NoticeSystem.GetComponent<Animation>();
        NoticeSystem.SetActive(false);
        effect.SetActive(false);
        button.interactable = false;
        image.raycastTarget = false;
    }

    /*
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            click = true;
        }
        else
        {
            click = false;
        }
    }
    */

    public void collectPoison()
    {
        Debug.Log("���ʸ� ����.");
        choiceSystem.SetActive(true);
    }

    public void collectHerb()
    {
        NoticeSystem.SetActive(true);
        notiAni.Play();
        Destroy(Herb);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            effect.SetActive(true);
            image.raycastTarget = true;
            button.interactable = true;
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            effect.SetActive(false);
            button.interactable = false;
            image.raycastTarget = false;
        }

    }

    /*
    private IEnumerator Dialog()
    {
        // �ؽ�Ʈâ 
   
        // �ʼ� ������Ʈ ���� �� ����
        yield return new WaitUntil(() => DialogSystem.UpdateDialog());

        // ������ Ȱ��ȭ
        choiceSystem.SetActive(true);
    }
    */

  
}
