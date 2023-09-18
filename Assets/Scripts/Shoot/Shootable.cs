using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shootable : MonoBehaviour
{
    public virtual void TakeShot(RaycastHit hit)
    {
    }
}
