using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private bool vertical;
    void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (vertical)
            {
                bullet.direction.x = - bullet.direction.x;
            }
            else
            {
                bullet.direction.z = - bullet.direction.z;
            }
        }
    }
}
