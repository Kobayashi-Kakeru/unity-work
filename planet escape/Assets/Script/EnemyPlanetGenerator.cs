using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlanetGenerator : MonoBehaviour
{

    public GameObject planetPrefab;
    float delta = 0;
    float interval = 2.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > interval)
        {
            this.delta = 0;
            int point = Random.Range(-1, 2);
            float movespeed = Random.Range(20, 40);
            GameObject item = Instantiate(planetPrefab) as GameObject;
            item.transform.position = new Vector3(point*7.5f, 0,  100);
            item.GetComponent<EnemyPlanetController>().speed = movespeed * 0.01f;

        }
    }
}
