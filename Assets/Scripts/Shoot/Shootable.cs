using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shootable : MonoBehaviour
{
    public static event Action<Shootable, RaycastHit> OnTookShoot = (shootable, hit) => { };

    public virtual void TakeShot(RaycastHit hit)
    {
        OnTookShoot(this, hit);
    }
}
