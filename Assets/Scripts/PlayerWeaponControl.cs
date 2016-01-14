using UnityEngine;
using System.Collections;

public class PlayerWeaponControl : MonoBehaviour {

    private const string MOUNT1 = "Mount1";
    private const string MOUNT2 = "Mount2";
    private const string FIRE = "Jump";

    public GameObject bulletPrefab;
    public float lifetime ;
    public float fireFrequency;

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
        if (lastShot <= 0 && Input.GetButton(FIRE)){
            fire(bulletPrefab);
        }
    }

    void fire(GameObject bulletPrefab)
    {
        if (currentMount.Equals(mount1))
        {
            currentMount = mount2;
        }
        else
        {
            currentMount = mount1;
        }
        lastShot = fireFrequency;
        GameObject bullet = GameObject.Instantiate(bulletPrefab, currentMount.position, currentMount.rotation) as GameObject;
        Destroy(bullet, lifetime);
    }
}
