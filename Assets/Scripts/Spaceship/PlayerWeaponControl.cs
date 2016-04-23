using UnityEngine;
using System.Collections;
using Weapon;

public class PlayerWeaponControl : MonoBehaviour {

    private const string MOUNT1 = "Mount1";
    private const string MOUNT2 = "Mount2";
    private const string FIRE1 = "Fire1";
    private const string FIRE2 = "Fire2";

    private Transform mount1;
    private Transform mount2;
	private GameObject weapon1;
	private GameObject weapon2;
	private GameObject currentWeapon;

    private float lastShot;

	public void attachWeapon(GameObject weapon){
		Destroy (weapon1);
		Destroy (weapon2);
		this.mount1 = transform.FindChild(MOUNT1);
		this.mount2 = transform.FindChild(MOUNT2);
		this.weapon1 = Instantiate (weapon,mount1.position,mount1.rotation) as GameObject;
		this.weapon1.transform.SetParent (mount1);
		this.weapon2 = Instantiate (weapon,mount2.position,mount2.rotation) as GameObject;
		this.weapon2.transform.SetParent (mount2);
		currentWeapon = weapon1;
	}
		

    // Use this for initialization
    void Start () {
        this.mount1 =  transform.FindChild(MOUNT1);
        this.mount2 = transform.FindChild(MOUNT2);
		currentWeapon = weapon1;
    }
	
	// Update is called once per frame
	void Update () {
        lastShot -= 1 * Time.deltaTime;
        
        if (lastShot <= 0 && Input.GetButton(FIRE1)) {
			fire();
        }
    }

	void fire()    {
		if (currentWeapon == null) {
			return;
		}
		if (currentWeapon.Equals(weapon1)) {
			currentWeapon = weapon2;
        } else {
			currentWeapon = weapon1;
        }

		AbstractWeapon weapon = currentWeapon.GetComponent<AbstractWeapon>();
		weapon.Fire (this.gameObject);
		lastShot = weapon.fireFrequency;
    }
}
