using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public int slotIndex;
    public Inventory playerInventory;
    private int indexTxtQtde = 1;

    private Image clickedItemImg;
    //private static Item clickedItem;
    private Vector2 slotOriginalPosition;


    // Use this for initialization
    void Start()
    {
        if (playerInventory.items[slotIndex] == null)
        {
            transform.GetChild(indexTxtQtde).GetComponent<Text>().text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInventory.items[slotIndex] != null)
        {
            transform.GetChild(indexTxtQtde).GetComponent<Text>().text = "" + playerInventory.items[slotIndex].quantidade;
        }
        else
        {
            transform.GetChild(indexTxtQtde).GetComponent<Text>().text = "";
        }

        if (clickedItemImg != null)
        {
            clickedItemImg.transform.position = Input.mousePosition;
        }

        if (Input.GetMouseButtonDown(1) && clickedItemImg != null)
        {
            //playerInventory.itemImages[slotIndex] = clickedItemImg;
            playerInventory.itemImages[slotIndex].transform.position = slotOriginalPosition;
            clickedItemImg = null;
            //clickedItem = null;
            //slotOriginalPosition = Vector2.zero;
        }
    }

    /* Ação quando é clicado no slot do inventario */
    public void SlotClick()
    {
        if (playerInventory.items[slotIndex] != null)
        {
            slotOriginalPosition = playerInventory.itemImages[slotIndex].transform.position;
            clickedItemImg = playerInventory.itemImages[slotIndex];
            //clickedItem = playerInventory.items[slotIndex];
        }
        //else if (clickedItemImg != null && playerInventory.items[slotIndex] != null)
        //{
        //    playerInventory.itemImages[slotIndex] = clickedItemImg;
        //    playerInventory.items[slotIndex] = clickedItem;
        //    clickedItem = null;
        //    clickedItemImg = null;
        //}
    }
}
