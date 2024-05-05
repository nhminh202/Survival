using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : GameUnit
{
    public float exp_value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().IncreaseExp(exp_value);
            SimplePool.Despawn(this);
        }
    }
}
