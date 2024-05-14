using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [5/08/2024]
 * [A door that ends the game]
 */

public class EndDoor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            //for each of the active players
            foreach (GameObject player in GameManager.Instance.players)
            {
                //set their active to false
                player.SetActive(false);
            }

            //publish the game over event
            GameEventBus.Publish(GameState.gameOver);
        }
    }
}
