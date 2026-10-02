using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button button;

    [SerializeField]
    public string mainSceneName;

    void Start()
    {
        button.onClick.AddListener(OnClickStart);
    }

    void OnDestroy()
    {
        button.onClick.RemoveListener(OnClickStart);
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
