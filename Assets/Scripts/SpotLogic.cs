using TMPro;
using UnityEngine;
public class SpotLogic : MonoBehaviour
{
    public Color color;
    public float cost;
    public float rent;
    public string owner;
    public SpotActions spotActions;
    public SpotType spotType;
    public SpriteRenderer renderer;

    public GameObject house;

    private TMP_Text textp1;
    private TMP_Text textp2;


    void Start()
    {
        textp1 = GameObject.Find("p1Action").GetComponent<TMP_Text>();
        textp1.text = "";

        textp2 = GameObject.Find("p2Action").GetComponent<TMP_Text>();
        textp2.text = "";
    }

    public void ActivateSpot(PlayerType playerType)
    {
        renderer.color = Color.beige;
        if (playerType == PlayerType.p1)
        {
            // Debug.Log("ahhh");
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
        BoxCollider col = GetComponentInChildren<BoxCollider>();
        Vector3 center = col.bounds.center;
        float halfZ = col.bounds.extents.x;
        float halfY = col.bounds.extents.y;
        float halfX = col.bounds.extents.x;

        Vector3 spawnPos = new Vector3(center.x, 0.2f, center.z + halfZ);
        GameObject houseSpawned = Instantiate(house);
        houseSpawned.transform.position = spawnPos;
        houseSpawned.transform.rotation = Quaternion.Euler(-90, 90, 0);
    }

    public void TriggerSpot(PlayerType playerType)
    {
        if (spotActions == SpotActions.Buy && spotType == SpotType.Active)
        {
            BuildHouse(playerType);
        }
    }
}
