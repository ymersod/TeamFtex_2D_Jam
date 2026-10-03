using TMPro;
using UnityEngine;
public class SpotLogic : MonoBehaviour
{
    public Color color;
    public float cost;
    public float rent;
    public string owner;
    public SpotActions spotActions;
    public SpriteRenderer renderer;

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
            textp1.text = $"<color=green>{spotActions} [X]";
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


}
