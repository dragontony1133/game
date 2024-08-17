using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public bool menuActivated=false;
    public ItemSlot[] itemSlot;
    public ItemSO[] itemSOs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B) && menuActivated )
        {
            Time.timeScale=1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetKey(KeyCode.B) && !menuActivated)
        {
            
            Time.timeScale=0;
            menuActivated = true;
            InventoryMenu.SetActive(true);
        }
    }
    public void UseItem(string itemName)
    {
        Debug.Log("itemName "+itemName);
        for (int i=0;i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                itemSOs[i].UseItem();
            }
        }
    }

    public void AddItem(string itemName,int quantity,Sprite itemSprite,string itemDescription)
    {
       for ( int i=0; i < itemSlot.Length;i++)
       {
        if (itemSlot[i].isFull == false)
        {
            itemSlot[i].AddItem(itemName,quantity,itemSprite,itemDescription);
            return;
        }
       }
    }

    public void DeselectAllShots()
    {
        for (int i = 0;i < itemSlot.Length; i++ )
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}
