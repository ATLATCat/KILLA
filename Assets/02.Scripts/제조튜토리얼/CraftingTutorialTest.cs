using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTutorialTest : MonoBehaviour
{
    // ---- ������ ----
    public Animator openingAnimator;

    // ---- ���Ҷ� ----
    public Animator valhallaAnimator;

    // ---- ��ư ----
    public Button buttonDrawer;

    
    //private Inventory inventory;
    //[SerializeField] private UI_Inventory UIInventory;
    
    [SerializeField] private DialogSystem dialogSystem01;
    [SerializeField] private DialogSystem dialogSystem02;
    [SerializeField] private DialogSystem dialogSystem03;
    [SerializeField] private DialogSystem dialogSystem04;
    [SerializeField] private DialogSystem dialogSystem05;
    [SerializeField] private DialogSystem dialogSystem06;

    static public bool isClickedButton = false;

    /*
    private void Awake()
    {
        //inventory = new Inventory();
        //UIInventory.SetInventory(inventory);
    }
    */
    private IEnumerator Start()
    {
        buttonDrawer.interactable = false;

        // �κ��丮 �ý���
        // ���� �ý���

        /*
        CraftingSystem craftingSystem = new CraftingSystem();
        Item item = new Item { itemType = Item.ItemType.Plant1, amount = 1 };
        craftingSystem.SetItem(item, 0);

        Debug.Log(craftingSystem.GetItem(0));

        //UICraftingSystem.SetCraftingSystem(craftingSystem);
        */


        // ������
        openingAnimator.Play("Opening");
        yield return new WaitForSeconds(3f);

        // ù��° ��� �б� ����
        valhallaAnimator.Play("Valhalla");
        yield return new WaitForSeconds(0.9f);

        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());

        // ���� ��ư Ȱ��ȭ
        buttonDrawer.interactable = true; 


        
    }

    private IEnumerator SecondBranch()
    {
        yield return new WaitUntil(() => dialogSystem02.UpdateDialog());
    }

    private IEnumerator ThirdBranch()
    {
        yield return new WaitUntil(() => dialogSystem03.UpdateDialog());
    }

    private IEnumerator FourthBranch()
    {
        yield return new WaitUntil(() => dialogSystem04.UpdateDialog());
    }

    private IEnumerator FifthBranch()
    {
        yield return new WaitUntil(() => dialogSystem05.UpdateDialog());
    }

    private IEnumerator SixthBranch()
    {
        yield return new WaitUntil(() => dialogSystem06.UpdateDialog());
    }

}
