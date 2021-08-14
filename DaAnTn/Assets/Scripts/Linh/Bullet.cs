using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 0.1f;
    public GameObject impactEffect;
    public Rigidbody2D rb2d;
    private float _lifeTime;
    public bool facingLeft;
    private void OnEnable()
    {
        _lifeTime = lifetime;
       
    }

    private void Start()
    {
        if (facingLeft == true)
        {
            facingLeft = false;
            Flip();
        }
    }

    private void FixedUpdate()
    {
        CheckDirection();
    }
    public void CheckDirection()
    {
        if (facingLeft != true && rb2d.velocity.x < 0)
        {
            Flip();
        }
        else if (facingLeft == true && rb2d.velocity.x > 0)
        {
            Flip();
        }
    }
    private void Flip()
    {
        facingLeft = !facingLeft;
        Vector2 theScale = new Vector2();
        theScale = gameObject.transform.localScale;
        theScale.x *= -1;
        gameObject.transform.localScale = theScale;
     }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger == false) 
        {
            if (col.CompareTag("Player"))
            {
                col.SendMessageUpwards("PlayerDamage", 20);
            }

        }
        // Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
         //GameObject destroyEffect = Instantiate(impactEffect, transform.position,transform.rotation);
         //     Destroy(gameObject);
        impactEffect.Spawn(transform.position, Quaternion.identity);
        gameObject.Recycle();
    }
    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            gameObject.Recycle();
    }
}