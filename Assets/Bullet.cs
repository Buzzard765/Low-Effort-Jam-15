using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Bloweffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject blow = Instantiate(Bloweffect, transform.position, Quaternion.identity);
        Destroy(blow, 5f);
        Destroy(gameObject);
    }
}
