using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerLogic))]

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Vector3 walkingDirection;
    public float force;
    private BoardHandler boardHandler;
    int cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boardHandler = FindAnyObjectByType<BoardHandler>();

        cooldown = 0;
        walkingDirection = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(walkingDirection * force);
        if (GetComponent<Rigidbody>().linearVelocity.sqrMagnitude > 0.01)
        {
            GetComponent<PlayerLogic>().lookingDirection = GetComponent<Rigidbody>().linearVelocity.normalized;
        }
        if (cooldown > 0)
        {
            cooldown--;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        walkingDirection.x = context.ReadValue<Vector2>().x;
        walkingDirection.z = context.ReadValue<Vector2>().y;
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
