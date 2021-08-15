using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource aus;
    public AudioClip shootingSound;
   
    // Update is called once per frame
    void Update()
    {
      
    }
   public void SoundAttack()
    {
        if (aus && shootingSound)
        {
            aus.PlayOneShot(shootingSound);

        }
    }
}
