using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }

    // Update is called once per frame
    public void SpawnEnemy()
    {
        float xvalue = Random.Range(-2.0f, 2.0f);
        Vector2 spawnposition = new Vector2(xvalue, 6.0f);
        Instantiate(enemy,spawnposition, Quaternion.identity);

    }
    public void StartSpawn()
    {
        InvokeRepeating("SpawnEnemy", 1.0f, 2.0f);
    }
    public void StopSpawn()
    {
        CancelInvoke("SpawnEnemy");
    }
}
