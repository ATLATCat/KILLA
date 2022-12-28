using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_Item : MonoBehaviour
{
    private Item item;
    private Image image;

    /*
    public static UI_Item returnUIItem(Item item)
    {
        //UI_Item UIItem = transform.GetComponent<UI_Item>();
        UIItem.SetItem(item);

        //return UI_Item;
    }
    */

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        image.sprite = item.GetSprite();
        image.SetNativeSize();

    }

    public Item GetItem()
    {
        return item;  
    }
}
