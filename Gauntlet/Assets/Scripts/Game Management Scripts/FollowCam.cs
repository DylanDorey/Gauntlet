using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public PlayerController player;
    private float targetPosx;
    private float targetPosz;
    private Vector3 targetPos;

    private void Start()
    {
        //transform.position = new Vector3(0f, 10f, 0f);
    }

    private void Update()
    {
        if (GameManager.Instance.isPlaying && player != null)
        {
            targetPosx = player.transform.position.x + 4f;
            targetPosz = player.transform.position.z - 4f;

            targetPos = new Vector3(targetPosx, 10f, targetPosz);
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.isPlaying && player != null)
        {
            transform.position = targetPos;
        }
    }

    public void InitializeCam()
    {
        if (GameManager.Instance.isPlaying)
        {
            player = GameObject.FindObjectOfType<PlayerController>();

            targetPosx = player.transform.position.x + 4f;
            targetPosz = player.transform.position.z - 4f;

            targetPos = new Vector3(targetPosx, 10f, targetPosz);
        }
    }
}
