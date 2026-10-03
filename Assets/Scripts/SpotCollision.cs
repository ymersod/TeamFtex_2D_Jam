using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SpotCollision : MonoBehaviour
{
    private BoardHandler boardHandler;
    public SpotLogic spotLogic;

    Collider m_Collider;
    RaycastHit m_Hit;

    void Start()
    {
        boardHandler = FindAnyObjectByType<BoardHandler>();
        m_Collider = GetComponent<Collider>();
    }

    void Update()
    {
        // m_HitDetect = Physics.BoxCastAll(m_Collider.bounds.center, transform.localScale * 0.5f, transform.forward, out m_Hit, transform.rotation, m_MaxDistance);
    }

    void OnTriggerEnter(Collider other)
    {
        string name = other.name;
        PlayerType playerType;

        print(name);

        if (name == "p1")
        {
            playerType = PlayerType.p1;
        }
        else if (name == "p2")
        {
            playerType = PlayerType.p2;
        }
        else
        {
            return;
        }

        boardHandler.ActivateSpot(spotLogic, playerType);
    }
}
