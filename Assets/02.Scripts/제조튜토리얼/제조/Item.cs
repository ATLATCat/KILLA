using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Plant1
    }

    public ItemType itemType;
    public int amount;

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType Plant1:
                return true;
        }
    }

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Plant1: return ItemAssets.Instance.Plant1;
        }
    }
}
