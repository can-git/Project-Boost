using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    bool durum = false;
    Vector3 rocketPos;
    private void Update()
    {
        if (durum)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, rocketPos, .4f * Time.deltaTime);
        }
    }
    public void jumpToTheRocket(Vector3 rocketPos)
    {
        durum = true;
        this.rocketPos = rocketPos;
    }
    public void ChangeDurum()
    {
        durum = false;
    }
}
