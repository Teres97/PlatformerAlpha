using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : Enemy
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 15f;

    public static Hero Instance {get; set;}
    public override void GetDamage()
    {
        lives--;
        Debug.Log(lives);
        if (lives < 1){
            Die();
            SceneManager.LoadScene("MainMenu");
        }
    }

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;

    private bool isGrounded = false;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Run(){
        Vector3 dir = transform.right * Input.GetAxis("Horizontal"); 
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        spriteRenderer.flipX = dir.x < 0.0f;
    }
    private void FixedUpdate() {
        CheckGround();
    }
    private void Update() {
        if(Input.GetButton("Horizontal")){
            Run();
        }
        if(isGrounded && Input.GetButtonDown("Vertical")){
            Jump();
        }
        if(Input.GetKey("escape")){
            SceneManager.LoadScene("MainMenu");
        }
        if(transform.position.y < -30)
            SceneManager.LoadScene("MainMenu");
    }

    private void CheckGround(){
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }

    private void Jump(){
        rigidbody.AddForce( transform.up * jumpForce, ForceMode2D.Impulse);
    }
}
