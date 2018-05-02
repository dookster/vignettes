using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {
	
	public float gravity = -9.8f;
	

	
	public void Attract(Rigidbody body, bool upToSurfaceNormal = false) {
		Vector3 gravityUp = (body.position - transform.position).normalized;
		Vector3 localUp = body.transform.up;

        // Apply downwards gravity to body
        //body.AddForce(gravityUp * gravity);

        Quaternion rotationToPlanetCenter = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation;

        if (!upToSurfaceNormal)
        {
            // Allign bodies up axis with the centre of planet
            body.rotation = rotationToPlanetCenter;
        }
        else
        {    
            // Align to the normal of surface under body (if diff between planet center and normal under threshold)
            Debug.DrawRay(body.position, transform.position - body.position, Color.cyan);
            Vector3 dir = transform.position - body.position;
            RaycastHit rh;
            if (Physics.Raycast(body.position, dir, out rh, 15, 1 << LayerMask.NameToLayer("Ground")))
            {
                Quaternion rotationToNormal = Quaternion.FromToRotation(localUp, rh.normal) * body.rotation;
                Quaternion targetRot;
                if (Quaternion.Angle(rotationToPlanetCenter, rotationToNormal) < 45f)
                {
                    targetRot = rotationToNormal;
                }
                else
                {
                    targetRot = rotationToPlanetCenter;
                }

                body.rotation = Quaternion.Slerp(body.rotation, targetRot, Time.deltaTime * 2.5f);
            }
        }

        body.AddForce(body.transform.up * gravity);
    }  
}
