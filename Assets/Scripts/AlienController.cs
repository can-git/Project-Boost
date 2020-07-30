using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    int count;
    AudioSource audioSource;
    void Start()
    {
        foreach (Alien alien in FindObjectsOfType<Alien>())
        {
            addCount();
        }
        audioSource = GetComponent<AudioSource>();
    }


    public void addCount()
    {
        count++;
    }
    public void deleteCount()
    {
        count--;
        audioSource.Play();
        
    }
    public int getCount()
    {
        return count;
    }
}
