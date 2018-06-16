using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LaunchedProjectile : MonoBehaviour {

	private Collider[] hitObjects;
    public float r = 2.5f;
    public GameObject explodeEffect;
    private GameObject explInstance;

	void OnCollisionEnter(Collision coll){
		hitObjects = Physics.OverlapSphere(transform.position, r);
        explInstance = Instantiate(explodeEffect, transform.position, Quaternion.identity);

		
		foreach (Collider hit in hitObjects){
			Destroy(hit.gameObject);
		}

        Invoke("StopParticles", 1.5f);
        Destroy(this.gameObject);

	}

    void StopParticles()
    {
        Destroy(explInstance);
    }
}
