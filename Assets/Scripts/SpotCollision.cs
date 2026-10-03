using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SpotCollision : MonoBehaviour
{
    private BoardHandler boardHandler;
    public PlayerType playerType;

    [SerializeField] private Vector3 boxSizeMultiplier = Vector3.one;

    private Collider m_Collider;

    void Start()
    {
        boardHandler = FindAnyObjectByType<BoardHandler>();
        m_Collider = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        Vector3 center = m_Collider.bounds.center;
        Vector3 halfExtents = Vector3.Scale(m_Collider.bounds.extents, boxSizeMultiplier);

        Collider[] hits = Physics.OverlapBox(
            center,
            halfExtents,
            transform.rotation
        );


        float shortestDist = 100000;
        SpotLogic curSpot = null;
        foreach (Collider hit in hits)
        {
            if (hit == m_Collider)
                continue;

            SpotLogic spotLogic = hit.GetComponentInParent<SpotLogic>();
            if (spotLogic == null)
                continue;

            float newDist = Vector3.Distance(hit.transform.position, transform.position);
            if (newDist < shortestDist)
            {
                curSpot = spotLogic;
                shortestDist = newDist;
            }
        }

        if (curSpot)
            boardHandler.ActivateSpot(curSpot, playerType);
        else
            boardHandler.TryDeactivate(playerType);
    }

    void OnDrawGizmos()
    {
        if (m_Collider == null)
            m_Collider = GetComponent<Collider>();

        Gizmos.color = Color.red;

        Vector3 center = m_Collider.bounds.center;
        Vector3 size = Vector3.Scale(m_Collider.bounds.size, boxSizeMultiplier);

        Gizmos.matrix = Matrix4x4.TRS(center, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, size);
        Gizmos.matrix = Matrix4x4.identity;
    }
}

