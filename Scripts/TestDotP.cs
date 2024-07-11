using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDotP : MonoBehaviour
{
    public Transform playerTransform, portalTransform;



    public float dp;

    private void Update()
    {
        dp = Vector3.Dot(portalTransform.position, playerTransform.position);
    }
}
