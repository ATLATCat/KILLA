using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Item
{
    int index;
    string name;
    Sprite image;

    public Item(int _index, string _name, Sprite _image)
    {
        this.index = _index;
        this.name = _name;
        this.image = _image;
    }

    public void Show()
    {
        Debug.Log(this.index);
        Debug.Log(this.name);
        Debug.Log(this.image);
    }
}
*/

public class DicTest : MonoBehaviour
{
    //Item item = new Item();
    Dictionary<int, Item> itemMap;


    // Start is called before the first frame update
    void Start()
    {
        itemMap = new Dictionary<int, Item>();
        string name;
        //아이템 추가
        name = "이슬초";
        //itemMap.Add(name, new Item(1, name, lily)); //sprtie?

        
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
