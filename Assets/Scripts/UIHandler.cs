using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public TMP_Text p1NameLabel;
    public TMP_Text p2NameLabel;


    public void SetName(bool isP1, string newName, int pChar)
    {
        if (isP1)
        {
            p1NameLabel.text = $"<color=black>{newName}</color>";
        }
        else
        {
            p2NameLabel.text = $"<color=beige>{newName}</color>";
        }
    }
}
