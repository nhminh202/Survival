using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour, IAttack
{
    private float dmg;
    public void InitSaw(float dmg)
    {
        this.dmg = dmg;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IGetDamage>() != null)
        {
            Debug.Log("DMG");
            other.GetComponent<IGetDamage>().GetDamage(dmg);
        }
    }

    public void DealDamage(float damage)
    {

    }
}
