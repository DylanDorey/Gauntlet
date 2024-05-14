using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sap : MonoBehaviour, IEnemyBehavior
{
    private readonly float timeBetweenSap = 1f;
    private int sapsHit;

    public void Behavior(Enemy enemy)
    {
        StartCoroutine(StartSap());
    }

    public IEnumerator StartSap()
    {
        Death death = GetComponent<Death>();

        while (death.playerHealth != null)
        {
            death.hasSapped = true;

            death.playerHealth.playerHealth -= 10;
            sapsHit++;

            AudioManager.Instance.AddToSoundQueue(death.deathSapSound);

            if (sapsHit >= 20)
            {
                death.playerHealth = null;
                StopCoroutine(StartSap());
                death.OnDeath();
            }

            //add time to wait before sapping again
            yield return new WaitForSeconds(timeBetweenSap);
        }

        death.hasSapped = false;
    }
}
