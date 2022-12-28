using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTutorialTest : MonoBehaviour
{
    // ---- 오프닝 ----
    public Animator openingAnimator;

    // ---- 발할라 ----
    public Animator valhallaAnimator;

    // ---- 버튼 ----
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

        // 인벤토리 시스템
        // 제작 시스템

        /*
        CraftingSystem craftingSystem = new CraftingSystem();
        Item item = new Item { itemType = Item.ItemType.Plant1, amount = 1 };
        craftingSystem.SetItem(item, 0);

        Debug.Log(craftingSystem.GetItem(0));

        //UICraftingSystem.SetCraftingSystem(craftingSystem);
        */


        // 오프닝
        openingAnimator.Play("Opening");
        yield return new WaitForSeconds(3f);

        // 첫번째 대사 분기 시작
        valhallaAnimator.Play("Valhalla");
        yield return new WaitForSeconds(0.9f);

        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());

        // 서랍 버튼 활성화
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
