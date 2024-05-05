using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawGroup : MonoBehaviour
{
    public List<Saw> listSaw = new List<Saw>();
    public float radius;
    public float dmg;
    public float duration;
    public float sleepTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DisableSaw), duration);
        SetSawPosition();
    }

    public void SetSawPosition()
    {
        int n = listSaw.Count;
        float singleAngle = 360 / n;

        Vector3 originVector = new(0, radius, 0);
        for (int i = 0; i < n; i++)
        {
            Vector3 v = Quaternion.AngleAxis(singleAngle * i, Vector3.forward) * originVector;

            listSaw[i].transform.localPosition = v;
            listSaw[i].InitSaw(dmg);
        }
    }



    public void DisableSaw()
    {
        for (int i = 0; i < listSaw.Count; i++)
        {
            listSaw[i].gameObject.SetActive(false);
        }

        Invoke(nameof(EnableSaw), sleepTime);
    }

    public void EnableSaw()
    {
        for (int i = 0; i < listSaw.Count; i++)
        {
            listSaw[i].gameObject.SetActive(true);
        }
        Invoke(nameof(DisableSaw), duration);
    }
}
