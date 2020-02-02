using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int maxScore = 0;

    public GameObject litter;
    public GameObject gameMessage;
    public GameObject switches;

    public bool displayMessage = false;
    public float displayTime = 1;
    public string message;

    // Start is called before the first frame update
    void Start()
    {
        maxScore = litter.transform.childCount + switches.transform.childCount;

        displayMessage = true;
        displayTime = 7;
        message = "Pick up all the litter and put them into the right bin.\nTurn off all the taps and electronic appliances.";
    }

    // Update is called once per frame
    void Update()
    {
        displayTime -= Time.deltaTime;
        if (displayTime <= 0.0)
        {
            displayMessage = false;
        }

        if (score == maxScore)
        {
            Debug.Log("Win!");
            gameMessage.SetActive(true);
            Invoke("changeScene", 5);
        }
    }

    void OnGUI()
    {
        if (displayMessage)
        {
            GUI.contentColor = Color.black;
            GUI.Label(new Rect(Screen.width / 2 - 110, 50, 200f, 200f), message);
        }
    }

    void changeScene()
    {
        Debug.Log("change");
        SceneManager.LoadScene(0);
    }
}
