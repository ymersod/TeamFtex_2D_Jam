using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button button;
    public Button p1_Ready;
    public TMP_InputField p1_Name;
    public Button p2_Ready;
    public TMP_InputField p2_Name;

    [SerializeField]
    public string mainSceneName;

    private string p1_name;
    private string p2_name;

    private bool p1_ready;
    private bool p2_ready;

    void Start()
    {
        CheckForStart();
        button.onClick.AddListener(OnClickStart);
        p1_Ready.onClick.AddListener(P1Ready);
        p2_Ready.onClick.AddListener(P2Ready);
        p1_Name.onValueChanged.AddListener(UpdateP1Name);
        p2_Name.onValueChanged.AddListener(UpdateP2Name);
    }

    void OnDestroy()
    {
        button.onClick.RemoveListener(OnClickStart);
    }

    void P1Ready()
    {
        p1_ready = !p1_ready;
        CheckForStart();
    }
    void P2Ready()
    {
        p2_ready = !p2_ready;
        CheckForStart();
    }

    void UpdateP1Name(string newText)
    {
        p1_name = newText;
    }

    void UpdateP2Name(string newText)
    {
        p2_name = newText;
    }

    void CheckForStart()
    {
        if (p1_ready && p2_ready)
        {
            button.enabled = true;
            button.interactable = true;
        }
        else
        {
            button.enabled = false;
            button.interactable = false;
        }
    }

    public void OnClickStart()
    {
        PlayerPrefs.SetString("p1_name", p1_name);
        PlayerPrefs.SetString("p2_name", p2_name);
        PlayerPrefs.SetInt("p1_char", 1);
        PlayerPrefs.SetInt("p2_char", 1);

        Debug.Log($"Player1: {p1_name}");
        Debug.Log($"Player2: {p2_name}");

        SceneManager.LoadScene("MainScene");
    }

}
