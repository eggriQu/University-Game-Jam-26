using UnityEngine;
using UnityEngine.UI;

public class MushroomGauge : MonoBehaviour
{
    [SerializeField] private RectTransform pivotTransform;
    [SerializeField] private PlayerController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
}
