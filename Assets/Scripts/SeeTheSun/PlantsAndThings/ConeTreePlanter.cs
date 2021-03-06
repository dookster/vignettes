﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeTreePlanter : MonoBehaviour {

    public List<ConeTree> trees;

    public float coneDistMin = 0.1f;
    public float coneDistMax = 0.35f;
    public float coneRotationMax = 12.5f;
    public float bottomMinHeight = 0.2f;
    public float bottomMaxHeight = 0.5f;
    public float minSizeAdjust = 0.5f;
    public float maxSizeAdjust = 1f;
    public float fullScaleMin = 0.5f;
    public float fullScaleMax = 1f;

    public LayerMask groundLayer;

    public void RandomizeAllTreesLook()
    {
        foreach(ConeTree ct in trees)
        {
            ct.RandomizeLook(coneRotationMax, coneDistMin, coneDistMax, bottomMinHeight, bottomMaxHeight, minSizeAdjust, maxSizeAdjust, fullScaleMin, fullScaleMax);
        }
    }

    public void PlaceOnGround()
    {
        RaycastHit hit;
        foreach (ConeTree ct in trees)
        {
            if (Physics.Raycast(ct.transform.position + Vector3.up, Vector3.down, out hit, 10, groundLayer.value))
            {
                ct.transform.position = hit.point;
            }
        }
    }



}
