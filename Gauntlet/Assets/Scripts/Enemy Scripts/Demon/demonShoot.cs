using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonShoot : MonoBehaviour
{
    private readonly float shootDistance = 3f;
    public float shootDelay = 2f;
    private Vector3 _rayDirection;
    public RaycastHit shot;
    public bool hasShot;

    private void Start()
    {
        _rayDirection = transform.forward;
        Destroy(gameObject, shootDelay);
    }

    private void FixedUpdate()
    {
        transform.Translate(_rayDirection * Time.deltaTime * shootDistance, Space.World);

        if (Physics.Raycast(transform.position, _rayDirection, out shot, shootDistance))
        {
            Debug.Log("Bullet Test");
        }
    }
}
