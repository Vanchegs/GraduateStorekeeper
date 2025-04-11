using System;
using System.Collections.Generic;
using Internal.Codebase;
using Internal.Codebase.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private List<Image> images;
    [SerializeField] private PlayerComponent playerInventory;
    [SerializeField] private ProductSpritesStorage spritesStorage;

    private void OnEnable() => 
        GameEventBus.UpdateInventoryDisplay += DisplayOrder;

    private void OnDisable() => 
        GameEventBus.UpdateInventoryDisplay -= DisplayOrder;

    public void DisplayOrder()
    {
        var inventoryList = playerInventory.Inventory.GetInventory();
        
        if (inventoryList != null)
        {
            for (int i = 0; i < images.Count; i++) 
            { 
                if (i < inventoryList.Count && inventoryList[i] != null) 
                { 
                    images[i].gameObject.SetActive(true); 
                    inventoryList[i].SetProductSprites(spritesStorage); 
                    //images[i].sprite = products[i].ProductSprite;
                    images[i].preserveAspect = true;
                }
                else 
                { 
                    images[i].gameObject.SetActive(false);
                }
            }
        }
    }

}
