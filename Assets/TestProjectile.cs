using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour {

	public GameObject projectile;
	public Transform projectileSpawn;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
			Fire ();
	}

	void Fire(){
		var proj = (GameObject)Instantiate (
			           projectile, projectileSpawn.position, projectileSpawn.rotation);

		projectile.GetComponent<Rigidbody> ().velocity = projectile.transform.forward * 5;

		Destroy (projectile, 2.0f);
	}
}
