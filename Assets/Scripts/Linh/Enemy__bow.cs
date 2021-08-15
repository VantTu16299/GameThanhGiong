using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy__bow : MonoBehaviour
{
    public int heath = 20;
    public GameObject deathEffect;
    //public GameObject gameWin;
    // Start is called before the first frame update
  
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
        Destroy(deatheffect, 0.3f);
        Destroy(gameObject);

    
    }

}
