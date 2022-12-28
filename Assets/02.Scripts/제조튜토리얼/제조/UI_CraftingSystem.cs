using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CraftingSystem : MonoBehaviour
{
    [SerializeField] private Transform pfUI_Item;

    private Transform[] slotTransformArray;
    private Transform outputSlotTransform;
    private Transform itemContainer;
    private CraftingSystem craftingSystem;

    private void Awake()
    {
        Transform gridContainer = transform.Find("GridContainer");
        itemContainer = transform.Find("ItemContainer");

        slotTransformArray = new Transform[CraftingSystem.Array_Size];

        for(int x =0; x< CraftingSystem.Array_Size; x++)
        {
            slotTransformArray[x] = gridContainer.Find("Grid_" + x);
            UI_CraftingItemSlot craftingItemSlot = slotTransformArray[x].GetComponent<UI_CraftingItemSlot>();
            craftingItemSlot.SetX(x);
            slotTransformArray[x].GetComponent<UI_CraftingItemSlot>().OnItemDropped += UI_CraftingSystem_OnItemDropped;
        }

        outputSlotTransform = transform.Find("OutputSlot");

        //CreateItem(0, new Item { itemType = Item.ItemType.Plant1 });
        //CreateItemOutput(new Item { itemType = Item.ItemType.Plant1 });
    }

    public void SetCraftingSystem(CraftingSystem craftingSystem)
    {
        this.craftingSystem = craftingSystem;
        craftingSystem.OnGridChanged += CraftingSystem_OnGridChanged;
        UpdateVisual();
    }

    private void CraftingSystem_OnGridChanged(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void UI_CraftingSystem_OnItemDropped(object sender, UI_CraftingItemSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log(e.item + " " + e.x);
        //craftingSystem.TryAddItem(e.item, e.x);
    }

    private void UpdateVisual()
    {
        foreach(Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }

        for(int x= 0; x < CraftingSystem.Array_Size; x++)
        {
            if (!craftingSystem.IsEmpty(x))
            {
                CreateItem(x, craftingSystem.GetItem(x));
            }

        }
    }

    private void CreateItem(int x, Item item)
    {
        Transform itemTransform = Instantiate(pfUI_Item, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition =
            new Vector2(slotTransformArray[x].GetComponent<RectTransform>().anchoredPosition.x , slotTransformArray[x].GetComponent<RectTransform>().anchoredPosition.y + 45);
        itemTransform.GetComponent<UI_Item>().SetItem(item);
    }

    private void CreateItemOutput(Item item)
    {
        Transform itemTransform = Instantiate(pfUI_Item, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = outputSlotTransform.GetComponent<RectTransform>().anchoredPosition;
        itemTransform.GetComponent<UI_Item>().SetItem(item);
    }
}
