using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{    
    private Transform Target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        SeekPlayer();
    }
   

    private void SeekPlayer() {
        transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
        Destroy(gameObject, 3f);
    }

}
