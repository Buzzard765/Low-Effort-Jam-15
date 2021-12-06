using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int HP;
    private BoxCollider2D ShldCol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("PlayerBullet")) {
            Destroy(collision.gameObject);
            HP--;
            if (HP == 0) {
                Destroy(gameObject);
            }
        }
    }
}
