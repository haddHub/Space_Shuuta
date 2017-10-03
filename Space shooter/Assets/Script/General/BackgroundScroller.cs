using UnityEngine;

public class BackgroundScroller : MonoBehaviour 
{
    [SerializeField]
    private float tileSize;
    [SerializeField]
    private float scrollSpeed;

    private Vector3 startPosition;  // Position of the background at the start of the level

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        transform.position = startPosition + Vector3.up * newPosition;
    }
}