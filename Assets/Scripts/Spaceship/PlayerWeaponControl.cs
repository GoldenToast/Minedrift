using UnityEngine;
using System.Collections;
using Weapon;

public class PlayerWeaponControl : MonoBehaviour {

    private const string MOUNT1 = "Mount1";
    private const string MOUNT2 = "Mount2";
    private const string FIRE1 = "Fire1";
    private const string FIRE2 = "Fire2";

    public int playerNumber;

    public GameObject weaponPrefab;

    private Transform mount1;
    private Transform mount2;
    private Transform currentMount;

    private float lastShot;

    // Use this for initialization
    void Start () {
        this.mount1 =  transform.FindChild(MOUNT1);
        this.mount2 = transform.FindChild(MOUNT2);
        currentMount = mount1;
    }
	
	// Update is called once per frame
	void Update () {
        lastShot -= 1 * Time.deltaTime;
        if (playerNumber == 1)
        {
            if (lastShot <= 0 && Input.GetButton(FIRE1))
            {
                fire(weaponPrefab);
            }
        }
        if (playerNumber == 2)
        {
            if (lastShot <= 0 && Input.GetButton(FIRE2))
            {
                fire(weaponPrefab);
            }
        }

    }

	void fire(GameObject weaponPrefab)    {
		if (weaponPrefab == null) {
			return;
		}
        if (currentMount.Equals(mount1))
        {
            currentMount = mount2;
        }
        else
        {
            currentMount = mount1;
        }
		GameObject weaponObj = GameObject.Instantiate(weaponPrefab, currentMount.position, currentMount.rotation) as GameObject;
		weaponObj.tag = this.tag;
		AbstractWeapon weapon = weaponObj.GetComponent<AbstractWeapon>();
		lastShot = weapon.fireFrequency;
		weapon.Fire (this.gameObject);
    }
}
