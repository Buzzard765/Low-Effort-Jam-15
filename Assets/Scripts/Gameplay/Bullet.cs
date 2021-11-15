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

        bulletRB.AddRelativeForce(Vector2.up * bulletforce, ForceMode2D.Impulse);
        //bulletRB.velocity = Vector2.up * Time.deltaTime;       
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject blow = Instantiate(Bloweffect, transform.position, Quaternion.identity);
        Destroy(blow, 5f);
        Destroy(gameObject);
    }
}
