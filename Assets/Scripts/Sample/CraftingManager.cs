using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    private ItemList currentItem;
    public Image customCursor;

    public SlotSystem[] craftingSlots;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(currentItem != null)
            {
                SlotSystem nearestSlot = null;
                float shortestDistance = float.MaxValue;

                foreach(SlotSystem slot in craftingSlots)
                {
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);

                    if (dist < shortestDistance)
                    {
                        shortestDistance = dist;
                        nearestSlot = slot;
                    }
                }
                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite =
                    currentItem.GetComponent<Image>().sprite;
                nearestSlot.itemList = currentItem;
                currentItem = null;
            }


        }
    }

    public void OnMouseDownItem(ItemList item)
    {
        if(currentItem == null)
        {
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentItem.GetComponent<Image>().sprite;

        }
    }


}
