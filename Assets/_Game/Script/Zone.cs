using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public float DPS;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<IGetDamage>() != null)
        {
            Debug.Log("DMG");
            collision.GetComponent<IGetDamage>().GetDamage(DPS * Time.deltaTime);
        }
    }
}
