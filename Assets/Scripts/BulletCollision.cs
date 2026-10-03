using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.GetComponent<Bullet>();
        if (bullet != null)
        {
            GetComponentInChildren<PlayerLogic>().GetHit(bullet);
        }

    }
}
