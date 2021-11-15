using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    private Transform FiringPoint;
    public GameObject bulletPF;
    public float bulletforce;
    public Joystick RotationJS;
    // Start is called before the first frame update
    void Start()
    {
        FiringPoint = GameObject.Find("FirePoint").GetComponent<Transform>();
        RotationJS = GameObject.Find("Rotation Joystick").GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDir = (Vector3.right * RotationJS.Horizontal + Vector3.up * RotationJS.Vertical);
        if (RotationJS.Horizontal != 0 || RotationJS.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDir);

        }       
    }

    public void Shoot()
    {       
        GameObject bullet = Instantiate(bulletPF, FiringPoint.position, FiringPoint.rotation);
        //Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        //bulletRB.AddForce(FiringPoint.up * bulletforce, ForceMode2D.Impulse);
    }
}
