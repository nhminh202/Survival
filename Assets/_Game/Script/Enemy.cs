using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameUnit, IGetDamage
{
    public float speed;
    public float dmg;
    public float maxHP;
    public Transform playerTF;
    private Vector3 direct;
    public Animator animator;
    public Rigidbody2D rb2d;
    public SpriteRenderer spriteRenderer;

    private float currentHP;
    private bool isdead;
    public override void OnInit()
    {
        currentHP = maxHP;
        isdead = false;
    }
    public void GetDamage(float damage)
    {
        currentHP -= damage;
        SetFlash();
        if (currentHP <= 0 && !isdead)
        {
            Death();
        }
    }

    public void SetFlash()
    {
        spriteRenderer.color = Color.red;
        Invoke(nameof(SetUnFlash), 0.1f);
    }

    public void SetUnFlash()
    {
        spriteRenderer.color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    void Death() 
    {
        isdead = true;
        animator.SetTrigger("die");
        Invoke(nameof(OnDespawn), 5 / 12f);
    }

    public override void OnDespawn()
    {
        SimplePool.Spawn<Exp>(PoolType.Exp, TF.position, Quaternion.identity);
        SimplePool.Despawn(this);
    }


    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(TF.position, playerTF.position) > 0.5f && currentHP > 0) {
            direct = playerTF.position - transform.position;
            rb2d.velocity = direct.normalized * speed;
            spriteRenderer.flipX = rb2d.velocity.x < 0;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }


    }
}
