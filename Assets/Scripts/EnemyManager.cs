using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] Transform[] positions;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.5f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (!enemies[i].activeSelf)
            {
                index = Random.Range(0, positions.Length - 1);
                enemies[i].SetActive(true);
                enemies[i].GetComponent<EnemyBehaviour>().StartEnemy();
                enemies[i].transform.position = positions[index].transform.position;
                return;
            }
        }
    }
}
