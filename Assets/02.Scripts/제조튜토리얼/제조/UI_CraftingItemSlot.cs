using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class UI_CraftingItemSlot : MonoBehaviour,IDropHandler
{
    private int x;

    public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;
    public class OnItemDroppedEventArgs : EventArgs
    {
        public Item item;
        public int x;
    }

    public void OnDrop(PointerEventData eventData)
    {
        UI_ItemDrag.Instance.Hide();
        Item item = UI_ItemDrag.Instance.GetItem();
        Debug.Log(item);
        OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs { item = item, x = x });
    }
    
    public void SetX(int x)
    {
        this.x = x;

    }
}
