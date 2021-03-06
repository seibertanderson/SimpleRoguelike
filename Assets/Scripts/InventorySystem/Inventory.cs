﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public const int numItemSlots = 5;
    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];

    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            /* se ja possui o item adiciona a quantidade */
            if (items[i] != null && items[i].name == itemToAdd.name)
            {
                items[i].quantidade = items[i].quantidade + 1;
                return;
            }
            else /* se ainda nao tem o item adiciona no slot */
            {
                if (items[i] == null)
                {
                    itemToAdd.quantidade = 1;
                    items[i] = itemToAdd;
                    itemImages[i].sprite = itemToAdd.sprite;
                    itemImages[i].enabled = true;
                    return;
                }
            }
        }
    }
    public void RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }
    public void RemoveItem2(int i)
    {
        items[i] = null;
        itemImages[i].sprite = null;
        itemImages[i].enabled = false;
        return;
    }
}
