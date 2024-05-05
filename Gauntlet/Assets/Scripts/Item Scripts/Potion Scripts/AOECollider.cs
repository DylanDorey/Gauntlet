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
        Vector3 scaleFactor = new Vector3(3f, 3f, 3f);
        transform.localScale = scaleFactor;

        for (int index = 0; index < 4; index++)
        {
            transform.localScale += scaleFactor;

            yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);
    }
}
