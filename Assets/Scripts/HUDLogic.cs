using TMPro;
using UnityEngine;

public class HUDLogic : MonoBehaviour
{
    [SerializeField] private int maxAmmo;
    [SerializeField] private GameObject p1Monney;
    [SerializeField] private GameObject p1Ammo;
    [SerializeField] private GameObject p1Hp;
    [SerializeField] private GameObject p2Monney;
    [SerializeField] private GameObject p2Ammo;
    [SerializeField] private GameObject p2Hp;
    public GameObject p1;
    public GameObject p2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Debug.Log(p1Monney);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLogic p1Logic = p1.GetComponentInChildren<PlayerLogic>();
        if (p1Logic != null)
        {
            if (p1Logic.updateHud)
            {
                // Debug.Log(p1Monney.GetComponent<TMP_Text>().text);
                p1Monney.GetComponent<TMP_Text>().text = $"Money: <color=green>{p1Logic.money}$</color>";
                p1Ammo.GetComponent<TMP_Text>().text = $"Ammo: <color=yellow>{p1Logic.ammo}/{maxAmmo}$</color>";
                p1Hp.GetComponent<TMP_Text>().text = $"Money: <color=red>{p1Logic.health}$</color>";
                // p1.GetComponentInChildren<PlayerLogic>().updateHud = false;
            }
        }
        PlayerLogic p2Logic = p2.GetComponentInChildren<PlayerLogic>();
        if (p1Logic != null)
        {
            if (p2Logic.updateHud)
            {
                p2Monney.GetComponent<TMP_Text>().text = $"Money: <color=green>{p2Logic.money}$</color>";
                p2Ammo.GetComponent<TMP_Text>().text = $"Ammo: <color=yellow>{p2Logic.ammo}/{maxAmmo}$</color>";
                p2Hp.GetComponent<TMP_Text>().text = $"Money: <color=red>{p2Logic.health}$</color>";
                // p2.GetComponentInChildren<PlayerLogic>().updateHud = false;
            }
        }
    }
}
