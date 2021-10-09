using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    private Transform FiringPoint;
    public GameObject bulletPF;
    public float bulletforce;
    // Start is called before the first frame update
    void Start()
    {
        FiringPoint = GameObject.Find("FirePoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    private void Shoot()
    {       
        GameObject bullet = Instantiate(bulletPF, FiringPoint.position, FiringPoint.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(FiringPoint.up * bulletforce, ForceMode2D.Impulse);
    }
}
