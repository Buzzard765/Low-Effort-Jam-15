using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{    
    private Transform Target;
    private Rigidbody2D bulletRB;
    //public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        bulletRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SeekPlayer();
    }
   

    private void SeekPlayer() {
        transform.position = Vector2.MoveTowards(transform.position, Target.position, bulletforce * Time.deltaTime);
        /*Vector2 Homingdir = Target.position - transform.position;
        float angle = Mathf.Atan2(Homingdir.y, Homingdir.x) * Mathf.Rad2Deg - 90f;
        bulletRB.rotation = angle;*/
        Destroy(gameObject, 3f);
    }

}
