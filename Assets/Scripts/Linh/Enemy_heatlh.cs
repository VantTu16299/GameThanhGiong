using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_heatlh : MonoBehaviour
{
    public int heath = 100;
    public GameObject deathEffect;
    public GameObject add_heatlh;


    public CoinsMananger cm;

    private void Start()
    {
 

        cm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<CoinsMananger>();
    }
    public void TakeDamage(int damage)
    {
        heath -= damage;
        if (heath <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject deatheffect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        GameObject addheatlh = Instantiate(add_heatlh, transform.position, Quaternion.identity);
        AudioManager.instance.PlaySound("enemy_die");
        Destroy(gameObject);
        
          cm.Coins += 1;
    }
   
}
