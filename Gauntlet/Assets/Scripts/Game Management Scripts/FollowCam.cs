using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    private PlayerController player;
    private float targetPosx;
    private float targetPosz;
    private Vector3 targetPos;

    private void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerController>();
        targetPosx = player.transform.position.x;
        targetPosz = player.transform.position.z;

        targetPos = new Vector3(targetPosx, transform.position.y, targetPosz);
    }
    private void Update()
    {
        targetPosx = player.transform.position.x + 4f;
        targetPosz = player.transform.position.z - 4f;

        targetPos = new Vector3(targetPosx, transform.position.y, targetPosz);
    }

    private void FixedUpdate()
    {
        transform.position = targetPos;
    }
}
