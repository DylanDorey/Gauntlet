using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/14/2024]
 * [The radius that enemies can start attacking and chasing in]
 */

public class AttackRadius : MonoBehaviour
{
    //the collided game object
    public Collider collide;

    private void Update()
    {
        //if collide is not empty
        if (collide != null)
        {
            //set the target position to collides position
            transform.gameObject.GetComponentInParent<Enemy>().targetPos = collide.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if other is a player
        if (other.gameObject.GetComponent<PlayerController>())
        {
            //set collide and set is aggro to true
            collide = other;
            transform.gameObject.GetComponentInParent<Enemy>().isAggro = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if other is a player
        if (other.gameObject.GetComponent<PlayerController>())
        {
            //set collide and set is aggro to false
            collide = null;
            transform.gameObject.GetComponentInParent<Enemy>().isAggro = false;
        }
    }
}
