using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/29/2024]
 * [Makes the main camera follow the first player that spawns in]
 */

public class FollowCam : MonoBehaviour
{
    //Follow cam variables
    public PlayerController player;
    private float targetPosx;
    private float targetPosz;
    private Vector3 targetPos;

    private void Update()
    {
        //if the game is in playing state and the player is initialized/spawned in
        if (GameManager.Instance.isPlaying && player != null)
        {
            //set the target x and z pos for the camera
            targetPosx = player.transform.position.x + 4f;
            targetPosz = player.transform.position.z - 4f;

            targetPos = new Vector3(targetPosx, transform.position.y, targetPosz);

            targetPos = new Vector3(targetPosx, 10f, targetPosz);
        }
    }

    private void FixedUpdate()
    {
        //if the game is in playing state and the player is initialized/spawned in
        if (GameManager.Instance.isPlaying && player != null)
        {
            //set the position of the camera to the target position
            transform.position = targetPos;
        }
    }

    /// <summary>
    /// Initializes the cameras target positions and player to follow
    /// </summary>
    public void InitializeCam()
    {
        //if the game is in playing state
        if (GameManager.Instance.isPlaying)
        {
            //find the player in the scene
            player = GameObject.FindObjectOfType<PlayerController>();

            //set the initial target position
            targetPosx = player.transform.position.x + 4f;
            targetPosz = player.transform.position.z - 4f;
            targetPos = new Vector3(targetPosx, 10f, targetPosz);
        }
    }
}
