using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycle : MonoBehaviour
{
    public GameObject litter;
    public GameObject inventory;
    public GameObject player;

    public string bin;

    public bool displayMessage = false;
    public float displayTime = 1;
    public string message; 

    // Start is called before the first frame update
    void Start()
    {
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            int lastChild = inventory.transform.childCount - 1;

            if (lastChild >= 0)
            {
                if (inventory.transform.GetChild(lastChild).gameObject.tag == bin)
                {
                    litter.GetComponent<Litter>().count -= 1;
                    Destroy(inventory.transform.GetChild(lastChild).gameObject);

                    player.transform.GetComponent<Score>().score += 1;

                    Debug.Log("Cleanup!");
                }
                else
                {
                    displayMessage = true;
                    displayTime = 1;
                    message = "Put it into the " + inventory.transform.GetChild(lastChild).gameObject.tag + " bin";
                }

            }   
        }
    }

    void OnGUI()
    {
        if (displayMessage)
        {
            GUI.contentColor = Color.black;
            GUI.Label(new Rect(Screen.width / 2 - 100, 20, 200f, 200f), message);
        }
    }
}
