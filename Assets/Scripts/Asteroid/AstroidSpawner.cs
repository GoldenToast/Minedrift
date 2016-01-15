using UnityEngine;
using System.Collections.Generic;

public class AstroidSpawner : MonoBehaviour {

    public int radius;
    public int count;
    public List<Hitable> spawner = new List<Hitable>();

	// Use this for initialization
	void Start () {
        for (int i = 0; i < count; i++) {
            int selector = Random.Range(0, spawner.Count);
            Vector3 pos =  RandPosition();
            float rndY = Random.Range(0, 359);
            Quaternion rotation = Quaternion.Euler(new Vector3(0, rndY, 0));
            GameObject asteroid = Instantiate(spawner[selector], pos,rotation) as GameObject;
        }
            //float rndScale = Random.Range(1f, 2f);
            //Debug.Log(asteroid);
            //asteroid.transform.localScale = new Vector3(rndScale, rndScale, rndScale);
    }

    private Vector3 RandPosition()
    {
        Vector3 dir = Random.insideUnitSphere * radius;
        Vector3 newRandPos = this.transform.position + dir;
        NavMeshHit hit;
        NavMesh.SamplePosition(newRandPos, out hit, radius, 1);
        return hit.position;
    }

}
