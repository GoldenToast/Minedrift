using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject objectPrefab;
	[Range(1,9999)]
	public int count = 1;

	public bool autoDestroy;
	public float destroyTime;

	public bool randomSpawn;
	[Range(1,9999)]
	public float spawnRadius;

	public void Spawn(Vector3 pos, Quaternion rotation){
		for (int i = 0; i < count; i++) {
			if (randomSpawn) {
				pos = randPosition (pos);
			}
			var go = Instantiate(objectPrefab, pos, rotation);
			if (autoDestroy) {
				Destroy (go, destroyTime);
			}
		}
	}
	private Vector3 randPosition(Vector3 pos){
		Vector2 dir = Random.insideUnitSphere * spawnRadius;
		Vector3 newRandPos = pos + new Vector3(dir.x, 0, dir.y);
		NavMeshHit hit;
		NavMesh.SamplePosition(newRandPos, out hit, spawnRadius, 1);
		return hit.position;
	}
}
