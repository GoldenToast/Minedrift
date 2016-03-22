using UnityEngine;
using System.Collections;

namespace Weapon{
	public class MeleeWeapon : AbstractWeapon {


		public int damage;

		public override void Fire(GameObject origin){
			
		}

		// Update is called once per frame
		void Update()
		{
		    this.transform.rotation *= Quaternion.Euler(new Vector3(0, 5, 0));
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.tag.Equals(Tags.PLAYER1) || other.tag.Equals(Tags.PLAYER2))
		    {
		        Debug.Log("Damage " + other.gameObject);
		        if(other.gameObject.GetComponent<Hitable>() != null)
		        {
		            other.gameObject.GetComponent<Hitable>().takeDamage(damage);
		        }
		    }
		    if (other.tag.Equals(this.tag))
		    {
		        Debug.Log("NoDamage to " + other);
		    }

		}
	}
}