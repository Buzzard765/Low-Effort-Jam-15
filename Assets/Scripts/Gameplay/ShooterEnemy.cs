using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    public Transform[] FiringPoint;
    public GameObject bulletPF;
    public GameObject Drops;
    public float bulletforce;

    public float StopDistance, BackwardDistance;    

    public float StartFireRate;
    private float FireRate;
    // Start is called before the first frame update
    void Start()
    {
        //FiringPoint = GameObject.Find("EnemyFP").GetComponentInChildren<Transform>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyrb2d = GetComponent<Rigidbody2D>();
        sprrdr = GetComponent<SpriteRenderer>();
        
        FireRate = StartFireRate;
    }

    // Update is called once per frame
    void Update()
    {
        findPlayer();
        if (health == 0)
        {
            death();
            Instantiate(Drops, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            health--;
        }
    }*/

    public virtual void enemyShooting() {       
            if (FireRate <= 0)
            {
                for (int i = 0; i < FiringPoint.Length; i++)
                {
                GameObject bullet = Instantiate(bulletPF, FiringPoint[i].position, FiringPoint[i].rotation);
                //Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
                //bulletRB.AddForce(FiringPoint[i].up * bulletforce, ForceMode2D.Impulse);
                FireRate = StartFireRate;
                }
            }
            else
            {
                FireRate -= Time.deltaTime;
            }
    }

    public virtual void findPlayer() {
        Vector2 direction = PlayerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        float FiringRange = Vector2.Distance(transform.position, PlayerPos.position);
        enemyrb2d.rotation = angle;
        direction.Normalize();        
        if (FiringRange > StopDistance)
        {
            //Move Towards Firing Range
            enemyrb2d.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));            
        }
        else
        {
            Debug.Log("onRange");
            enemyShooting();
            //enemyrb2d.transform.position = this.transform.position;
        }
        if (Vector2.Distance(transform.position, PlayerPos.position) < BackwardDistance)
        {
            Debug.Log("Retreating");
            enemyShooting();
            enemyrb2d.MovePosition((Vector2)transform.position - (direction * speed * Time.deltaTime));
        }
        movement = direction;
    }
}
