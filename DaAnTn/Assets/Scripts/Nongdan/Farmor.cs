using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmor : MonoBehaviour
{
    public Animator anim;
    public bool change = false;
    public Transform leftLimit;
    public Transform rightLimit;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            change = true;
            anim.SetBool("Changer", change);
        }
   
    }
}
