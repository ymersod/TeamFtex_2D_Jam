using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float velocity;
    public PlayerType owner;
    public PlayerAvatar avatar;
    [SerializeField] private int ttl;

    void FixedUpdate()
    {
        Vector3 velocityVector = direction * velocity;
        GetComponent<Rigidbody>().linearVelocity = velocityVector;

        if (velocityVector.sqrMagnitude > 0.001f)
        {
            transform.right = -velocityVector.normalized;
        }

        ttl--;
        if (ttl <= 0)
        {
            Destroy(gameObject);
        }
    }

}
