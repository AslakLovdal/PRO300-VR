using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public float timeBetweenSpawns;
    //public Transform spawnPoint;

    float timer;
    //bool spawned;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if(timer >= timeBetweenSpawns)
        {
            Spawn(); 
        }

	}

    void Spawn()
    {
        GameObject enemyClone = (GameObject) Instantiate(enemy, transform.position, transform.rotation);

        timer = 0f;
       
    }
}
