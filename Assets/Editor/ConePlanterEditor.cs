using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ConeTreePlanter))]
public class ConePlanterEditor : Editor {

    private ConeTreePlanter treePlanter;

    void OnEnable()
    {
        treePlanter = (ConeTreePlanter) target;
        treePlanter.trees = new List<ConeTree>(treePlanter.GetComponentsInChildren<ConeTree>());
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Randomize look"))
        {
            EditorGUI.BeginChangeCheck();

            treePlanter.RandomizeAllTreesLook();

            if (EditorGUI.EndChangeCheck())
            {

            }
        }

        if (GUILayout.Button("Place on ground"))
        {
            EditorGUI.BeginChangeCheck();

            treePlanter.PlaceOnGround();

            if (EditorGUI.EndChangeCheck())
            {

            }
        }
    }


}
