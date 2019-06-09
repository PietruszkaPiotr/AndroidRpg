﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] lines;
    public string npcName;
    public bool qGiver;
    public bool trader;
    public Item[] items;


    public override void Interact()
    {
        Dialogues.Instance.AddNewDialog(lines, npcName, trader, qGiver);
        if (trader)
        {
            foreach (Item item in items)
            {
                bool added = Shop.instance.Add(item);
                if (added) Debug.Log("Item added to shop");
            }
        }
        base.Interact();
    }
}
