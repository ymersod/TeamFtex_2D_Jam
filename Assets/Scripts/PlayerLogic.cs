using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public GameObject spawner;
    public string playerName;
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
            spawner.GetComponent<BulletSpawner>().Spawn(transform.position, lookingDirection, playerName);
        }
    }
}
