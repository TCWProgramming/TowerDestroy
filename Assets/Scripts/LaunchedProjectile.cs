using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LaunchedProjectile : MonoBehaviour {

	private Collider[] hitObjects;

	void OnCollisionEnter(Collision coll){
		hitObjects = Physics.OverlapSphere(transform.position, 2.5f);
		
		foreach (Collider hit in hitObjects){
			Destroy(hit.gameObject);
		}
	}
}
