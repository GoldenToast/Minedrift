using UnityEngine;
using System.Collections;

public class EnemyMeleeControl : MonoBehaviour {

    public GameObject weaponPrefab;

    private const string MOUNT1 = "Mount1";
    private Transform mount1;
    private GameObject saw;

    // Use this for initialization
    void Start () {
        this.mount1 = transform.FindChild(MOUNT1);
        saw = Instantiate(weaponPrefab, mount1.position, mount1.rotation) as GameObject;
        saw.transform.SetParent(mount1);
    }
	
	// Update is called once per frame
	void Update () {
               
    }
}
