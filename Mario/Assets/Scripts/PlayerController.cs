using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpForce;
    [SerializeField] GameObject text;
    GameObject gameobject;
    GameObject gameobject2;
    [SerializeField] GameObject button;
    private bool isMoving = false;
    private bool isJumping = false;
    private bool isFalling = false;

    private void Start()
    {
        this.gameobject = GameObject.Find("GameObject");
        this.gameobject2 = GameObject.Find("Mace");
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        isMoving = horizontal != 0;
        isFalling = rb.velocity.y < -0.5f;

        if (isMoving)
        {
            Vector3 scale = gameObject.transform.localScale;
            if (horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
            {
                scale.x *= -1;
            }
            gameObject.transform.localScale = scale;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isFalling)
        {
            Jump();
        }
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);

        if (rb.transform.position.y < -10)
        {
            text.SetActive(true);
            button.SetActive(true);
            Destroy(gameObject);
        }

        if(rb.transform.position.x > 16)
        {
            this.gameobject2.GetComponent<EnemyController>().ChangeKinematic();
        }
    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stage"))
        {
            isJumping = false;
        }

        if (collision.CompareTag("Enemy"))
        {
            text.SetActive(true);
            button.SetActive(true);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Coin"))
        {
            this.gameobject.GetComponent<UIController>().countUp();
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Finish");
        }
        if (collision.CompareTag("Living Enemy"))
        {
            text.SetActive(true);
            button.SetActive(true);
            Destroy(gameObject);
        }
    }
}