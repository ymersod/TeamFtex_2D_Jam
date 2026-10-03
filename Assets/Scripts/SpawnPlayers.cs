using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPlayers : MonoBehaviour
{
    public Vector3 playerSpawnPosition1;
    public Vector3 playerSpawnPosition2;
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private GameObject playerPrefeb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player1 = Instantiate(playerPrefeb, playerSpawnPosition1, Quaternion.identity);
        player1.GetComponentInChildren<PlayerInput>().SwitchCurrentActionMap("P1");
        player1.GetComponentInChildren<PlayerLogic>().playerType = PlayerType.p1;
        player1.GetComponentInChildren<PlayerLogic>().spawner = gameObject;
        GameObject player2 = Instantiate(playerPrefeb, playerSpawnPosition2, Quaternion.identity);
        player2.GetComponentInChildren<PlayerInput>().SwitchCurrentActionMap("P2");
        player2.GetComponentInChildren<PlayerLogic>().playerType = PlayerType.p2;
        player2.GetComponentInChildren<PlayerLogic>().spawner = gameObject;
    }
}
