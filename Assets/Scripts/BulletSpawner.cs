using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet BulletPrefab;
    public void Spawn(Vector3 pos, Vector3 lookingDirection, PlayerType playerName)
    {
        Bullet bullet = Instantiate(BulletPrefab, pos, Quaternion.identity);
        bullet.direction = lookingDirection;
        bullet.owner = playerName;
    }
}
