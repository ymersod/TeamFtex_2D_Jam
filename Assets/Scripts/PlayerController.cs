using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerLogic))]

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Vector3 walkingDirection;
    private BoardHandler boardHandler;
    [SerializeField] float turnForce = 10f;

    [SerializeField] float force = 10f;
    int cooldown;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        boardHandler = FindAnyObjectByType<BoardHandler>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        cooldown = 0;
        walkingDirection = new Vector3(0, 0, 0);

    }

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Rigidbody rbParent = transform.parent.GetComponent<Rigidbody>();

        float z = transform.eulerAngles.z * Mathf.Deg2Rad;

        Vector2 facingDirection = new Vector2(
            -Mathf.Cos(z),
            Mathf.Sin(z)
        );

        spriteRenderer.flipX = z < -90f || z > 90f;

        GetComponent<PlayerLogic>().lookingDirection = new Vector3(facingDirection.x, 0, -facingDirection.y);

        if (Mathf.Abs(walkingDirection.y) > 0.01f)
        {
            rbParent.AddForce(
               force * facingDirection.x * walkingDirection.y, 0, force * -facingDirection.y * walkingDirection.y,
               ForceMode.Force
           );
        }

        rb.position = rbParent.position;
        if (Mathf.Abs(walkingDirection.x) > 0.01f)
        {
            rb.AddTorque(
                0,
                0,
                turnForce * -walkingDirection.x,
                ForceMode.Force
            );
        }

        if (cooldown > 0)
        {
            cooldown--;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {

        walkingDirection.x = context.ReadValue<Vector2>().x;
        walkingDirection.y = context.ReadValue<Vector2>().y;
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.action.IsPressed() && cooldown == 0)
        {
            // Debug.Log("PlayerController.OnShoot()");
            GetComponent<PlayerLogic>().Shoot();
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger("Shoot");
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
}
