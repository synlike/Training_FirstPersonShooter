using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private LayerMask mask;
    private InputManager inputManager;


    void Start()
    {
        inputManager = GetComponent<InputManager>();
    }

    public void DoFire()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, mask))
        {
            Shootable shootable = hit.collider.GetComponent<Shootable>();

            shootable.TakeShot(hit);
        }
    }
}
