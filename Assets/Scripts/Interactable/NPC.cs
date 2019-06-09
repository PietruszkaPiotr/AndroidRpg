using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] lines;
    public string npcName;

    public override void Interact()
    {
        Dialogues.Instance.AddNewDialog(lines, npcName);
        base.Interact();
    }
}
