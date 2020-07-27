using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] GameObject rocket = null;
    Vector3 bu;
    void Start()
    {
        bu = rocket.transform.position;
    }
    public void jumpToTheRocket()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(bu);
        transform.Translate(bu * Time.deltaTime * 20f);
    }
}
