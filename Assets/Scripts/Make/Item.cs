using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
[System.Serializable]
public class Item 
{
    public string itemName;
    public Sprite itemImage;

    //������ ��� ���� ���� ��ȯ
    public bool Use()
    {
        return false;
    }
}
*/

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    //public int value;
    public Sprite icon;
}


