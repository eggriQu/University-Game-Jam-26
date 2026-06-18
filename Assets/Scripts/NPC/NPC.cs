using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private TextAsset dialogueList;
    [SerializeField] private int CurrentDialogue;
    [SerializeField] private int dialogueIndex;
    private DialogueTyping DTyping;
    public string[] SplitDialogue;
    [SerializeField] private NPCInfo soberInfo;
    [SerializeField] private NPCInfo highInfo;
    [SerializeField] private NPCInfo chosenInfo;
    [SerializeField] private GameObject dialogueBox;

    private void Awake()
    {
        DTyping = GameObject.Find("Dialogue Text").GetComponent<DialogueTyping>();
        string text = File.ReadAllText("Assets/Dialogue/Dialogue.txt");
        SplitDialogue = text.Split('-');
        dialogueIndex = chosenInfo.indexList[0];
    }

    public void Interact()
    {
        Image image = dialogueBox.GetComponent<Image>();
        Image npcImage = GameObject.Find("NPC Portrait").GetComponent<Image>();
        Text text = dialogueBox.GetComponentInChildren<Text>();
        if (dialogueIndex >= chosenInfo.indexList.Count)
        {
            image.enabled = false;
            npcImage.enabled = false;
            text.enabled = false;
            //dialogueIndex = chosenInfo.indexList[0];
            dialogueIndex = 0;
            CurrentDialogue = chosenInfo.indexList[dialogueIndex];
        }
        else
        {
            image.enabled = true;
            npcImage.enabled = true;
            text.enabled = true;
            CurrentDialogue = chosenInfo.indexList[dialogueIndex];
            CorrelateTextAlignment(CurrentDialogue, text);
            dialogueIndex++;
            PlayCurrentDialogue(SplitDialogue[CurrentDialogue]);
        }
    }

    public void OnNotTouchingPlayer()
    {

    }

    public void OnTouchingPlayer()
    {

    }

    private void PlayCurrentDialogue(string CD)
    {
        DTyping.PlayDialogue(CD);
    }

    public void ChangeNPCInfo(bool high)
    {
        if (high)
        {
            chosenInfo = highInfo;
        }
        else
        {
            chosenInfo = soberInfo;
        }
        dialogueIndex = 0;
    }

    void CorrelateTextAlignment(int index, Text text)
    {
        if (index == 2 || index == 5 || index == 7 || index == 10 || index == 12 ||
            index == 81 || index == 85 || index == 86 || index == 88)
        {
            text.alignment = TextAnchor.UpperRight;
        }
        else
        {
            text.alignment = TextAnchor.UpperLeft;
        }
    }
}
