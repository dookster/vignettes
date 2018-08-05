using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GrassPlanter : MonoBehaviour {

    public List<Transform> grass;

    public float radius = 5;
    public float sizeAdjust = 0.1f;

    public LayerMask groundLayer;

    public void RandomizeAllGrass()
    {
        foreach(Transform gt in grass)
        {
            gt.localPosition = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));
            gt.localEulerAngles = new Vector3(0, Random.Range(0, 360), 0);
            gt.localScale = Vector3.one * Random.Range(1f - sizeAdjust, 1f + sizeAdjust);
        }
    }

    public void PlaceOnGround()
    {
        RaycastHit hit;
        foreach (Transform gt in grass)
        {
            if (Physics.Raycast(gt.position + Vector3.up, Vector3.down, out hit, 10, groundLayer.value))
            {
                gt.position = hit.point;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(radius*2, 0.1f, radius * 2));
    }

}
