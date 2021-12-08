using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Bloweffect;
    Rigidbody2D bulletRB;
    public float bulletforce;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();       
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Bullet")) {
            GameObject blow = Instantiate(Bloweffect, transform.position, Quaternion.identity);
            Destroy(blow, 5f);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Player"))
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
                if (collision.gameObject.name.Contains("Stealth")) {
                    StealthEnemy StealthCheck = collision.GetComponent<StealthEnemy>();

                }
                collision.GetComponent<TopDownShooter>().health--;
            }
            Destroy(gameObject);
        }

    }

}
