using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MapBondary : MonoBehaviour 
{
    private BoxCollider2D col;          // The box collider that define the map limits

    public static MapBondary instance;  // Singleton
    public Bondary bondary;             // World postion of the bondary

    private void Awake()
    {
        instance = this;
        col = GetComponent<BoxCollider2D>();
        bondary = new Bondary(col.bounds.min.x, col.bounds.max.x, col.bounds.min.y, col.bounds.max.y);
    }

    // Destroy everything that exit the map bondary
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == null)
            return;
        
        Destroy(collision.gameObject);
    }
}

[System.Serializable]
public class Bondary
{
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;


    public Bondary(float xmin, float xmax, float ymin, float ymax)
    {
        xMin = xmin;
        xMax = xmax;
        yMin = ymin;
        yMax = ymax;
    }
}