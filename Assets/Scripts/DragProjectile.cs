using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragProjectile : MonoBehaviour {

    // Use this for initialization
    public Vector3 projectileVec;
    private bool projectileUp;
    //public GameObject projectilePosition;
    public Rigidbody projectile, projectile_clone;
    public float projectile_dist = 5f;

	void Start () {
        projectileUp = false;
	}
	
	// Update is called once per frame
	void Update () {

        GetPosition();
        if (projectileUp)
        {
            projectile_clone.transform.position = this.transform.position;

            if (Input.GetMouseButtonUp(0))
            {
                projectileUp = false;
                LaunchProjectile();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            projectileUp = true;
            CreateProjectile();

        }
	}

    void CreateProjectile()
    {
        projectile_clone = (Rigidbody)Instantiate(projectile, this.transform.position, this.transform.rotation);

    }
    void GetPosition()
    {
        projectileVec = Input.mousePosition;
        projectileVec.z = projectile_dist;
        this.transform.position = Camera.main.ScreenToWorldPoint(projectileVec);

        //Debug.Log(projectileVec);
    }
    void LaunchProjectile()
    {

    }
}
