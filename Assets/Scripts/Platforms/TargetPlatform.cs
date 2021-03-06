﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlatform : MonoBehaviour
{
    [SerializeField] int alienCount = 0;
    [SerializeField] Alien prefab;
    List<Alien> aliens;
    private void Awake()
    {
        aliens = new List<Alien>();
    }
  
    public void Start()
    {
        aliens = new List<Alien>();
        for (int i = 0; i < alienCount; i++)
        {
            aliens.Add(Instantiate(prefab,
                this.gameObject.transform.position + new Vector3(Mathf.RoundToInt(Random.Range(-1 * (this.gameObject.transform.localScale.x / 2), this.gameObject.transform.localScale.x / 2)), this.gameObject.transform.localScale.y+.3f, Random.Range(-1 * (this.gameObject.transform.localScale.z / 2), this.gameObject.transform.localScale.z / 2)),
                Quaternion.identity));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        foreach (Alien alien in aliens)
        {
            if (collision.gameObject.transform.rotation.z >= -.1f && collision.gameObject.transform.rotation.z <= .1f)
            {
                alien.LeaveThePlatform(collision.gameObject.transform.position);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        foreach (Alien alien in aliens)
        {
            alien.StayOnThePlatform();
        }
    }
}
