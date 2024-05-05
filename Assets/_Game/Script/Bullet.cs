using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : GameUnit
{
    public float speed;
    Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    public void OnInit(Vector2 direct)
    {
        float angleZ = Mathf.Atan2(direct.x, direct.y) * Mathf.Rad2Deg;
        TF.eulerAngles = new Vector3(0, 0, -angleZ);
        myBody.AddForce(direct * speed, ForceMode2D.Impulse);
        Invoke(nameof(OnDespawn), 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            SimplePool.Spawn<FireBall>(PoolType.FireBall, TF.position, Quaternion.identity).OnInit();
            SimplePool.Despawn(this);
        }
    }

    public override void OnDespawn()
    {
        SimplePool.Spawn<FireBall>(PoolType.FireBall, TF.position, Quaternion.identity).OnInit();
        SimplePool.Despawn(this);
    }
}
