using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private bool isBlock = true;
    private AudioSource audioSource;

    public GameObject bombParticle;
    public Rigidbody rb;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
        audioSource = gameObject.GetComponent<AudioSource>();
        GameManagerScript.score = 0;

        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f);
        float distance = 0.9f;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag=="COIN")
        {
            //爆破パーティクル発生
            Instantiate(bombParticle, transform.position, Quaternion.identity);

            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 8.0f;
        Vector3 v = rb.velocity;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            v.x = moveSpeed;
            transform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            v.x = -moveSpeed;
            transform.rotation = Quaternion.Euler(0, -90, 0);
            animator.SetBool("Walk", true);
        }
        else
        {
            v.x = 0;
            animator.SetBool("Walk", false);
        }
        rb.velocity = v;

        //ジャンプアニメーション切り替え
        if(isBlock==true)
        {
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Jump", true);
        }

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
