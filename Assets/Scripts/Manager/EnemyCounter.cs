using UnityEngine;
using System.Collections;

public class EnemyCounter : MonoBehaviour {

    public int counter;


	// Update is called once per frame
	void Update () {
        counter = GameObject.FindGameObjectsWithTag(Tags.ENEMY).Length;
    }
}
