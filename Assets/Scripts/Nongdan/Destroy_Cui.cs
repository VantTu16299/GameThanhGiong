using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Cui : MonoBehaviour
{
    public int destroy = 20;
    public int Famor;
    public GameObject deathEffect;
    
    public CoinsMananger cm;
    private void Start()
    {
        cm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<CoinsMananger>();
    }
    public void TakeDamage(int damage)
    {
        destroy -= damage;
        if (destroy <= 0)
        {
            Destroy();
        }
    }
    void Destroy()
    {
        GameObject deatheffect = Instantiate(deathEffect, transform.position, Quaternion.identity);
      
        Destroy(gameObject);
        AudioManager.instance.PlaySound("enemy_die");
        cm.famor += Famor;
    }
}
