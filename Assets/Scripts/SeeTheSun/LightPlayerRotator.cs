using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlayerRotator : MonoBehaviour {

    public float offset;
    public float factor;

    public Transform planet;
    public Transform player;

    public float playerAngle;
    private float maxAngle = float.MinValue;

    private void LateUpdate()
    {
        Vector3 playerVect = player.position - planet.position;
        Vector3 planetVect = Vector3.up - planet.position;

        playerVect = Vector3.ProjectOnPlane(playerVect, Vector3.right);
        planetVect = Vector3.ProjectOnPlane(planetVect, Vector3.right);

        playerAngle = Vector3.Angle(playerVect, planetVect);

        if (playerAngle > maxAngle) maxAngle = playerAngle;

        transform.localRotation = Quaternion.Euler(offset + maxAngle * factor, 0, 0);
        //transform.rotation = Quaternion.Euler(player.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z); 
    }

}
