using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchedProjectile : MonoBehaviour {

	private Collider[] hitObjects;

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "TowerPart"){
			hitObjects = Physics.OverlapSphere(transform.position, 2.5f);
			pushObjects(hitObjects);
		}
	}

	void pushObjects(Collider[] colls){
		foreach (Collider hit in colls){
			Rigidbody rb = hit.GetComponent<Rigidbody>();
			if (rb != null && rb.gameObject.tag == "TowerPart"){
				rb.AddExplosionForce(2f, transform.position, 2.5f, 1f);
			}
		}
	}
}
