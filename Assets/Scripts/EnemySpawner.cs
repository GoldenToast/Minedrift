using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefabs;
    public int enemyCount;

    private int currentCount;
    
    // Use this for initialization
    void Start () {
        currentCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
         if (currentCount < enemyCount) {
            spawnEnemy(enemyPrefabs, randPosition());
            currentCount++;
        } 
    }

    private void spawnEnemy(GameObject enemyPrefabs ,Vector3 position)
    {
        GameObject.Instantiate(enemyPrefabs, position, Random.rotation);
    }

    private Vector3 randPosition()
    {
        Vector2 dir = Random.insideUnitSphere * 20.0f;
        Vector3 newRandPos = this.transform.position + new Vector3(dir.x, 0, dir.y);
        NavMeshHit hit;
        NavMesh.SamplePosition(newRandPos, out hit, 20.0f, 1);
        return hit.position;
    }

}
