using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPlatform : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.rotation.z >= -0.1 && collision.transform.rotation.z <= .1)
        {
            if (FindObjectOfType<OilController>().GetValue() < 1000)
            {
                FindObjectOfType<OilController>().AddOil();
            }
        }
    }
}
