using UnityEngine;

public class CarMovement : MonoBehaviour {

    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;

    private float rotation;
    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        rotation = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate ()
    {
        rb.MovePosition(rb.position + transform.forward * (moveSpeed * Time.fixedDeltaTime));
        Vector3 yRotation = Vector3.up * (rotation * rotationSpeed * Time.fixedDeltaTime);
        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        var rotation1 = rb.rotation;
        Quaternion targetRotation = rotation1 * deltaRotation;
        rb.MoveRotation(Quaternion.Slerp(rotation1, targetRotation, 50f * Time.deltaTime));
    }

}