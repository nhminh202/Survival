using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public FloatingJoystick joystick;
    public float speed;
    public Image expBar;
    public TMP_Text levelText;

    private GameObject map;
    private float maxEXP;
    private float currentEXP;
    private int level;

    [Header("BULLET")]
    public float fireCD;
    private float currentFireCD;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindGameObjectWithTag("Map");
        InvokeRepeating(nameof(SpawnEnemy), 1, 2);

        currentEXP = 0;
        level = 0;
        maxEXP = 50;
        expBar.fillAmount = currentEXP / maxEXP;
        levelText.text = "Level " + level;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(joystick.Horizontal, joystick.Vertical).normalized * speed * Time.deltaTime;

        if (currentFireCD <= 0)
        {
            FireBullet();
            currentFireCD = fireCD;
        }
        else
        {
            currentFireCD -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RightCollider")){
            map.transform.position += new Vector3(10.24f, 0);
        }        
        
        if (other.CompareTag("LeftCollider")){
            map.transform.position -= new Vector3(10.24f, 0);
        }
        
        if (other.CompareTag("TopCollider")){
            map.transform.position += new Vector3(0, 10.24f);
        }        
        
        if (other.CompareTag("BottomCollider")){
            map.transform.position -= new Vector3(0, 10.24f);
        }
    }

    public void SpawnEnemy()
    {
        Enemy newEnemy = SimplePool.Spawn<Enemy>(PoolType.Enemy);
        newEnemy.transform.position = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f)) + transform.position;
        newEnemy.playerTF = transform;
        newEnemy.OnInit();
    }

    public void IncreaseExp(float exp)
    {
        currentEXP += exp;
        if (currentEXP >= maxEXP)
        {
            level++;
            currentEXP = 0;
            maxEXP += 50;
            levelText.text = "Level " + level;
        }

        expBar.fillAmount = currentEXP / maxEXP;
    }

    public void FireBullet()
    {
        Bullet bullet = SimplePool.Spawn<Bullet>(PoolType.Bullet, transform.position, Quaternion.identity);
        bullet.OnInit(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized);
    }
}
