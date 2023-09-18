using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Shootable
{
    public override void TakeShot(RaycastHit hit)
    {
        base.TakeShot(hit);

        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        Debug.Log("Enemy shot");
    }
}
