using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField]private Transform[] FiringPoint;
    
    [SerializeField]private int weaponRank;
    public int weaponRank_get {
        get { return weaponRank; }
        set { weaponRank = value; }
    }
    public GameObject bulletPF;
    public float bulletforce;
    public Joystick RotationJS;

    public AudioSource AllAudio;
    public AudioClip SFX_Shoot;
    // Start is called before the first frame update
    void Start()
    {
        AllAudio = GetComponent<AudioSource>();
        RotationJS = GameObject.Find("Rotation Joystick").GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponRank >= FiringPoint.Length) {
            weaponRank = FiringPoint.Length - 1;
        }
        Vector3 lookDir = (Vector3.right * RotationJS.Horizontal + Vector3.up * RotationJS.Vertical);
        if (RotationJS.Horizontal != 0 || RotationJS.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDir);

        }       
    }

    public void Shoot()
    {
        for (int i = 0; i <= weaponRank; i++) {
            GameObject bullet = Instantiate(bulletPF, FiringPoint[i].position, FiringPoint[i].rotation);
            AllAudio.PlayOneShot(SFX_Shoot);
        }
        
        //Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        //bulletRB.AddForce(FiringPoint.up * bulletforce, ForceMode2D.Impulse);
    }
}
