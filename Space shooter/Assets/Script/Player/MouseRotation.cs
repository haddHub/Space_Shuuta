using UnityEngine;

public class MouseRotation : MonoBehaviour 
{
    private void Update()
    {
        // Direction from mouse to transform position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        direction.Normalize();

        // Angle of the rotation to apply at the transform
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, -angle);
    }
}