using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public TMP_Text p1NameLabel;
    public TMP_Text p2NameLabel;


    public void SetName(bool isP1, string newName)
    {
        if (isP1)
        {
            p1NameLabel.text = $"{newName}: <color=green>1$</color>";
        }
        else
        {
            p2NameLabel.text = $"{newName}: <color=green>1$</color>";
        }
    }
}
