using UnityEngine;

public class Wall : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.collider.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.direction = Vector3.Reflect(bullet.direction, collision.GetContact(0).normal);
            bullet.direction.y = 0;
            // Debug.Log(collision.GetContact(0).normal);
        }
    }
}
