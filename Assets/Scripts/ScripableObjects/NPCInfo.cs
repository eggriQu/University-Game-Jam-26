using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCInfo", menuName = "Scriptable Objects/NPCInfo")]
public class NPCInfo : ScriptableObject
{
    public List<int> indexList;
    public Sprite npcSprite;
}
