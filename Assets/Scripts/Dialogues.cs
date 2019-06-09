using System.Collections;
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
    bool qGiver;

    private void Awake()
    {
        continueButton = dialoguePanel.transform.Find("ButtonField").Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("TextField").Find("TextPanel").Find("TalkText").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("NamePanel").Find("NameText").GetComponent<Text>();

        continueButton.onClick.AddListener(delegate { ContinueDial(); });
        dialoguePanel.SetActive(false);

        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialog(string[] lines, string name, bool trader, bool qGiver)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = name;
        this.trader = trader;
        this.qGiver = qGiver;
        dialoguePanel.transform.Find("ButtonField").Find("Continue").Find("Text").GetComponent<Text>().text = "Continue";
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialoguePanel.transform.Find("ButtonField").Find("Quest").GetComponent<Button>().interactable = false;
        dialoguePanel.transform.Find("ButtonField").Find("Shop").GetComponent<Button>().interactable = false;
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDial()
    {
        if(dialogueIndex < dialogueLines.Count-1)
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
            dialoguePanel.SetActive(false);

        }
    }
}
