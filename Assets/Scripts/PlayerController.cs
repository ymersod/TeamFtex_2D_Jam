using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerLogic))]
public class PlayerController : MonoBehaviour
{
    private Vector2 walkingDirection;
    private BoardHandler boardHandler;
    public float velocity;
    int cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boardHandler = FindAnyObjectByType<BoardHandler>();

        cooldown = 0;
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
        if (cooldown > 0)
        {
            cooldown--;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        walkingDirection = context.ReadValue<Vector2>();
        if (walkingDirection.sqrMagnitude > 0.99)
        {
            GetComponent<PlayerLogic>().lookingDirection = context.ReadValue<Vector2>();
        }
        // Debug.Log($"Input Move: {walkingDirection}");
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.action.IsPressed() && cooldown == 0)
        {
            // Debug.Log("PlayerController.OnShoot()");
            GetComponent<PlayerLogic>().Shoot();
            cooldown = 2;
        }
    }

    public void OnAction(InputAction.CallbackContext context)
    {
        if (context.action.IsPressed() && cooldown == 0)
        {
            boardHandler.TriggerActionActiveSpot(GetComponent<PlayerLogic>().playerType);
            cooldown = 2;
        }
    }
    // void OnCollisionEnter(Collision collision)
    // {
    //     Debug.Log(collision.thisGameObject.GetComponent<Bullet>());

    // }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.GetComponent<Bullet>());
        Bullet bullet = other.GetComponent<Bullet>();
        if (bullet != null)
        {
            GetComponent<PlayerLogic>().GetHit(bullet);
        }
    }
}
