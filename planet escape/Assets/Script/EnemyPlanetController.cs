using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlanetController : MonoBehaviour
{
    public float speed = 0.3f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -1*speed);
        if(transform.position.z < -1)
        {
            Destroy(gameObject);
        }
    }
}
