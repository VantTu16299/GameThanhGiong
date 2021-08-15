using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackdelay = 0.3f;
    public bool attacking = false;

    public Animator anim;

    public Collider2D trigger;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool attack1 = false;
    public bool attack2 = false;
    public bool attack3 = false;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (!attacking)
        {
            Attacking();
        }
        Attacking1();
        Attacking2();
    }
   public void Attacking()
    {
        //if ( attack1 == true && !attacking)-- dùng thay cho phím
        if (Input.GetKeyDown(KeyCode.W) && !attacking)
            {
            AudioManager.instance.PlaySound("attack");
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.3f;
        }

        if (attacking)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;

            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }

        anim.SetBool("Attacking", attacking);

    }
   public void Attacking1()
    {
        if (Input.GetKeyDown(KeyCode.E) && !attacking)
        {
            AudioManager.instance.PlaySound("attack2");
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.3f;
        }

        if (attacking)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;

            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }

        anim.SetBool("Attacking1", attacking);

    }
  public  void Attacking2()
    {
        if (Input.GetKeyDown(KeyCode.R)  && !attacking)
        {
            AudioManager.instance.PlaySound("attack3");
            attacking = true;
            var bullet = bulletPrefab.Spawn(firePoint.position,firePoint.rotation);
            bullet.transform.localScale = Vector3.one;
            bullet.SetActive(true);
            ////Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            attackdelay = 0.3f;

        }

        anim.SetBool("Attacking2", attacking);

    }
    public void Attack(bool attack)
    {
        attack1= attack;

    }
    public void Attack1(bool attack)
    {
        attack2 = attack;

    }
    public void Attack2(bool attack)
    {
        attack3 = attack;

    }

}
