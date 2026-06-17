using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MushroomGauge : MonoBehaviour
{
    [SerializeField] private RectTransform pivotTransform;
    [SerializeField] private PlayerController player;
    [SerializeField] private TilemapManager tileManager;

    public UnityEvent soberEvent;
    public UnityEvent museumEvent;
    public UnityEvent megadoseEvent;
    public UnityEvent heroicEvent;
    public UnityEvent badTripEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.tripLevel < 360)
        {
            player.tripLevel += Time.deltaTime;
            pivotTransform.Rotate(-Vector3.forward, Time.deltaTime);
        }
        else
        {
            Debug.Log("Trip Level: " + player.tripLevel);
        }
    }

    public void AddToTripLevel()
    {
        player.tripLevel = player.tripLevel + 36;
        pivotTransform.Rotate(-Vector3.forward, 36);
        if (player.tripLevel < 72)
        {
            soberEvent.Invoke();
        }
        else if (player.tripLevel > 72 && player.tripLevel < 144)
        {
            museumEvent.Invoke();
        }
        else if (player.tripLevel > 144 && player.tripLevel < 216)
        {
            megadoseEvent.Invoke();
        }
        else if (player.tripLevel > 216 && player.tripLevel < 288)
        {
            heroicEvent.Invoke();
        }
        else if (player.tripLevel > 288 && player.tripLevel < 360)
        {
            badTripEvent.Invoke();
        }
    }
}
