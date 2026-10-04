using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet BulletPrefab;
    public Bullet greenBullet;
    public Bullet redBullet;
    public Bullet blueBullet;
    public void Spawn(Vector3 pos, Vector3 lookingDirection, PlayerType playerType, PlayerLogic playerLogic)
    {

        Bullet bullet = null;


        if (playerLogic.playerAvatar == PlayerAvatar.Thimble)
        {
            bullet = Instantiate(greenBullet, pos, Quaternion.identity);
        }
        else if (playerLogic.playerAvatar == PlayerAvatar.Car)
        {
            bullet = Instantiate(redBullet, pos, Quaternion.identity);
        }
        else if (playerLogic.playerAvatar == PlayerAvatar.Hat)
        {
            bullet = Instantiate(blueBullet, pos, Quaternion.identity);
        }

        bullet.avatar = playerLogic.playerAvatar;
        bullet.direction = lookingDirection;
        bullet.owner = playerType;
        if (playerType == PlayerType.p1)
        {
            bullet.gameObject.layer = 9;
        }
        else
        {
            bullet.gameObject.layer = 10;
        }
    }
}
