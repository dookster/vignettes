using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeTree : MonoBehaviour {

    public Transform[] cones;

    public Transform trunk;

    public Transform[] branches;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void RandomizeLook(float maxRot, float minDist, float maxDist, float minBottomHeight, float maxBottomHeight, float minSize, float maxSize, float fullScaleMin, float fullScaleMax)
    {
        //Vector3 lastConePos = new Vector3(0, Random.Range(minBottomHeight, maxBottomHeight), 0);
        //float lastSize = 1f;
        //Vector3 lastRotation = new Vector3(-90, 0, 0);

        cones[0].localEulerAngles = Vector3.zero;
        cones[0].localScale = Vector3.one;
        cones[0].localPosition = Vector3.zero;

        // middle cones
        for (int n = 0; n < cones.Length; n++)
        {
            cones[n].localEulerAngles = new Vector3(Random.Range(-maxRot, maxRot), Random.Range(0f, 360f), Random.Range(-maxRot, maxRot));
            cones[n].localPosition = new Vector3(0, Random.Range(minDist, maxDist), 0);
            cones[n].localScale = Vector3.one * Random.Range(minSize, maxSize);
        }
     
        // whole tree
        transform.localScale = Vector3.one * Random.Range(fullScaleMin, fullScaleMax);
        trunk.localEulerAngles = new Vector3(-90 + Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(0, 360));

        // branches
        foreach(Transform branch in branches)
        {
            branch.gameObject.SetActive(Random.Range(0, 2) == 0);
        }
    }


}
