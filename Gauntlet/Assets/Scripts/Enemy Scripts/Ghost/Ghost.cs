using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;

public class Ghost : Enemy
{
    private bool _isChasingPlayer = false;
    private Transform player;

    //private void Update()
    //{
    //    if (_isChasingPlayer && player != null)
    //    { 
    //        transform.LookAt(player);
    //        transform.Translate(Vector3.forward * Time.deltaTime * 1f);
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        player = other.transform;
    //        _isChasingPlayer = true;
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        _isChasingPlayer = false;
    //    }
    //}
}
