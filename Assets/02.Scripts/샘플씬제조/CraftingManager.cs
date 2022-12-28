using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    private Plant currentPlant;
    public Image customCursor;

    public Slot[] craftingSlots;

    public List<Plant> plantList;
    public string[] recipes;
    public Plant[] recipeResults;
    public GameObject tool;
   // public Slot resultSlot;

    public CraftingTutorialTest GameManager;
    private bool isFirst = true;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(currentPlant != null)
            {
                customCursor.gameObject.SetActive(false);
                Slot nearestSlot = null;
                float shortestDistance = float.MaxValue;

                foreach(Slot slot in craftingSlots)
                {
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);

                    if (dist < shortestDistance)
                    {
                        shortestDistance = dist;
                        nearestSlot = slot;

                    }
                }

                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currentPlant.GetComponent<Image>().sprite;
                nearestSlot.plant = currentPlant;
                nearestSlot.GetComponent<Image>().SetNativeSize();
                nearestSlot.isNotNull = true;
                Debug.Log(isFirst);
                plantList[nearestSlot.index] = currentPlant;
                CheckForSlotNull(nearestSlot.isNotNull);

               

                currentPlant = null;
                CheckForCreateRecipes();
            }
        }        
    }

    void CheckForSlotNull(bool isNotNull)
    {
        if (isNotNull) // slot에 아이템 존재
        {
            
            if (isFirst)
            {
                Debug.Log("세번째 분기 시작");
                GameManager.StartCoroutine("ThirdBranch");
                isFirst = false;
            }
        }
    }

    void CheckForCreateRecipes()
    {

        tool.gameObject.SetActive(false);

        string currentRecipeString = "";

        foreach(Plant plant in plantList)
        {
            if(plant != null)
            {
                currentRecipeString += plant.plantName;
            }
            else
            {
                currentRecipeString += "null";
            }
        }

        for(int i = 0; i < recipes.Length; i++)
        {
            if(recipes[i] == currentRecipeString)
            {
                // 결과창
                tool.gameObject.SetActive(true);
                GameManager.StartCoroutine("FourthBranch");

                /*
                resultSlot.GetComponent<Image>().sprite = 
                    recipeResults[i].GetComponent<Image>().sprite;
                resultSlot.GetComponent<Image>().SetNativeSize();
                resultSlot.plant = recipeResults[i];
                */
            }
        }
    }

    public void OnClickSlot(Slot slot)
    {
        slot.plant = null;
        plantList[slot.index] = null;
        slot.gameObject.SetActive(false);
        CheckForCreateRecipes();
    }

    public void OnMouseDownItem(Plant plant)
    {
        if(currentPlant == null)
        {
            currentPlant = plant;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentPlant.GetComponent<Image>().sprite;
            customCursor.SetNativeSize();
        }
    }
}
