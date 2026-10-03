using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float velocity;
    public PlayerType owner;
    [SerializeField] private int ttl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().linearVelocity = direction * velocity;
        // Vector3 pos = transform.position;
        // pos.x += direction.x * velocity;
        // pos.y += direction.y * velocity;
        // transform.position = pos;
        ttl--;
        if (ttl == 0)
        {
            Destroy(gameObject);
        }
    }
}
