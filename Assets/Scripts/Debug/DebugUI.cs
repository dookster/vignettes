using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour {
    
    public Text fpsText;

	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        fpsText.text = "FPS: " + RoundToTwo(1f /Time.deltaTime);
	}

    float RoundToTwo(float number)
    {
        return Mathf.Round(number * 100) / 100f;
    }
}
