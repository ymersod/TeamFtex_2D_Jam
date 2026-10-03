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
        float halfZ = col.bounds.extents.z / 2;

        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + halfZ);
        GameObject houseSpawned = Instantiate(house);
        houseSpawned.transform.position = spawnPos;
    }

    public void TriggerSpot(PlayerType playerType)
    {
        if (spotActions == SpotActions.Buy && spotType == SpotType.Active)
        {
            BuildHouse(playerType);
        }
    }
}
