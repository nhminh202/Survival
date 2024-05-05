using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : GameUnit, IAttack
{
    public float dmg;

    public override void OnInit()
    {
        Invoke(nameof(OnDespawn), 1);
    }

    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IGetDamage>() != null)
        {
            Debug.Log("DMG");
            collision.GetComponent<IGetDamage>().GetDamage(dmg);
        }
    }

    public void DealDamage(float damage)
    {
        
    }
}
