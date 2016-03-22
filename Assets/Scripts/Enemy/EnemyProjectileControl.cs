using UnityEngine;
using System.Collections;
using Weapon;

public class EnemyProjectileControl : MonoBehaviour {

    private const string MOUNT1 = "Mount1";
    private const string MOUNT2 = "Mount2";

    public GameObject weaponPrefab;
    public float lifetime;
    public float fireFrequency;

    private Transform mount1;
    private Transform mount2;
	private GameObject weapon1;
	private GameObject weapon2;
	private GameObject currentWeapon;
   
    private float lastShot;

    // Use this for initialization
    void Start () {
        this.mount1 = transform.FindChild(MOUNT1);
        this.mount2 = transform.FindChild(MOUNT2);
		this.weapon1 = Instantiate (weaponPrefab,mount1.position,mount1.rotation) as GameObject;
		this.weapon1.transform.SetParent (mount1);
		this.weapon2 = Instantiate (weaponPrefab,mount2.position,mount2.rotation) as GameObject;
		this.weapon2.transform.SetParent (mount2);
		currentWeapon = weapon1;
    }
		

	// Update is called once per frame
	void Update () {
        lastShot -= 1 * Time.deltaTime;
        if (lastShot <= 0)
        {
            fire();
        }
    }
  
	void fire()    {
		if (currentWeapon.Equals(weapon1))
		{
			currentWeapon = weapon2;
		}
		else
		{
			currentWeapon = weapon1;
		}

		AbstractWeapon weapon = currentWeapon.GetComponent<AbstractWeapon>();
		weapon.Fire (this.gameObject);
		lastShot = weapon.fireFrequency;
	}
}
