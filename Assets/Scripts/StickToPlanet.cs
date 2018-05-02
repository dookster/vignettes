using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stick the object to the surface of the planet at game start (optionally in the editor)
/// </summary>
public class StickToPlanet : MonoBehaviour
{


	void Start ()
    {
        StickToSurface();
	}
	
	
	void Update ()
    {
		
	}

    public void StickToSurface()
    {
        GameObject planet = GameObject.FindGameObjectWithTag("Planet");

        Vector3 newPos = transform.position;

        RaycastHit rh;
        Debug.DrawRay(transform.position, planet.transform.position - transform.position, Color.red, 2f);
        Vector3 dir = planet.transform.position - transform.position;
        if (Physics.Raycast(transform.position, dir, out rh, 15, 1 << LayerMask.NameToLayer("Ground")))
        {
            newPos = rh.point;
            transform.position = newPos;
            //transform.SetParent(rh.collider.transform, true);

            

            Vector3 gravityUp = (transform.position - planet.transform.position).normalized;
            //Vector3 surfaceUp = (transform.position - planet.transform.position).normalized;
            Vector3 localUp = transform.up;

            //transform.rotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;
            transform.rotation = Quaternion.FromToRotation(localUp, rh.normal) * transform.rotation;
        }

    }

    public Vector3 GetSurfacePos()
    {
        GameObject planet = GameObject.FindGameObjectWithTag("Planet");

        Vector3 newPos = transform.position;

        RaycastHit rh;
        Debug.DrawRay(transform.position, planet.transform.position - transform.position, Color.red, 2f);
        Vector3 dir = planet.transform.position - transform.position;
        if (Physics.Raycast(transform.position, dir, out rh, 15, 1 << LayerMask.NameToLayer("Ground")))
        {
            //transform.position = rh.point;
            newPos = rh.point;
            //transform.SetParent(rh.collider.transform, true);
        }

        //Vector3 gravityUp = (transform.position - planet.transform.position).normalized;
        //Vector3 localUp = transform.up;
        //transform.rotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;

        return newPos;
    }

}
