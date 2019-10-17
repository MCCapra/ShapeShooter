using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private float timeTillNextEnemy;
    
    [SerializeField] 
    private GameObject cube, sphere, cylinder, player; //Enemies
    // Start is called before the first frame update
    void Start()
    {
        timeTillNextEnemy = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timeTillNextEnemy += Time.deltaTime;

        if(timeTillNextEnemy > 5)
        {
            Spawn();
            timeTillNextEnemy = 0;
        }
    }

    void Spawn()
    {
        int nextEnemy = Random.Range(1, 4);
        GameObject clone;

        switch (nextEnemy)
        {
            case 1:
                clone = Instantiate(cube, transform.position, transform.rotation);
                clone.GetComponent<EnemyBehavior>().Type = 1;
                clone.GetComponent<EnemyBehavior>().PlayerPosition = player.transform.position;
                clone.GetComponent<EnemyBehavior>().Player = player;
                break;
            case 2:
                clone = Instantiate(sphere, transform.position, transform.rotation);
                clone.GetComponent<EnemyBehavior>().Type = 2;
                clone.GetComponent<EnemyBehavior>().PlayerPosition = player.transform.position;
                clone.GetComponent<EnemyBehavior>().Player = player;
                break;
            case 3:
                clone = Instantiate(cylinder, transform.position, transform.rotation);
                clone.GetComponent<EnemyBehavior>().Type = 3;
                clone.GetComponent<EnemyBehavior>().PlayerPosition = player.transform.position;
                clone.GetComponent<EnemyBehavior>().Player = player;
                break;
            default:
                break;
        }

    }
}
