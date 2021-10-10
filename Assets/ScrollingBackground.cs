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
        Mat = MR.material;
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Offset = Mat.mainTextureOffset;
        Offset.x = PlayerPos.position.x;
        Offset.y = PlayerPos.position.y;
        Mat.mainTextureOffset = Offset;
    }
}
