using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask notToHit;

    float timeToFire = 0;
    Transform firePoint;

	// Use this for initialization
    void Awake()
    {
        firePoint = transform.FindChild("FirePoint");
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
