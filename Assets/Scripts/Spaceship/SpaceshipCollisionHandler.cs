using UnityEngine;
using System.Collections;

public class SpaceshipCollisionHandler : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.CompareTag (Tags.COLLECTABLE)) {
			Debug.Log (other.name + " collected!");
			GetComponent<PlayerWeaponControl> ().attachWeapon(other.GetComponent<CollectableContainer>().getCollectable());
		}
	}
}
