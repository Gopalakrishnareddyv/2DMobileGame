using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject currentenemy;
    Score score;
    Stack<GameObject> enemypool = new Stack<GameObject>();
    private static EnemySpawn instance;

    public static EnemySpawn Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<EnemySpawn>();
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
        score = GameObject.Find("ScoreManager").GetComponent<Score>();
    }
    public void CreatePool()
    {
        enemypool.Push(Instantiate(enemy));
        enemypool.Peek().SetActive(false);
        enemypool.Peek().name = "Enemy";
    }
    public void addEnemy(GameObject enemytemp)
    {
        enemypool.Push(enemytemp);
        enemypool.Peek().SetActive(false);
        score.Increment();

    }
    // Update is called once per frame
    public void SpawnEnemy()
    {
        if (enemypool.Count == 0)
        {
            CreatePool();
        }
        GameObject temp = enemypool.Pop();
        temp.SetActive(true);
        float xvalue = Random.Range(-2.0f, 2.0f);
        Vector2 spawnposition = new Vector2(xvalue, 6.0f);
        temp.transform.position = spawnposition;
        currentenemy = temp;

    }
    public void StartSpawn()
    {
        InvokeRepeating("SpawnEnemy", 1.0f, 4.0f);
    }
    public void StopSpawn()
    {
        CancelInvoke("SpawnEnemy");
    }
}
