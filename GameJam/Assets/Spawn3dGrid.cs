using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn3dGrid : MonoBehaviour
{
    // Define the size of the grid and the size of each cube
    public int gridSize = 10;
    public float cubeSize;
    public float spawnTime;
    private bool canPress = true;
    public Material cubeTexture;
    [SerializeField] private GameObject cube;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canPress)
        {
            StartCoroutine(spawnGrid());
            canPress = false;
        }
    }
    
    private IEnumerator spawnGrid()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int z = 0; z < gridSize; z++)
                {
                    yield return new WaitForSeconds(spawnTime);

                    Instantiate(cube, new Vector3(x * cubeSize, y * cubeSize, z * cubeSize),Quaternion.identity);
                    
                    cube.GetComponentInChildren<Renderer>().material = cubeTexture;
                    Physics.Raycast
                }
            }
        }
    }
}