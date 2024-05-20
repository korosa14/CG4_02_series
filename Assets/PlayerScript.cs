using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private bool isBlock = true;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 5.0f;
        Vector3 v = rb.velocity;


        if (Input.GetKey(KeyCode.RightArrow))
        {
            v.x = moveSpeed;
        }
        else
        {
            v.x = 0;
        }

        rb.velocity = v;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            v.x = -moveSpeed;
        }
        rb.velocity = v;


        //プレイヤーの下方向へレイを出す
        Vector3 rayPosition = transform.position;
        Ray ray = new Ray(rayPosition, Vector3.down);
        float distance = 0.6f;
        isBlock = Physics.Raycast(ray, distance);

        if(isBlock==true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                v.y = moveSpeed;
            }
            rb.velocity = v;
        }

    }
}
