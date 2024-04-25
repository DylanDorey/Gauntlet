using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadius : MonoBehaviour
{
    private Collider collider;

    private void Update()
    {
        if (collider != null)
        {
            transform.gameObject.GetComponentInParent<Enemy>().targetPos = collider.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            collider = other;
            transform.gameObject.GetComponentInParent<Enemy>().isAggro = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            collider = null;
            transform.gameObject.GetComponentInParent<Enemy>().isAggro = false;
        }
    }
}
