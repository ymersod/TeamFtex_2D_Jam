using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public GameObject spawner;
    public PlayerType playerType;
    public PlayerAvatar playerAvatar;
    public Vector3 lookingDirection;
    public int money;
    public int health;
    public int ammo;
    public bool inJail;
    public bool updateHud;

    void Start()
    {
        updateHud = true;
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
            Debug.Log(health);
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Debug.Log("Kill");
        Destroy(gameObject);
    }


}
