using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_heatlh : MonoBehaviour
{
    public Playermove player;

    void Start()
    {
   
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Playermove>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            player.AddHealth(20);
            Destroy(gameObject);
        }
      
    }
 
}
