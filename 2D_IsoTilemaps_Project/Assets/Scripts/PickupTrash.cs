using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrash : MonoBehaviour
{
    public GameObject inventory;
    public GameObject inventoryItem;

    public bool displayMessage = false;
    public float displayTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        inventory = transform.parent.GetComponent<Litter>().inventory;
    }

    // Update is called once per frame
    void Update()
    {
        displayTime -= Time.deltaTime;
        if (displayTime <= 0.0)
        {
            displayMessage = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        int count = transform.parent.GetComponent<Litter>().count;
        if (col.gameObject.tag == "Player" && count < 2)
        {
            Destroy(gameObject);
            transform.parent.GetComponent<Litter>().count += 1;

            Debug.Log("Pickup trash");
            Debug.Log(count + 1);

            GameObject icon = Instantiate(inventoryItem) as GameObject;
            icon.transform.SetParent(inventory.transform);
            icon.transform.localPosition = new Vector3((count) * 30, 1, 1);
            icon.transform.localScale = new Vector3(1, 1, 1);
        } 
        else if (count >= 2)
        {
            displayMessage = true;
            displayTime = 1;
        }
    }

    void OnGUI()
    {
        string message = "You only got 2 hands lol";
        if (displayMessage)
        {
            GUI.contentColor = Color.black;
            GUI.Label(new Rect(Screen.width / 2 - 100, 20, 200f, 200f), message);
        }
    }
}
