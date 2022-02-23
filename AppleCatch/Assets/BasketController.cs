using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource audioSource;
    GameObject Director;

    private void Start()
    {
        this.Director = GameObject.Find("GameDirector");
        this.audioSource = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Apple")
        {
            this.Director.GetComponent<GameDirector>().GetApple();
            this.audioSource.PlayOneShot(this.appleSE);
            Debug.Log("Apple");
        }
        else
        {
            this.Director.GetComponent<GameDirector>().GetBomb();
            this.audioSource.PlayOneShot(this.bombSE);
            Debug.Log("BOMB");
        }
        Destroy(other.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0.0f, z);
            }
        }
    }
}
