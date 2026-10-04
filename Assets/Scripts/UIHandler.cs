using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public TMP_Text p1NameLabel;
    public TMP_Text p2NameLabel;


    public void SetName(bool isP1, string newName, int pChar)
    {
        string color = "blue";
        if (pChar == 0)
        {
            color = "green";
        }
        else if (pChar == 1)
        {
            color = "red";
        }
        else if (pChar == 2)
        {
            color = "blue";
        }

        if (isP1)
        {
            p1NameLabel.text = $"<color={color}>{newName}</color>";
        }
        else
        {
            p2NameLabel.text = $"<color={color}>{newName}</color>";
        }
    }
}
