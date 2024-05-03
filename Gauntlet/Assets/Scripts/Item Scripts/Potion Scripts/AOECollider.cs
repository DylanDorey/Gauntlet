using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [05/02/2024]
 * [The radius collider for potions that removes enemies]
 */
public class AOECollider : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(IncreaseSize());
    }

    private void OnTriggerEnter(Collider other)
    {  
        if (other.transform.GetComponent<Enemy>())
        {
            Destroy(other.gameObject);
        }
    }

    private IEnumerator IncreaseSize()
    {
        SphereCollider aoeSize = GetComponent<SphereCollider>();

        aoeSize.radius = 0f;

        for (int index = 0; index < 4; index++)
        {
            aoeSize.radius += 4f;

            yield return new WaitForSeconds(0.2f);
        }

        gameObject.SetActive(false);
    }
}
