using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCard : MonoBehaviour
{
    //private Object thisObject;
    private int startingCards = 0;
    public float currentCards;
    private int card = 1;
    [HideInInspector] public int maxCards = 52;

    private void Start()
    {
        currentCards = startingCards;
    }




    public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Card"))
            {
                currentCards = currentCards + card;
                Destroy(collision.gameObject);


            }

        } 
}
