using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Player : MonoBehaviour
{
    public float speed = 5.0f;//control the speed
    private Rigidbody2D rb;
    public bool isDead = false;
    public GameManager gameManager;
    Audio audioManager;
    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio>();
    }

    void Start()
    {
        //get rigibody2d Component of the BirdbBek
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetMouseButtonDown(0) --> left side mouse button pressed down
        if(Input.GetMouseButtonDown(0)){
            rb.velocity = Vector2.up * speed;
        }
    }

  

    private void OnCollisionEnter2D(Collision2D other) {
    isDead = true;
    if (gameManager != null) {
        audioManager.PlaySFX(audioManager.wallTouch);
        gameManager.GameOver();
    } else {
        Debug.LogError("GameManager not assigned in Player script");
    }
}

    
    
}
