using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CraftingManager : MonoBehaviour
{
    private Item currentItem;
    public Image customCursor;

    public Slot[] craftingSlots;

    public List<Item> itemList;
    public string[] recipes;
    public Item[] recipeResults;
    public Slot resultSlot;
    public GameObject box;
    public GameObject Fox;
    public GameObject sox;
    

    
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(currentItem != null)
            {
                customCursor.gameObject.SetActive(false);
                Slot nearestSlot = null;
                float shortestDistance = float.MaxValue;

                foreach(Slot slot in craftingSlots)
                {
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);

                    if(dist < shortestDistance)
                    {
                        shortestDistance = dist;
                        nearestSlot = slot;
                    }
                }
                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currentItem.GetComponent<Image>().sprite;
                nearestSlot.item = currentItem;
                itemList[nearestSlot.index] = currentItem;
                currentItem = null;

                CheckForCreatedRecipes();
            }
        }
    }

    void CheckForCreatedRecipes()
    {
        resultSlot.gameObject.SetActive(false);
        resultSlot.item = null;

        string currentRecipeString = "";
        foreach(Item item in itemList)
        {
           if(item !=  null)
           {
            currentRecipeString += item.itemName;
           }
           else
           {
            currentRecipeString += "null";
           }
        }

        for (int i = 0; i < recipes.Length; i++)
        {
            if(recipes[i] == currentRecipeString)
            {
            
                resultSlot.gameObject.SetActive(true);
                //tin.enabled = true;
                resultSlot.GetComponent<Image>().sprite = recipeResults[i].GetComponent<Image>().sprite;
                resultSlot.item = recipeResults[i];
            }
        }
    }

    public void OnClickSlot(Slot slot )
    {
        
        if(slot.item.name == "frie")
        {
            box.SetActive(true);
        }
        else if(slot.item.name == "leratrer")
        {
            Fox.SetActive(true);
        }
        else if(slot.item.name == "son")
        {
            sox.SetActive(true);
        }
        slot.item = null;
        itemList[slot.index] = null;
        
        slot.gameObject.SetActive(false);
        CheckForCreatedRecipes();
    }

    public void OuMouseDownItem(Item item)
    {
        if(currentItem == null)
        {
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            Debug.Log(item);
            customCursor.sprite = currentItem.GetComponent<Image>().sprite;
            if(item.name == "frie" )
            {
               box.SetActive(false);     
            }
            else if(item.name == "leratrer" )
            {
               Fox.SetActive(false);     
            }
            else if(item.name == "son" )
            {
               sox.SetActive(false);     
            }
            
        }
    }
}
