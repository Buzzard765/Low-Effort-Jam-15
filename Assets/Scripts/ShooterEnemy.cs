﻿using System.Collections;
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
        sprrdr.sprite = randomSprite[Random.Range(0, randomSprite.Length)];
        FireRate = StartFireRate;
    }

    // Update is called once per frame
    void Update()
    {
        findPlayer();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("PlayerBullet"))
        {
            Instantiate(Drops, transform.position, Quaternion.identity);
            Destroy(gameObject);
            CoreGameManager.score += score;
            SpawnerNonEndless.limit++;
        }
    }

    void enemyShooting() {       
            if (FireRate <= 0)
            {
                for (int i = 0; i < FiringPoint.Length; i++)
                {
                GameObject bullet = Instantiate(bulletPF, FiringPoint[i].position, FiringPoint[i].rotation);
                Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
                bulletRB.AddForce(FiringPoint[i].up * bulletforce, ForceMode2D.Impulse);
                FireRate = StartFireRate;
                }
            }
            else
            {
                FireRate -= Time.deltaTime;
            }
    }

    public override void findPlayer() {
        Vector2 direction = PlayerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        enemyrb2d.rotation = angle;
        direction.Normalize();
        
        if (Vector2.Distance(transform.position, PlayerPos.position) > StopDistance)
        {
            //Move Towards Firing Range
            enemyrb2d.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
            
        }
        else if (Vector2.Distance(transform.position, PlayerPos.position) < StopDistance && Vector2.Distance(transform.position, PlayerPos.position) > BackwardDistance)
        {
            enemyShooting();
            enemyrb2d.transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, PlayerPos.position) < BackwardDistance)
        {
            enemyShooting();
            enemyrb2d.MovePosition((Vector2)transform.position - (direction * speed * Time.deltaTime));
        }
        movement = direction;
    }
}