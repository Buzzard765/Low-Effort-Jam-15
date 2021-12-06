using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShielderEnemy : Enemy
{
    [SerializeField]private Shield Shielding;
    public float StopDistance, BackwardDistance;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyrb2d = GetComponent<Rigidbody2D>();
        sprrdr = GetComponent<SpriteRenderer>();
        try
        {
            Shielding = GetComponentInChildren<Shield>();
        }
        catch {
            Debug.Log("No Shield");
        }
        Shielding.gameObject.SetActive(false);
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

    public override void findPlayer()
    {
        Vector2 direction = PlayerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        float ShieldingRange = Vector2.Distance(transform.position, PlayerPos.position);
        //int BoostedHealth = (health + Shielding.HP);
        enemyrb2d.rotation = angle;
        direction.Normalize();
        if (ShieldingRange > StopDistance)
        {
            //Move Towards Firing Range
            enemyrb2d.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        }
        else
        {
            Debug.Log("onRange");
            Shielding.gameObject.SetActive(true);
            //health = BoostedHealth;
            //enemyrb2d.transform.position = this.transform.position;
        }
        if (Vector2.Distance(transform.position, PlayerPos.position) < BackwardDistance)
        {
            Debug.Log("Retreating");
            //Shielding.gameObject.SetActive(false);
            enemyrb2d.MovePosition((Vector2)transform.position - (direction * speed * Time.deltaTime));
        }
        movement = direction;
    }
}
