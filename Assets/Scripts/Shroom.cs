using UnityEngine;

public class Shroom : MonoBehaviour, IInteractable
{
    private MushroomGauge mGauge;

    public void Interact()
    {
        Consume();
    }

    public void OnNotTouchingPlayer()
    {
        
    }

    public void OnTouchingPlayer()
    {
        
    }

    void Consume()
    {
        mGauge.AddToTripLevel();
        Destroy(gameObject);
    }

    private void Awake()
    {
        mGauge = GameObject.Find("Mushroom Gauge").GetComponent<MushroomGauge>();
    }
}
