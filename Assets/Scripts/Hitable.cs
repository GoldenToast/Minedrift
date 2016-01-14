﻿using UnityEngine;
using System.Collections;

public class Hitable : MonoBehaviour {

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
            Respawn();
        }
	}

    void Respawn(){
		transform.position = spawnPosition;
	}
	
	void DoExplosion(Vector3 pos, Quaternion rotation){
        Debug.Log("Explode");
        //GameObject explosion = Instantiate(explosionPrefab, pos, rotation) as GameObject;
        GetComponent<AudioSource>().Play(0);

		//Destroy (explosion, SecondsUntilDestroy);
	}
}
