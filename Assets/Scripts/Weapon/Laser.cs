using UnityEngine;
using System.Collections;

namespace Weapon {
[RequireComponent (typeof (Rigidbody))]
public class Laser : AbstractWeapon{
		
		public float bulletSpeed;
	


		private Rigidbody rb;

		public override void Fire(GameObject origin){
			
		}

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

		    if (!other.tag.Equals(this.tag))
		    { 
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
