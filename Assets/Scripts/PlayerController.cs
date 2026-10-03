using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerLogic))]
public class PlayerController : MonoBehaviour
{
    private Vector2 walkingDirection;
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
            GetComponent<PlayerLogic>().lookingDirection = context.ReadValue<Vector2>();
        }
        Debug.Log($"Input Move: {walkingDirection}");
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.action.IsPressed())
        {
            Debug.Log("PlayerController.OnShoot()");
            GetComponent<PlayerLogic>().Shoot();
        }
    }
}
