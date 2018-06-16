using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragProjectile : MonoBehaviour {

    // Use this for initialization
    public Vector3 projectileVec;
    private Vector3 oldVec;
    private bool projectileUp;
    
    public Rigidbody projectile, projectile_clone;
    public float projectile_dist = 5f;
    public float force = 2000f;
    public float additionalForce = 0;
    public float Force_multiplier1 = 200;
    public float Force_multiplier2 = 100;

    void Start () {
        projectileUp = false;
        projectileVec = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        GetPosition();
        if (projectileUp)
        {
            if(projectile_clone == null)
            {
                projectile_clone = (Rigidbody)Instantiate(projectile, this.transform.position, this.transform.rotation);
            }
            projectile_clone.transform.position = this.transform.position;

            if (Input.GetMouseButtonUp(0))
            {
                LaunchProjectile();
                projectileUp = false;
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
        oldVec = projectileVec;
        projectileVec = Input.mousePosition;
        projectileVec.z = projectile_dist;
        this.transform.position = Camera.main.ScreenToWorldPoint(projectileVec);

       // Debug.Log(projectileVec - oldVec);
    }
    void LaunchProjectile()
    {
        Vector3 initialLaunch = -transform.right + transform.up; // Based on ah_scene xyz orientation--Could change 
        Vector3 vec_diff = projectileVec - oldVec;
        Debug.Log(projectileVec - oldVec);
        //initialLaunch += vec_diff;
        if (vec_diff.y > 130)
        {
            Force_multiplier1 = 30;
        }
        else if (vec_diff.y > 50)
        {
            Force_multiplier1 = 15;
        }
        else if(vec_diff.y > 20)
        {
            Force_multiplier1 = 10;
        }
        else
        {
            Force_multiplier1 = 1;
        }
        additionalForce = vec_diff.y * Force_multiplier1;
        projectile_clone.AddForce((initialLaunch)*(force + additionalForce), ForceMode.Force);
    }
}
