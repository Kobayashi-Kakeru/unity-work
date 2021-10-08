using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip sound;
    int hp = 4;
    [SerializeField] LifeStar lifeStar;
    ParticleSystem particle;

    public void Damage(int damage)
    {
        hp -= damage;
        //　0より下の数値にならないようにする
        hp = Mathf.Max(0, hp);

        if (hp >= 0)
        {
            lifeStar.SetLifeGauge(hp);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lifeStar.SetLifeGauge(hp);
        particle = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(this.transform.position.x > - 7.5f)
            {
                this.transform.Translate(-7.5f, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (this.transform.position.x < 7.5f)
            {
                this.transform.Translate(7.5f, 0, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            particle.Play();
            audioSource.PlayOneShot(sound);
            Damage(1);
            if (hp <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        
    }
}
