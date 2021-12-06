using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy : ShooterEnemy
{

    private float FireRate;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyrb2d = GetComponent<Rigidbody2D>();
        sprrdr = GetComponent<SpriteRenderer>();
        
        FireRate = StartFireRate;
    }

    // Update is called once per frame
    void Update()
    {
        findPlayer();
    }

    void SpecialShoot() {
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("PlayerBullet"))
        {
            Instantiate(Drops, transform.position, Quaternion.identity);
            Destroy(gameObject);
            CoreGameManager.score += score;
            SpawnerNonEndless.limit+=1;
        }
    }

    public override void enemyShooting() {
        if (FireRate <= 0)
        {
            for (int i = 0; i < FiringPoint.Length; i++)
            {
                GameObject bullet = Instantiate(bulletPF, FiringPoint[i].position, FiringPoint[i].rotation);
                //Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
                //bulletRB.AddForce(FiringPoint[i].up * bulletforce, ForceMode2D.Impulse);
                //bullet.transform.position = Vector2.MoveTowards(FiringPoint[i].position, PlayerPos.position, 1 * Time.deltaTime);
                FireRate = StartFireRate;
            }
        }
        else
        {
            FireRate -= Time.deltaTime;
        }
    }
}
