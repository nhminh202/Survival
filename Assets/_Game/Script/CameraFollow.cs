using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().transform;
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed*Time.deltaTime);
    }
}
