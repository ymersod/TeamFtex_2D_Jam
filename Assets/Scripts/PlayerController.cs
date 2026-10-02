using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public string playerName;
    [SerializeField] private Bullet BulletPrefab;
    private Vector2 walkingDirection;
    [SerializeField] private Vector2 lookingDirection;
    public float velocity;
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
        pos.x += walkingDirection.x * velocity;
        pos.y += walkingDirection.y * velocity;
        transform.position = pos;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        walkingDirection = context.ReadValue<Vector2>();
        if (walkingDirection.sqrMagnitude > 0.99)
        {
            lookingDirection = context.ReadValue<Vector2>();
        }
        Debug.Log($"Input Move: {walkingDirection}");
    }

    public void OnShot(InputAction.CallbackContext context)
    {
        if (context.action.IsPressed())
        {
            Debug.Log("Shot");
            Bullet bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
            bullet.direction = lookingDirection;
        }
    }
}
