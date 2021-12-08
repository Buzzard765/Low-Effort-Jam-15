using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : Bullet
{
    private Rigidbody2D bulletRB;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletRB.AddRelativeForce(Vector2.up * bulletforce, ForceMode2D.Impulse);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.GetComponent<Enemy>().health--;
            }
            else if (collision.gameObject.name.Contains("Shield")) {
                collision.GetComponent<Shield>().HP--;
            }
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.GetComponent<TopDownShooter>().health--;
            }
            Destroy(gameObject);
        }*/
        
    }

}
