﻿using UnityEngine;
using System.Collections;

public class MeleeWeapon : MonoBehaviour {


    public int damage;

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation *= Quaternion.Euler(new Vector3(0, 5, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Laser enters " + other);
        if (other.tag.Equals(Tags.PLAYER))
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
