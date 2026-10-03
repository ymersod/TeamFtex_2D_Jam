using UnityEngine;

public class HouseLogic : MonoBehaviour
{
    public PlayerType owner;
    public int health;

    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(other.GetComponent<Bullet>());
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            GetHit(bullet);
        }
    }

    public void GetHit(Bullet bullet)
    {
        if (owner != bullet.owner)
        {
            Debug.Log($"The house of {owner} got hit by {bullet.owner}");
            health--;
            if (health <= 0)
            {
                Die();
            }
        }
        Destroy(bullet.gameObject);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
