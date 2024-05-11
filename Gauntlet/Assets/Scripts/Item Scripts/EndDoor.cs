using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameEventBus.Publish(GameState.gameOver);
    }
}
