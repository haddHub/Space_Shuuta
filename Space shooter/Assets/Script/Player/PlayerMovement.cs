using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour 
{
    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float[] movementInputs = ReadMovementInputs();
        Vector3 movement = new Vector3(movementInputs[0], movementInputs[1], 0f);

        rb.velocity = movement * moveSpeed * Time.deltaTime;
    }

    private float[] ReadMovementInputs()
    {
        return new float[] { Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") };
    }
}