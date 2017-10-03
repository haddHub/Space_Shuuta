using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour 
{
    [SerializeField]
    private float moveSpeed;    // Move speed

    private Rigidbody2D rb;     // My rigidbody2d
    private Collider2D col;     // Collider 2d, can be any type of collider2d
    private Bondary mapBondary; // Limits of the map
    private Vector2 sizeOffset; // Offset caused by the size of the sprite
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        mapBondary = MapBondary.instance?.bondary;
        sizeOffset = new Vector2(col.bounds.size.x / 2f, col.bounds.size.y / 2f);
    }

    private void FixedUpdate()
    {
        // Read the current input
        float[] movementInputs = ReadMovementInputs();
        Vector3 movement = new Vector3(movementInputs[0], movementInputs[1], 0f);
        // Apply inputs to the velocity
        rb.velocity = movement * moveSpeed * Time.deltaTime;

        // Limit the player position to not exit the map limits
        if (mapBondary != null)
        {
            transform.position = MapLimitedPositions();
        }
    }

    private float[] ReadMovementInputs()
    {
        return new float[] { Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") };
    }

    private Vector2 MapLimitedPositions()
    {
        return new Vector2
               (Mathf.Clamp(rb.position.x, mapBondary.xMin + sizeOffset.x, mapBondary.xMax - sizeOffset.x),
               Mathf.Clamp(rb.position.y, mapBondary.yMin + sizeOffset.y, mapBondary.yMax - sizeOffset.y));
    }
}