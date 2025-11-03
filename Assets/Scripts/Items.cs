using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Items : MonoBehaviour
{
    [SerializeField] private Image itemImageHolder;
    private UIText ui;
    private shoot shoot;
    private List<Color> items = new List<Color>();
    private int activeItemIndex = -1;


    ShipMovement shipmovement;
    // Start is called before the first frame update
    void Start()
    {
        shipmovement = GetComponent<ShipMovement>();
        ui = FindObjectOfType<UIText>();
        shoot = GetComponent<shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        CycleItems();
        UseItem();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            PickUpItem(other.gameObject);
        }
    }
    void PickUpItem(GameObject item)
    {

        Color color = item.gameObject.GetComponent<Renderer>().material.color;

        Destroy(item);

        items.Add(color);

        activeItemIndex = items.Count - 1;

        itemImageHolder.color = items[activeItemIndex];
        itemImageHolder.enabled = true;
    }

    void CycleItems()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (items.Count > 0)
            {
                if (activeItemIndex < items.Count - 1)
                {
                    activeItemIndex++;
                }
                else
                {
                    activeItemIndex = 0;
                }
                itemImageHolder.color = items[activeItemIndex];
            }
            else
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }
    }
    void UseItem()
    {

        if (Input.GetKeyDown(KeyCode.E) && items.Count > 0 && activeItemIndex != -1)
        {

            if (items[activeItemIndex] == Color.blue)
            {
                StartCoroutine(ui.DisplayText(" +  Move Speed", 3f));
                shipmovement.moveSpeed += 5;
            }
            else if (items[activeItemIndex] == Color.red)
            {
                StartCoroutine(ui.DisplayText(" + Fire Rate", 3f));
                shoot.cooldownTime -= 0.1f;
            }
            else if (items[activeItemIndex] == Color.green)
            {
                StartCoroutine(ui.DisplayText(" + Rotation Speed", 3f));
                shipmovement.rotationSpeed += 20;
            }
            items.RemoveAt(activeItemIndex);
            if (activeItemIndex > 0)
            {
                activeItemIndex--;
                itemImageHolder.color = items[activeItemIndex];
            }
            else if (items.Count == 0)
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }

        }
    }
}
