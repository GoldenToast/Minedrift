using UnityEngine;
using System.Collections;

public class Hitable : MonoBehaviour {
	public Object test;
	public GameObject explosionPrefab;
	public int health = 100;

    private float SecondsUntilDestroy = 5;
    private Vector3 spawnPosition;

    void Start() {
        spawnPosition = transform.position;
    }

	public void takeDamage(int damage){
		health -= damage;
		if (health <= 0) {
            DoExplosion(transform.position, transform.rotation);
			Destroy (this.gameObject);
            //Respawn();
        }
	}

    void Respawn(){
		transform.position = spawnPosition;
	}
	
	void DoExplosion(Vector3 pos, Quaternion rotation){
        Debug.Log("Explode");
        GetComponent<AudioSource>().Play(0);
	}
}
