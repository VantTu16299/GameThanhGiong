using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playermove : MonoBehaviour
{
    public float speed = 50f, maxspeed = 3, jumpPow = 220f;
    public bool grounded = true, faceright = true, doublejump = false;

    public Rigidbody2D r2;
    public Animator anim;

    public int currenhealth;
    public int maxhealth = 100;
    public HealthBar healthBar;
    public GameObject gameover_ui;
    public CoinsMananger cm;
    // Use this for initialization
    void Start()
    {
       
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        currenhealth = maxhealth;
        healthBar.setMaxHealth(maxhealth);
        cm  = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<CoinsMananger>();

        //if()

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumpPow);

            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 0.7f);
                }
            }
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);
    
        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

        if (h > 0 && !faceright)
        {
            Flip();
        }

        if (h < 0 && faceright)
        {
            Flip();
        }
        if (currenhealth <= 0)
        {
            Die();
        }
    }

    public void Flip()
    {
            faceright = !faceright;
            transform.Rotate(0f, 180f, 0f);
        AudioManager.instance.PlaySound("nguachay");
    }
    public void Die()
    {
        AudioManager.instance.PlaySound("mantiep");
        gameover_ui.SetActive(true);
        // gameoverUI.SetActive(true);

        Destroy(gameObject);
        //load lại scene hiện tại và build scene đó
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
 
    public void PlayerDamage(int damage)
    {
        currenhealth -= damage;

        //gameObject.GetComponent<Animation>().Play("Redflash");
        healthBar.sethealth(currenhealth);
    }
    public void AddHealth(int health)
    {
            currenhealth += health;
        healthBar.sethealth(currenhealth);
    }
    //public void Knockback(float Knockpow, Vector2 Knockdir)
    //{
    //    r2.velocity = new Vector2(0, 0);
    //    r2.AddForce(new Vector2(Knockdir.x * -100, Knockdir.y + Knockpow));
    //}
    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.CompareTag("Farmor"))
    //    {

    //        Destroy(col.gameObject);
    //        cm.famor += 1;
    //        //CoinsMananger.AddFamer(1);
    //    }
    //}
}
