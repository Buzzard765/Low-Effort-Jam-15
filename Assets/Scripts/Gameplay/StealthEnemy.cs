using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthEnemy : ShooterEnemy
{
    private Collider2D coll;

    private float FireRate;
    bool onCloak;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();

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
            //Instantiate(Drops, transform.position, Quaternion.identity);
        }
    }

    public override void findPlayer()
    {
        //base.findPlayer();
        Vector2 direction = PlayerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        float FiringRange = Vector2.Distance(transform.position, PlayerPos.position);
        enemyrb2d.rotation = angle;
        direction.Normalize();
        if (FiringRange > StopDistance)
        {
            //Move Towards Firing Range
            enemyrb2d.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
            Cloaking(true);
        }
        else
        {
            Debug.Log("onRange");
            enemyShooting();
            Cloaking(false);
            //enemyrb2d.transform.position = this.transform.position;
        }
        if (Vector2.Distance(transform.position, PlayerPos.position) < BackwardDistance)
        {
            Debug.Log("Retreating");
            Cloaking(true);
            enemyrb2d.MovePosition((Vector2)transform.position - (direction * speed * Time.deltaTime));
        }
    }

    void Cloaking(bool onCloak) {
        Debug.Log(onCloak, this.gameObject);
        var opacity = sprrdr.color.a;       
        
        if (onCloak == true)
        {
            coll.enabled = false;
            opacity = 0.2f;            
        }
        else if (onCloak == false){
            coll.enabled = true;
            opacity = 1f; 
        }
    }
}
