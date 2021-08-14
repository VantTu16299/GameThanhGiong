using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_heahGameWin : MonoBehaviour
{
    public int heath = 100;
    public GameObject deathEffect;
    public AudioSource aus;
    public AudioClip shootingSoundDeath;
    public GameObject gamewin_ui;
    //public int CointsAdd = 1;
    private void Start()
    {
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
        Destroy(deatheffect, 0.3f);
        if (aus && shootingSoundDeath)
        {
            aus.PlayOneShot(shootingSoundDeath);
        }

        Destroy(gameObject);
        //CoinsMananger.AddCoins(1);
        gamewin_ui.SetActive(true);
    }
}
