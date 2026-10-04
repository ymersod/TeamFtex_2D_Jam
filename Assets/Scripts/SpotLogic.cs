using TMPro;
using UnityEngine;
public class SpotLogic : MonoBehaviour
{
    public Color color;
    public float cost;
    public float rent;
    public PlayerType owner;
    public bool owned = false;
    public SpotActions spotActions;
    public SpotType spotType;
    public SpriteRenderer renderer;
    public SpotState spotState = SpotState.NoBuild;
    public FreeMoneySigns freeMoneyDirection;
    private GameObject building;

    public GameObject house_prefab;
    public GameObject hotel_prefab;

    private TMP_Text textp1;
    private TMP_Text textp2;


    void Start()
    {
        textp1 = GameObject.Find("p1Action").GetComponent<TMP_Text>();
        textp1.text = "";

        textp2 = GameObject.Find("p2Action").GetComponent<TMP_Text>();
        textp2.text = "";
    }

    public void ActivateSpot(PlayerLogic playerLogic)
    {
        PlayerType playerType = playerLogic.playerType;
        renderer.color = Color.beige;

        if (spotType == SpotType.Passive && spotActions == SpotActions.Start && playerLogic.nextMoneySign == freeMoneyDirection)
        {
            Debug.Log(freeMoneyDirection);
            playerLogic.money += (int)cost;

            if (freeMoneyDirection == FreeMoneySigns.NorthEast)
                playerLogic.nextMoneySign = FreeMoneySigns.SouthWest;
            if (freeMoneyDirection == FreeMoneySigns.SouthWest)
                playerLogic.nextMoneySign = FreeMoneySigns.NorthEast;

            Debug.Log(playerLogic.nextMoneySign);
        }

        if (playerType == PlayerType.p1 && spotType == SpotType.Active)
        {
            textp1.text = $"<color=green>{spotActions} [X]";
        }
        else
            textp2.text = $"<color=green>{spotActions} [ENTER]";
    }

    public void DeactivateSpot(PlayerType playerType)
    {
        renderer.color = Color.white;
        if (playerType == PlayerType.p1)
            textp1.text = "";
        else
            textp2.text = "";
    }


    private void BuildHouse(PlayerType playerType)
    {
        if (owned && owner != playerType)
        {
            owned = true;
            owner = playerType;
        }

        GameObject prefabChosen;
        if (spotState == SpotState.NoBuild)
        {
            spotState = SpotState.HouseBuild;
            prefabChosen = house_prefab;
        }
        else if (spotState == SpotState.HouseBuild && building)
        {
            spotState = SpotState.HotelBuild;
            prefabChosen = hotel_prefab;
            Destroy(building);
        }
        else
        {
            Debug.Log($"Cant buy a house for player ${playerType}");
            return;
        }

        Transform spawn = transform.GetChild(1);
        Debug.Log(spawn.transform.rotation.z);

        float yBoundsPrefab = prefabChosen.GetComponent<MeshRenderer>().bounds.extents.y;
        Debug.Log(yBoundsPrefab);
        Vector3 spawnPos = new Vector3(spawn.position.x, prefabChosen.transform.position.y + yBoundsPrefab, spawn.position.z);
        GameObject houseSpawned = Instantiate(prefabChosen);
        houseSpawned.transform.SetPositionAndRotation(spawnPos, Quaternion.Euler(-90, 90 + spawn.transform.rotation.eulerAngles.z, 0));
        if (spotState == SpotState.HouseBuild)
        {
            houseSpawned.GetComponent<HouseLogic>().owner = playerType;
        }
        else if (spotState == SpotState.HotelBuild)
        {
            houseSpawned.GetComponent<HotelLogic>().owner = playerType;
        }
        building = houseSpawned;
    }

    public void TriggerSpot(PlayerLogic playerLogic)
    {
        PlayerType playerType = playerLogic.playerType;
        if (spotActions == SpotActions.Buy && spotType == SpotType.Active)
        {
            BuildHouse(playerType);
        }
    }
}
