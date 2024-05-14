using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        foreach (GameObject player in GameManager.Instance.players)
        {
            player.SetActive(false);
        }

        GameEventBus.Publish(GameState.gameOver);
    }
}
