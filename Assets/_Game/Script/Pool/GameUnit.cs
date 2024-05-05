using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    private Transform tf;
    public Transform TF
    {
        get
        {
            //tf = tf ?? gameObject.transform;
            if (tf == null)
            {
                tf = GetComponent<Transform>();
            }
            return tf;
        }
    }

    public PoolType poolType;

    public virtual void OnInit() {

    }
    public virtual void OnDespawn()
    {

    }
}