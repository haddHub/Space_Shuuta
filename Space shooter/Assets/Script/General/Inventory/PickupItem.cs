using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PickupItem : MonoBehaviour 
{
    [SerializeField]
    private Item item;
    private SpriteRenderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<SpriteRenderer>();

        if (item != null)
        {
            myRenderer.sprite = item.itemIcon;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        if (Inventory.instance.AddItem(item))
        {
            Destroy(gameObject);
        }
    }
}