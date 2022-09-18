using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public static float moveSpeed;
    public Camera cam;
    public GameObject player;
    public GameObject choiceSystem;

    // public static int flag;
    public static bool move;

    AudioSource audioSource;
    Animation camAni;
    Animator animator;
    Vector3 inputPos;
    Vector2 dir;
    Rigidbody2D rigid2D;
    float dis;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        camAni = cam.GetComponent<Animation>();
        animator = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
        move = true;
        moveSpeed = 5f;
        //flag = 0; // choice canvas active - false
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (move)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!IsPointerOverUIObject(Input.mousePosition))
                {
                    audioSource.Play();
                    inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
                

            dis = player.transform.position.x - inputPos.x;
            dir = inputPos - player.transform.position;


            //if(dir!= Vector2.zero)
            //rigid2D.MovePosition(player.transform.position + inputPos * Time.deltaTime * moveSpeed);
            player.transform.position =
              Vector2.MoveTowards(player.transform.position, inputPos, Time.deltaTime * moveSpeed);

           
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!IsPointerOverUIObject(Input.mousePosition))
                {
                    move = true;
                    audioSource.Play();
                    inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
        }

        // animation
        // dis = ���� ĳ���� x��ǥ - ���콺 ��ǲ x��ǥ
        // dis > 0�� ���� ��ǲ�� ĳ���ͺ��� ���� -> left
        // dis < 0�� ���� ��ǲ�� ĳ���ͺ��� ������ -> right
        animator.SetFloat("hAxis", dis);

        if (dis == 0)
        {
            animator.SetBool("Stay", true);
            audioSource.Stop();
        }
        else
            animator.SetBool("Stay", false);
    }

    // �浹 ó��
    void OnTriggerEnter2D(Collider2D collision)
    {
        /* �浹 �� ä�� 
        // ���� ä��
        if (collision.tag == "Herb")
        {
            Debug.Log("�浹 ����");
            choiceSystem.SetActive(true);
            flag = 1;
        }
        */ 

        // ī�޶� �̵�
        if (collision.tag == "Portal_L")
        {
            if (collision.transform.name == "Portal_L")
            {
                Debug.Log("�浹����, ���� �̵�");
                camAni.Play("Left");
                move = false;
                player.transform.position = new Vector3(-12.42f, 0, 0); // ���� �Ϸ�
            }

            if (collision.transform.name == "Portal_L_2")
            {
                Debug.Log("�浹����, ������ �̵�");
                camAni.Play("Left_2");
                move = false;
                player.transform.position = new Vector3(6.9f, 0, 0); // ���� �Ϸ�
            }            
        }

        if (collision.tag == "Portal_R")
        {
            if (collision.transform.name == "Portal_R_2")
            {
                Debug.Log("�浹����, ������ �̵�");
                camAni.Play("Right_2");
                move = false;
                player.transform.position = new Vector3(-6.8f, 0, 0); // ���� �Ϸ�
            }

            if (collision.transform.name == "Portal_R")
            {
                Debug.Log("�浹����, ������ �̵�");
                camAni.Play("Right");
                move = false;
                player.transform.position = new Vector3(12.5f, 0, 0); // ���� �Ϸ�
            }

        }

        if (collision.tag == "Portal_U")
        {
            if (collision.transform.name == "Portal_U_2") // �Ʒ����� �߾�
            {
                Debug.Log("�浹����, ���� �̵�");
                camAni.Play("Up_2");
                move = false;
                player.transform.position = new Vector3(0, -2.5f, 0); // ���� �Ϸ�
            }

            if (collision.transform.name == "Portal_U") // �߾ӿ��� ��
            {
                Debug.Log("�浹����, ���� �̵�");
                camAni.Play("Up");
                move = false;
                player.transform.position = new Vector3(0, 8.9f, 0); // ���� �Ϸ�
            }

        }

        if (collision.tag == "Portal_D")
        {
            if (collision.transform.name == "Portal_D")
            {
                Debug.Log("�浹����, �Ʒ��� �̵�");
                camAni.Play("Down");
                move = false;
                player.transform.position = new Vector3(0, -8.9f, 0); // ���� �Ϸ�
            }

            if (collision.transform.name == "Portal_D_2")
            {
                Debug.Log("�浹����, �Ʒ��� �̵�");
                camAni.Play("Down_2");
                move = false;   
                player.transform.position = new Vector3(0, 2.6f, 0); // ���� �Ϸ�
            }
        }
    }

    public bool IsPointerOverUIObject(Vector2 touchPos)
    {
        PointerEventData eventDataCurrentPosition
            = new PointerEventData(EventSystem.current);

        eventDataCurrentPosition.position = touchPos;

        List<RaycastResult> results = new List<RaycastResult>();


        EventSystem.current
        .RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
}