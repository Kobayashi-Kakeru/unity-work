using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    GameObject timeText;
    

    // Start is called before the first frame update
    void Start()
    {
        this.timeText = GameObject.Find("Time");

    }

    // Update is called once per frame
    void Update()
    {
        
        float restTime = 30.0f - Time.time;
        this.timeText.GetComponent<Text>().text = restTime.ToString("n2");

        if (restTime <= 0)
        {
            SceneManager.LoadScene("GameClear");
        }
    }
}
