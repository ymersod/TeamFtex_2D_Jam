using UnityEngine;

public class HotelLogic : MonoBehaviour
{
    public PlayerType owner;
    public int health;

    void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.collider.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.direction = Vector3.Reflect(bullet.direction, collision.GetContact(0).normal);
            GetHit(bullet);
            // Debug.Log(collision.GetContact(0).normal);
        }
    }

    public void GetHit(Bullet bullet)
    {
        if (owner != bullet.owner)
        {
            Debug.Log($"The house of {owner} got hit by {bullet.owner}");
            health--;
            bullet.owner = owner;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
