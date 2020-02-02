using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void home()
    {
        Debug.Log("click");
        SceneManager.LoadScene(0);
    }

    public void change()
    {
        Debug.Log("click");
        SceneManager.LoadScene(1);
    }
}
