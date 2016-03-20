using UnityEngine;
using System.Collections;

namespace Weapon {
public class LaserWeapon : AbstractWeapon{

		public GameObject projectilePrefab;
		private string LASER = "Laser";
			
		public override void Fire(GameObject origin){
			GameObject weaponObj = GameObject.Instantiate(projectilePrefab, transform.position, transform.rotation) as GameObject;
			weaponObj.tag = origin.tag + LASER;
		}
	}
}
