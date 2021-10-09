using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class advanceEnemy : Enemy
{
    public Transform FiringPoint;
    public GameObject bulletPF;
    public GameObject Drops;
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
        enemyShooting();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("PlayerBullet"))
        {
            Instantiate(Drops, transform.position, Quaternion.identity);
            Destroy(gameObject);
            TopDownShooter.score++;
        }
    }

    void enemyShooting() {
        if (FireRate <= 0)
        {
            GameObject homingbullet = Instantiate(bulletPF, FiringPoint.position, FiringPoint.rotation);
            FireRate = StartFireRate;
        }
        else {
            FireRate -= Time.deltaTime;
        }
        
    }
}
