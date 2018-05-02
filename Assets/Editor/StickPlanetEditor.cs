using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StickToPlanet))]
[CanEditMultipleObjects()]
public class StickPlanetEditor : Editor {

    private StickToPlanet stickObject;

    void OnEnable()
    {
        stickObject = (StickToPlanet)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Put on planet!"))
        {
            EditorGUI.BeginChangeCheck();

            //GameObject planet = GameObject.FindGameObjectWithTag("Planet");
            //Vector3 newPos = stickObject.GetSurfacePos();

            //Undo.RecordObject(stickObject.transform, "Placed on planet - position");
            //stickObject.transform.position = newPos;

            //Vector3 gravityUp = (stickObject.transform.position - planet.transform.position).normalized;
            //Vector3 localUp = stickObject.transform.up;

            //Undo.RecordObject(stickObject.transform, "Placed on planet - rotation");
            //stickObject.transform.rotation = Quaternion.FromToRotation(localUp, gravityUp) * stickObject.transform.rotation;

            Undo.RecordObject(stickObject.transform, "Placed on planet - rotation");
            stickObject.StickToSurface();

            if (EditorGUI.EndChangeCheck())
            {
            }
        }
        
    }

}
