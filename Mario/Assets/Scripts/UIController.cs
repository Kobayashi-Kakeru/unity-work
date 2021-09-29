using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    GameObject gameobject;
    GameObject button;
    GameObject ctext;
    int point = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.gameobject = GameObject.Find("gameoverText");
        this.button = GameObject.Find("resetButton");
        this.ctext = GameObject.Find("coinText");
        this.gameobject.SetActive(false);
        this.button.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        this.ctext.GetComponent<Text>().text = this.point.ToString() + "/3 coin";
    }

    public void revive()
    {
        SceneManager.LoadScene("Stage");
    }

    public void countUp()
    {
        this.point += 1;
    }
}
