using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxTrigger : MonoBehaviour
{
    public int dmg = 20;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Player"))
        {
            col.SendMessageUpwards("PlayerDamage", dmg);
           
                AudioManager.instance.PlaySound("enemy_attack");                            // Play A Single Sound with key "Bounce"
            
        }
    }
}
