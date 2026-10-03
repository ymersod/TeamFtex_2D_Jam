using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public float velocity;
    public string owner;
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
        Vector3 pos = transform.position;
        pos.x += direction.x * velocity;
        pos.y += direction.y * velocity;
        transform.position = pos;
        ttl --;
        if (ttl == 0)
        {
            Destroy(gameObject);
        }
    }
}
