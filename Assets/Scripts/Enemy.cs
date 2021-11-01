using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int score;
    public int health;
    [HideInInspector]public Rigidbody2D enemyrb2d;
    [HideInInspector] public Transform PlayerPos;
    [HideInInspector] public TopDownShooter PlayerStats;
    [HideInInspector] public Vector2 movement;
    [HideInInspector] public SpriteRenderer sprrdr;
    public Sprite[] randomSprite;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyrb2d = GetComponent<Rigidbody2D>();
        sprrdr = GetComponent<SpriteRenderer>();
        sprrdr.sprite = randomSprite[Random.Range(0, randomSprite.Length)]; 
    }

    // Update is called once per frame
    void Update()
    {
        findPlayer();
        if (health == 0)
        {
            death();
        }
    }

    public virtual void findPlayer() {
        Vector2 direction = PlayerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        enemyrb2d.rotation = angle;
        direction.Normalize();
        enemyrb2d.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        movement = direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("PlayerBullet")) {
            health--;
            
        }
    }

    void death() {
        Destroy(gameObject);
        CoreGameManager.score += score;
        SpawnerNonEndless.limit++;
    }
}
