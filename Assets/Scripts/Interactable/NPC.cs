using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] lines;
    public string[] bQuestLines;
    public string dQuestLines;
    public string aQuestLines;
    public string npcName;
    public bool qGiver;
    public bool trader;
    public Item[] items;

    public override void Interact()
    {
        Dialogues.Instance.AddNewDialog(lines, bQuestLines, dQuestLines, aQuestLines, npcName, trader, qGiver);
        if (trader)
        {
            foreach (Item item in items)
            {
                Shop.instance.Add(item);
            }
        }
        base.Interact();
    }
}
