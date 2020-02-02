using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite switched;
    public bool isSwitched = false;

    public GameObject litter;
    public GameObject inventory;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        litter = transform.parent.GetComponent<Furniture>().litter;
        inventory = transform.parent.GetComponent<Furniture>().inventory;
        player = transform.parent.GetComponent<Furniture>().player;

        if (isSwitched == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = switched;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && isSwitched == false)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = switched;
            isSwitched = true;

            player.transform.GetComponent<Score>().score += 1;

            Debug.Log("Switch!");
        }
    }
}
