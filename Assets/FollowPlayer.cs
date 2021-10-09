using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float followspeed = 2f;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != Target.position)
        {
            Vector3 newPos = new Vector3(Target.position.x, Target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, followspeed);
        }
            
    }
}
