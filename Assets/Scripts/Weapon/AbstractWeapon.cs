using UnityEngine;

namespace Weapon
{
	public abstract class AbstractWeapon : MonoBehaviour
	{
		public GameObject projectilePrefab;
	
		public float fireFrequency;

		public abstract void Fire(GameObject origin);
	}
}

