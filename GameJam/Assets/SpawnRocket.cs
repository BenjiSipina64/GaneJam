using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocket : MonoBehaviour
{
    [SerializeField] private GameObject rocket;
    public KeyCode key;
    
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Instantiate(rocket, transform.position, Quaternion.identity);
        }
    }
}
