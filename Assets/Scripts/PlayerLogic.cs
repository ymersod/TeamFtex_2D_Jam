using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public GameObject spawner;
    public PlayerType playerType;
    public Vector2 lookingDirection;
    public int money;
    public int health;
    public int ammo;
    public bool inJail;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {
        if (ammo > 0 && !inJail)
        {
            // Debug.Log("PlayerLogic.Shoot()");
            spawner.GetComponent<BulletSpawner>().Spawn(transform.position, lookingDirection, playerType);
            ammo--;
        }
    }

    public void GetHit(Bullet bullet)
    {
        if (playerType != bullet.owner)
        {
            Debug.Log($"{playerType} got hit by {bullet.owner}");
            health--;
            Destroy(bullet.gameObject);
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
