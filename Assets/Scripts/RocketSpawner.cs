using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    [SerializeField] GameObject rocket = null;
    void Start()
    {
        newRocket();
    }
    public void newRocket()
    {
        Vector3 bu = transform.position;
        bu.y = bu.y + 5;
        Instantiate(rocket, bu , transform.rotation);
        
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
