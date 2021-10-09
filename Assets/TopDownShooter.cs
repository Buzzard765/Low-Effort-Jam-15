using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooter : MonoBehaviour
{
    public float movespeed;
    private Rigidbody2D rb2d;
    Vector2 movement, mousePos;
    private Camera cam;
    static public int health;
    public  int maxhealth;
    
    public int highscore;
    public static int score;
    public Joystick js;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        rb2d = GetComponent<Rigidbody2D>();
        js = FindObjectOfType<Joystick>();
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);      
        Debug.Log(score);
    }

    private void FixedUpdate()
    {
        movementControl();
        if (health == 0) {            
            Destroy(gameObject, 3f);
        }
    }

    void movementControl() {
        //movement.x = js.Horizontal * movespeed;
        //movement.y = js.Vertical * movespeed;
        rb2d.MovePosition(rb2d.position + movement * movespeed * Time.deltaTime);
        Vector2 lookDir = mousePos - rb2d.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = angle;       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy")) {
            health--;
            Destroy(collision.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Shield"))
        {
            if (health >= maxhealth)
            {
                health = maxhealth;
            }
            else
            {
                health++;
            }
            Destroy(collision.gameObject);
        }

    }

}
