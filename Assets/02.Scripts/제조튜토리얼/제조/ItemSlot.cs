using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        }
    }

}
