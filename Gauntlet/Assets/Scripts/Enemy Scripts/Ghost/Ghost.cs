using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    [SerializeField] Transform positionTransform;
    private NavMeshAgent navMeshAgent;
    private bool _isChasingPlayer = false;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player").transform;
    }
}
