using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadius : MonoBehaviour
{
    private Collider collide;

    private void Update()
    {
        if (collide != null)
        {
            transform.gameObject.GetComponentInParent<Enemy>().targetPos = collide.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            collide = other;
            transform.gameObject.GetComponentInParent<Enemy>().isAggro = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            collide = null;
            transform.gameObject.GetComponentInParent<Enemy>().isAggro = false;
        }
    }
}
