using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GrassPlanter))]
public class GrassPlanterEditor : Editor {

    private GrassPlanter grassPlanter;

    void OnEnable()
    {
        grassPlanter = (GrassPlanter)target;
        grassPlanter.grass = new List<Transform>(grassPlanter.GetComponentsInChildren<Transform>());
        grassPlanter.grass.Remove(grassPlanter.transform);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Randomize placement"))
        {
            EditorGUI.BeginChangeCheck();

            grassPlanter.RandomizeAllGrass();

            if (EditorGUI.EndChangeCheck())
            {

            }
        }

        if (GUILayout.Button("Place on ground"))
        {
            EditorGUI.BeginChangeCheck();

            grassPlanter.PlaceOnGround();

            if (EditorGUI.EndChangeCheck())
            {

            }
        }
    }


}
