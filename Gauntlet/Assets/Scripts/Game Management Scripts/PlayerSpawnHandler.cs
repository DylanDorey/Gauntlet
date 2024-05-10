using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnHandler : MonoBehaviour
{
    private void Update()
    {
        OnPlayerJoined();
    }

    public void OnPlayerJoined()
    {
        switch (GameManager.Instance.characters)
        {
            case 0:
                GetComponent<PlayerInputManager>().playerPrefab = GameManager.Instance.playerPrefabs[0];
                break;

            case 1:
                GetComponent<PlayerInputManager>().playerPrefab = GameManager.Instance.playerPrefabs[1];
                break;

            case 2:
                GetComponent<PlayerInputManager>().playerPrefab = GameManager.Instance.playerPrefabs[2];
                break;

            //case 3:
            //    GetComponent<PlayerInputManager>().playerPrefab = playerPrefabs[2];
            //    break;
        }
    }
}
