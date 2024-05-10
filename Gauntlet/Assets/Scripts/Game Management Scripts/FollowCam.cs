using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    private PlayerController player;
    private float targetPosx;
    private float targetPosz;
    private Vector3 targetPos;

    private float minCameraSize = 8f;
    private float maxCameraSize = 12f;

    private void OnEnable()
    {
        GameEventBus.Subscribe(GameState.startGame, InitializeCam);
    }

    private void OnDisable()
    {
        GameEventBus.Unsubscribe(GameState.startGame, InitializeCam);
    }

    private void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            targetPosx = player.transform.position.x + 4f;
            targetPosz = player.transform.position.z - 4f;

            targetPos = new Vector3(targetPosx, transform.position.y, targetPosz);

            //CheckScreenBounds();
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.isPlaying)
        {
            transform.position = targetPos;
        }
    }

    private void InitializeCam()
    {
        player = GameObject.FindObjectOfType<PlayerController>();

        targetPosx = player.transform.position.x + 4f;
        targetPosz = player.transform.position.z - 4f;

        targetPos = new Vector3(targetPosx, 10f, targetPosz);
    }

    private void CheckScreenBounds()
    {
        for (int index = 0; index < GameManager.Instance.players.Count; index++)
        {
            if (GameManager.Instance.players[index].gameObject.transform.position.x > targetPos.x + Camera.main.orthographicSize || GameManager.Instance.players[index].gameObject.transform.position.x < targetPos.x + Camera.main.orthographicSize)
            {
                Camera.main.orthographicSize += 0.1f;

                if (Camera.main.orthographicSize > maxCameraSize)
                {
                    Camera.main.orthographicSize = maxCameraSize;
                }
            }

            if (GameManager.Instance.players[index].gameObject.transform.position.z > targetPos.z + Camera.main.orthographicSize || GameManager.Instance.players[index].gameObject.transform.position.z < targetPos.z + Camera.main.orthographicSize)
            {
                Camera.main.orthographicSize += 0.1f;

                if (Camera.main.orthographicSize > maxCameraSize)
                {
                    Camera.main.orthographicSize = maxCameraSize;
                }
            }
        }

        //if (Camera.main.orthographicSize < minCameraSize)
        //{
        //    Camera.main.orthographicSize = minCameraSize;
        //}
    }
}
