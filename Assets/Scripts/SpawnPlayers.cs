using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPlayers : MonoBehaviour
{
    public Vector3 playerSpawnPosition1;
    public Vector3 playerSpawnPosition2;
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private GameObject playerPrefeb;
    [SerializeField] private GameObject thimblePlayer;
    [SerializeField] private GameObject carPlayer;
    [SerializeField] private GameObject hatPlayer;
    [SerializeField] private GameObject hud;

    GameObject[] playerList = new GameObject[3];



    void Start()
    {
        playerList[0] = carPlayer;
        playerList[1] = thimblePlayer;
        playerList[2] = hatPlayer;




        int p1Char = PlayerPrefs.GetInt("p1_char");
        PlayerAvatar avatar1 = (PlayerAvatar)p1Char;
        // Debug.Log(avatar1);

        GameObject prefabFoundP1 = null;
        foreach (GameObject prefabVariant in playerList)
        {
            // Debug.Log(prefabVariant.GetComponentInChildren<PlayerLogic>().playerAvatar);
            if (prefabVariant.GetComponentInChildren<PlayerLogic>().playerAvatar == avatar1)
            {
                prefabFoundP1 = prefabVariant;
            }
        }

        int p2Char = PlayerPrefs.GetInt("p2_char");
        PlayerAvatar avatar2 = (PlayerAvatar)p2Char;

        GameObject prefabFoundP2 = null;
        foreach (GameObject prefabVariant in playerList)
        {
            if (prefabVariant.GetComponentInChildren<PlayerLogic>().playerAvatar == avatar2)
            {
                prefabFoundP2 = prefabVariant;
            }
        }

        if (prefabFoundP1 == null || prefabFoundP2 == null)
        {
            Debug.Log("OOF");
            return;
        }



        GameObject player1 = Instantiate(prefabFoundP1, playerSpawnPosition1, Quaternion.identity);
        player1.GetComponentInChildren<PlayerInput>().SwitchCurrentActionMap("P1");
        player1.GetComponentInChildren<PlayerLogic>().playerType = PlayerType.p1;
        player1.GetComponentInChildren<PlayerLogic>().spawner = gameObject;
        player1.GetComponentInChildren<PlayerLogic>().nextMoneySign = FreeMoneySigns.NorthEast;
        player1.transform.rotation = Quaternion.Euler(0, 0f, 180f);

        player1.layer = 7;
        hud.GetComponent<HUDLogic>().p1 = player1;


        GameObject player2 = Instantiate(prefabFoundP2, playerSpawnPosition2, Quaternion.identity);
        player2.GetComponentInChildren<PlayerInput>().SwitchCurrentActionMap("P2");
        player2.GetComponentInChildren<PlayerLogic>().playerType = PlayerType.p2;
        player2.GetComponentInChildren<PlayerLogic>().spawner = gameObject;
        player2.GetComponentInChildren<PlayerLogic>().nextMoneySign = FreeMoneySigns.SouthWest;
        player2.layer = 8;
        hud.GetComponent<HUDLogic>().p2 = player2;

    }
}
