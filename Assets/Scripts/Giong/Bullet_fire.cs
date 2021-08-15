using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_fire : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float lifetime = 0.1f;
    public GameObject impactEffect;
    private float _lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        _lifeTime = lifetime; 
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
     
        Enemy_heatlh enemy = collision.GetComponent<Enemy_heatlh>();
        if (enemy != null)
        {
            enemy.TakeDamage(20);
        }
        impactEffect.Spawn(transform.position, Quaternion.identity);
        gameObject.Recycle();

    }
   void Update()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
        {
            gameObject.Recycle();
        }
    }
}
