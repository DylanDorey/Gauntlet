using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sap : MonoBehaviour, IEnemyBehavior
{
    public void Behavior(Enemy enemy)
    {
        StartCoroutine(StartSap());
    }

    private IEnumerator StartSap()
    {
        Death death = GetComponent<Death>();
        death.hasSapped = true;

        AudioManager.Instance.AddToSoundQueue(death.deathSapSound);

        //add time to wait before sapping again
        yield return null;

        death.hasSapped = false;
    }
}
