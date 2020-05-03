using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject SpawnObject;

    public float SpawnAreaWidth;
    public float SpawnAreaHeight;

    public int NoOfEnemiesX;
    public int NoOfEnemiesY;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NoOfEnemiesX; i++)
        {
            for (int j = 0; j < NoOfEnemiesY; j++)
            {
                Vector3 spawnPosition = transform.position;
                spawnPosition.x += i * (SpawnAreaWidth / NoOfEnemiesX);
                spawnPosition.y += j * (SpawnAreaHeight / NoOfEnemiesY);
                Instantiate(SpawnObject, spawnPosition, SpawnObject.transform.rotation, transform);
            }
        }
    }

    private void Update()
    {
        if (transform.childCount == 0)
            Start();
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < NoOfEnemiesX; i++)
        {
            for (int j = 0; j < NoOfEnemiesY; j++)
            {
                Vector3 spawnPosition = transform.position;
                spawnPosition.x += i * (SpawnAreaWidth / NoOfEnemiesX);
                spawnPosition.y += j * (SpawnAreaHeight / NoOfEnemiesY);
                Gizmos.DrawLine(spawnPosition + Vector3.left, spawnPosition + Vector3.right);
                Gizmos.DrawLine(spawnPosition + Vector3.up, spawnPosition + Vector3.down);
                Gizmos.DrawLine(spawnPosition + Vector3.forward, spawnPosition + Vector3.back);
            }
        }
    }
}