using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levelTiles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTilemap(int index)
    {
        for (int i = 0; i < levelTiles.Count; i++)
        {
            if (levelTiles[i] != levelTiles[index])
            {
                levelTiles[i].SetActive(false);
            }
            else if (levelTiles[i] == levelTiles[index])
            {
                levelTiles[i].SetActive(true);
            }
        }
    }
}
