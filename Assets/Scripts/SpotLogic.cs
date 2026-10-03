using UnityEngine;

public class SpotLogic : MonoBehaviour
{
    public Color color;
    public float cost;
    public float rent;
    public string owner;
    public SpotActions spotActions;
    public SpriteRenderer renderer;

    void Start()
    {

    }

    public void ActivateSpot(PlayerType playerType)
    {
        renderer.color = Color.beige;
    }

    public void DeactivateSpot(PlayerType playerType)
    {
        renderer.color = Color.white;
    }


}
