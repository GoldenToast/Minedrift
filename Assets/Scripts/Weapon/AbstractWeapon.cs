using UnityEngine;

namespace Weapon
{
	public abstract class AbstractWeapon : MonoBehaviour
	{
		
		public float lifetime;
		public float fireFrequency;
		public int damage;

		public abstract void Fire(GameObject origin);


	}
}

