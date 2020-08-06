using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    enum State { Stay, Leave };

    State state = State.Stay;
    Vector3 rocketPos;
    private void Awake()
    {
        FindObjectOfType<AlienController>().addCount();
    }
    private void Update()
    {
        if (state == State.Leave)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, rocketPos, .4f * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Rocket")
        {
            FindObjectOfType<AlienController>().deleteCount();
            Destroy(gameObject);
        }
    }
    public void LeaveThePlatform(Vector3 rocketPos)
    {
        state = State.Leave;
        this.rocketPos = rocketPos;
    }
    public void StayOnThePlatform()
    {
        state = State.Stay;
    }
}
