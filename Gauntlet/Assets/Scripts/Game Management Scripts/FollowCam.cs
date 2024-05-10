using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    private PlayerController player;
    private float targetPosx;
    private float targetPosz;
    private Vector3 targetPos;

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

        targetPos = new Vector3(targetPosx, transform.position.y, targetPosz);
    }
}
