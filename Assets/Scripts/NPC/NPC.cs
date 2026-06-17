using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private TextAsset dialogueList;
    private int CurrentDialogue;
    private DialogueTyping DTyping;
    public string[] SplitDialogue;

    private void Awake()
    {
        DTyping = GameObject.Find("Text").GetComponent<DialogueTyping>();
        string text = File.ReadAllText("Assets/Dialogue/Dialogue.txt");
        SplitDialogue = text.Split('-');
    }

    public void Interact()
    {
        //implement check to see which npc player is talking to 
        PlayCurrentDialogue(SplitDialogue[CurrentDialogue]);
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
}
