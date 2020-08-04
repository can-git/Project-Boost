using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    [SerializeField] GameObject objects;
    [SerializeField] float rotateSpeed=5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //foreach (GameObject item in objects)
        //{
        //}
            transform.RotateAround(objects.transform.position, Vector3.down, rotateSpeed * Time.deltaTime);
    }
}
