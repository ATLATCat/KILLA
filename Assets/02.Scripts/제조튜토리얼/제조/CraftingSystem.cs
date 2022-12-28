using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem
{
    public const int Array_Size = 2;
    private Item[] itemArray;

    public event EventHandler OnGridChanged;

    public CraftingSystem()
    {
        itemArray = new Item[Array_Size];
    }

    public bool IsEmpty(int x)
    {
        return itemArray[x] == null;

    }

    public Item GetItem(int x)
    {
        return itemArray[x];
    }

    public void SetItem(Item item, int x)
    {
        itemArray[x] = item;
        OnGridChanged?.Invoke(this, EventArgs.Empty);
    }

    public void IncreaseItemAmount(int x)
    {
        GetItem(x).amount++;
        OnGridChanged?.Invoke(this, EventArgs.Empty);
    }
    public void DecreaseItemAmount(int x)
    {
        GetItem(x).amount--;
        OnGridChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(int x)
    {
        SetItem(null, x);
    }

    public bool TryAddItem(Item item, int x)
    {
        if (IsEmpty(x))
        {
            SetItem(item, x);
            return true;
        }
        else
        {
            if(item.itemType == GetItem(x).itemType)
            {
                IncreaseItemAmount(x);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
