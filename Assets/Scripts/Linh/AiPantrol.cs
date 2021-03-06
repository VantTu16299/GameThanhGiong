using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPantrol : MonoBehaviour
{
    public float walkSpeed;
    public float range, timeBTWShots, shootSpeed;
    private float distToPlayer;

    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;
    private bool canShoot, faceright = true;

    public Rigidbody2D rb;
    public Transform groundCheckpos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform player, shootPos;
    public GameObject bullet;

    private Animator anim;
    public bool attacking;

    //public Bullet arrow;

    void Start()
    {
        //arrow = GameObject.FindGameObjectWithTag("Arrow").GetComponent<Bullet>();
        anim = GetComponent<Animator>();
        mustPatrol = true;
        canShoot = true;

    }

    void Update()
    {
        if (mustPatrol || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Patrol();
        }
        anim.SetBool("Attack", attacking == false);
      
        if (player != null)
        {
            distToPlayer = Vector2.Distance(transform.position, player.position);

            if (distToPlayer <= range)
            {
                if (player.position.x > transform.position.x && transform.localScale.x < 0
                    || player.position.x < transform.position.x && transform.localScale.x > 0)
                {
                    Flip();
                }
                mustPatrol = false;
                rb.velocity = Vector2.zero;
                if (canShoot)
                {
                    StartCoroutine(Shoot1());
                 
                }
                else
                {
                    mustPatrol = true;
                }
                anim.SetBool("Attack", attacking == true);
            }
        }
    }
    void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckpos.position, 0.1f, groundLayer);
        }
    }
    void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
        anim.SetBool("Attack", attacking == false);
    }
    //Hàm lật Nhân vật
    //public void Flip()
    //{
    //    faceright = !faceright;
    //    transform.Rotate(0f, 180f, 0f);
    //    //AudioManager.instance.PlaySound("nguachay");
    //}
    void Flip()
    {
        mustPatrol = false;
    
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
   
        mustPatrol = true;
    }
    IEnumerator Shoot1()
    {
        canShoot = false;

        yield return new WaitForSeconds(timeBTWShots);
        GameObject newBullet = Instantiate(bullet, shootPos.position,shootPos.rotation); 
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);
        Debug.Log("Shoot");
        canShoot = true;

    }
}
