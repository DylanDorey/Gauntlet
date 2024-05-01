using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererBlink : MonoBehaviour, IEnemyBehavior
{
    public bool hasBlinked = false;
    public float blinkDuration = 3f;

    public void Behavior(Enemy enemy)
    {
        StartCoroutine(InitiateBlink(enemy));
    }

    public IEnumerator InitiateBlink(Enemy enemy)
    {
        while (true)
        {
            int randomNum = Random.Range(0, 2);

            switch (randomNum)
            {
                case 0:
                    yield return new WaitForSeconds(Random.Range(3.1f, 10f));
                    break;

                case 1:
                    StartCoroutine(Blink(enemy));
                    yield return new WaitForSeconds(Random.Range(3.1f, 10f));
                    break;
            }
        }
    }

    public IEnumerator Blink(Enemy enemy)
    {
        if (!hasBlinked)
        {
            hasBlinked = true;

            for (int index = 0; index < enemy.transform.childCount - 1; index++)
            {
                enemy.transform.GetChild(index).GetComponent<MeshRenderer>().enabled = false;
            }

            yield return new WaitForSeconds(blinkDuration);
        }

        hasBlinked = false;

        for (int index2 = 0; index2 < enemy.transform.childCount - 1; index2++)
        {
            enemy.transform.GetChild(index2).GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
