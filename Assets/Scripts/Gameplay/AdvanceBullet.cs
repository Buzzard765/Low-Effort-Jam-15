using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceBullet : Bullet
{
    Rigidbody2D bulletRB;
    public GameObject SpreadBullet;
    public GameObject[] SpreadPoint;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletRB.AddRelativeForce(Vector2.up * bulletforce, ForceMode2D.Impulse);
        //bulletRB.velocity = Vector2.up * Time.deltaTime;       
        StartCoroutine(DelayedExplosion(5f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {       
        if (collision.gameObject.name.Contains("Bullet"))
        {
            GameObject blow = Instantiate(Bloweffect, transform.position, Quaternion.identity);
            //DelayedExplosion();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy's Bullet");
            if (collision.gameObject.name.Contains("PlayerBullet")) {
                Debug.Log("Hit");
                StartCoroutine(DelayedExplosion(0f));
            }
        }
        else {
            Debug.Log("Player Bullet");
        }
    }
    IEnumerator DelayedExplosion(float delay) {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < SpreadPoint.Length; i++) {
            Instantiate(SpreadBullet, SpreadPoint[i].transform.position, SpreadPoint[i].transform.rotation);
        }
        Destroy(gameObject);
    }
}
