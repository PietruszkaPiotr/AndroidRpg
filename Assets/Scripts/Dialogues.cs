﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogues : MonoBehaviour
{
    public static Dialogues Instance { get; set; }
    public GameObject dialoguePanel;
    public string npcName;
    public List<string> dialogueLines = new List<string>();

    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;
    bool trader;

    //Quest
    bool qGiver;
    public bool GotQuest { get; set; }
    public bool Done { get; set; }
    public List<string> bQuestDialogue = new List<string>();
    public string dQuestDialogue;
    public string aQuestDialogue;
    Button questButton;
    int questIndex;

    private void Awake()
    {
        continueButton = dialoguePanel.transform.Find("ButtonField").Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("TextField").Find("TextPanel").Find("TalkText").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("NamePanel").Find("NameText").GetComponent<Text>();
        questButton = dialoguePanel.transform.Find("ButtonField").Find("Quest").GetComponent<Button>();

        continueButton.onClick.AddListener(delegate { ContinueDial(); });
        questButton.onClick.AddListener(delegate { QuestDial(); });
        dialoguePanel.SetActive(false);
        dialogueIndex = 0;
        questIndex = - 1;

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialog(string[] lines, string[] bQuestLines, string dQuestLines, string aQuestLines, string name, bool trader, bool qGiver)
    {
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        bQuestDialogue.AddRange(bQuestLines);
        //dQuestDialogue.AddRange(dQuestLines);
        //aQuestDialogue.AddRange(aQuestLines);
        this.npcName = name;
        this.trader = trader;
        this.qGiver = qGiver;
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialoguePanel.transform.Find("ButtonField").Find("Continue").Find("Text").GetComponent<Text>().text = "Continue";
            dialoguePanel.transform.Find("ButtonField").Find("Shop").GetComponent<Button>().interactable = false;
            dialoguePanel.transform.Find("ButtonField").Find("Quest").GetComponent<Button>().interactable = false;
        }
        else
        {
            if (trader)
                dialoguePanel.transform.Find("ButtonField").Find("Shop").GetComponent<Button>().interactable = true;
            if (qGiver)
                dialoguePanel.transform.Find("ButtonField").Find("Quest").GetComponent<Button>().interactable = true;
        }
        
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDial()
    {
        //if()
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            if (dialogueIndex == dialogueLines.Count - 2)
            {
                dialoguePanel.transform.Find("ButtonField").Find("Continue").Find("Text").GetComponent<Text>().text = "Exit";
                if (trader)
                    dialoguePanel.transform.Find("ButtonField").Find("Shop").GetComponent<Button>().interactable = true;
                if (qGiver)
                    dialoguePanel.transform.Find("ButtonField").Find("Quest").GetComponent<Button>().interactable = true;
            }
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            int count = Shop.instance.items.Count;
            for (int i = 0; i < count; i++)
            {
                Shop.instance.Remove(Shop.instance.items[0]);
            }
            dialoguePanel.SetActive(false);
        }
    }

    public void QuestDial()
    {
        
        dialoguePanel.transform.Find("ButtonField").Find("Quest").Find("Text").GetComponent<Text>().text = "Continue";
        if (questIndex < bQuestDialogue.Count - 1)
        {
            dialoguePanel.transform.Find("ButtonField").Find("Continue").GetComponent<Button>().interactable = false;
            dialoguePanel.transform.Find("ButtonField").Find("Shop").GetComponent<Button>().interactable = false;
            if (questIndex == bQuestDialogue.Count - 2)
            {
                dialoguePanel.transform.Find("ButtonField").Find("Quest").Find("Text").GetComponent<Text>().text = "Exit";
            }
            questIndex++;
            dialogueText.text = bQuestDialogue[questIndex];
        }
        else
        {
            if (trader)
                dialoguePanel.transform.Find("ButtonField").Find("Shop").GetComponent<Button>().interactable = true;

            dialoguePanel.transform.Find("ButtonField").Find("Continue").GetComponent<Button>().interactable = true;
            dialoguePanel.transform.Find("ButtonField").Find("Quest").Find("Text").GetComponent<Text>().text = "Quest";

            int count = Shop.instance.items.Count;
            for (int i = 0; i < count; i++)
            {
                Shop.instance.Remove(Shop.instance.items[0]);
            }
            dialoguePanel.SetActive(false);
        }
    }
    public void UpdateShop(GameObject npc)
    {
        if(!Inventory.instance.wear)
            npc.transform.Find(npcName).GetComponent<NPC>().items = Shop.instance.items.ToArray();
    }
}
