using UnityEngine;
using System.Collections;

namespace Weapon
{
	[RequireComponent (typeof (Rigidbody))]
	public class LaserProjectile : MonoBehaviour {

		public float lifetime;
		public float bulletSpeed;
		public int damage;

		private Rigidbody rb;


		// Use this for initialization
		void Start () {
			rb = GetComponent<Rigidbody>();
			Destroy(this.gameObject, lifetime);
		}

		// Update is called once per frame
		void FixedUpdate () {
			rb.velocity = transform.forward * bulletSpeed;
		}

		void OnTriggerEnter(Collider other) {
			if (other.tag.Equals(Tags.RADAR)) {
				return;
			}

			if (!this.tag.Contains(other.tag)){ 
				if (other.gameObject.GetComponent<Hitable>() != null)
				{
					Debug.Log("Damage " + other.gameObject);
					other.gameObject.GetComponent<Hitable>().takeDamage(damage);
				}
				Destroy(this.gameObject);
			}

		}
	}
}
