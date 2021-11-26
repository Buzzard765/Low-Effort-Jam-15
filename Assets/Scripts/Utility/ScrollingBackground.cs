using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private MeshRenderer MR;
    Material Mat;
    Vector2 Offset;
    Transform PlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        MR = GetComponent<MeshRenderer>();
        
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Mat = MR.material;
        Offset = Mat.mainTextureOffset;
        Offset.x = PlayerPos.position.x / 50f;
        Offset.y = PlayerPos.position.y / 50f;
        Mat.mainTextureOffset = Offset;
    }
}
