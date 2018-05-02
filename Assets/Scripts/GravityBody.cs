using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour {

    [Header("Rotate up to surface normal under collision")]
    public bool UpToNormal = false;

	GravityAttractor planet;
	Rigidbody rigBody;
	
	void Awake () {
		planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
		rigBody = GetComponent<Rigidbody> ();

		// Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
		rigBody.useGravity = false;
		rigBody.constraints = RigidbodyConstraints.FreezeRotation;
	}
	
	void FixedUpdate () {
		// Allow this body to be influenced by planet's gravity
		planet.Attract(rigBody, UpToNormal);
	}

    private void LateUpdate()
    {
        
    }
    
    private void Update()
    { 
        
    } 
}