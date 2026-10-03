using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet BulletPrefab;
    public void Spawn(Vector3 pos, Vector3 lookingDirection, PlayerType playerType)
    {
        Bullet bullet = Instantiate(BulletPrefab, pos, Quaternion.identity);
        bullet.direction = lookingDirection;
        bullet.owner = playerType;
        if (playerType == PlayerType.p1)
        {
            bullet.gameObject.GetComponent<SphereCollider>().includeLayers = 0b01000000000;
        }
        else
        {
            bullet.gameObject.GetComponent<SphereCollider>().includeLayers = 0b10000000000;
        }
    }
}
