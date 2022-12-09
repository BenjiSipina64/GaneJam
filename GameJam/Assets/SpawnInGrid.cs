using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnInGrid : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    public float spawnSpeed;
    public int rows;
    public int cols;
    private bool iterate;
    private bool canPress = true;
    private float num;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canPress)
        {
            canPress = false;
            StartCoroutine(SpawnGrid());
        }
        Debug.Log(num);
    }

    private IEnumerator SpawnGrid()
    {
        for (int R = 0; R < rows; R++)
        {
            for (int C = 0; C < cols; C++)
            {
                num += 0.0001f;
                yield return new WaitForSeconds(spawnSpeed / 1000);
                if (iterate)
                {
                    Instantiate(cube,
                        new Vector3(gameObject.transform.position.x + C + num, 0, gameObject.transform.position.z + R +num),
                        Quaternion.identity);
                    iterate = false;
                }

                if (!iterate)
                {
                    Instantiate(cube,
                        new Vector3(gameObject.transform.position.x + C + num, 0, gameObject.transform.position.z + C +num),
                        Quaternion.identity);
                    iterate = true;
                }

            }
        }
    }


private void OnDrawGizmos()
    {
        for (int A = 0; A < rows ; A++)
        {
            for (int B = 0; B < cols; B++)
            {
                Gizmos.color = Color.red;
               Gizmos.DrawWireCube(new Vector3(rows/2, 0, cols/2), new Vector3(rows,0,cols));

            }
        }
    }
}
