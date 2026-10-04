using UnityEngine;

public class DiceLogic : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float impulseForce = 5f;
    [SerializeField] private float torqueForce = 2f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Vector3 hitDirection = other.attachedRigidbody != null
                ? other.attachedRigidbody.linearVelocity.normalized
                : (transform.position - other.transform.position).normalized;

            // Add upward force
            hitDirection += Vector3.up * 0.5f;
            hitDirection.Normalize();

            rb.AddForce(hitDirection * impulseForce, ForceMode.Impulse);

            Vector3 torque = Vector3.Cross(hitDirection, Vector3.up).normalized;
            rb.AddTorque(torque * torqueForce, ForceMode.Impulse);

            Debug.Log(other.tag);
            Destroy(other.gameObject);
        }
    }
}

