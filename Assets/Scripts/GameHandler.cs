using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private UIHandler uIHandler;
    public string p1Name = "";
    public string p2Name = "";
    public int p1Char = -1;
    public int p2Char = -1;
    void Start()
    {
        p1Name = PlayerPrefs.GetString("p1_name");
        p2Name = PlayerPrefs.GetString("p2_name");
        p1Char = PlayerPrefs.GetInt("p1_char");
        p2Char = PlayerPrefs.GetInt("p2_char");


        uIHandler.SetName(true, p1Name);
        uIHandler.SetName(false, p2Name);
    }
}
