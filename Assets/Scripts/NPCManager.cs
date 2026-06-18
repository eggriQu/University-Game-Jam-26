using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    public string[] dialogueList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ChangeIndexLists();
        string text = File.ReadAllText("Assets/Dialogue/Dialogue.txt");
        dialogueList = text.Split('-');
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeIndexLists()
    {
        GameObject[] NPCList = GameObject.FindGameObjectsWithTag("NPC");
        for (int i = 0; i < NPCList.Length; i++)
        {
            if (player.tripLevel < 72)
            {
                NPCList[i].GetComponent<NPC>().ChangeNPCInfo(false);
            }
            else
            {
                NPCList[i].GetComponent<NPC>().ChangeNPCInfo(true);
            }
        }
    }
}
