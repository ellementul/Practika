using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControler : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator anim;
    private float hormoveInputer;
    private float vermoveInputer;
    public GameObject Player;
    public Transform[] moveSpots;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        hormoveInputer = Input.GetAxisRaw("Horizontal");
        vermoveInputer = Input.GetAxisRaw("Vertical");
        Vector2 moveImput = new Vector2(hormoveInputer, vermoveInputer);
        moveVelocity = moveImput * speed;
        Flip();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void Flip()
    {
        if (vermoveInputer > 0)
        {
            anim.SetBool("isrun", true);
        }
        else
        {
            anim.SetBool("isrun", false);
        }

        if (hormoveInputer < 0)
        {
            anim.SetBool("isrunl", true);
        }
        else
        {
            anim.SetBool("isrunl", false);
        }
    }
    public void SpawnPoint()
    {
        Player.transform.position = moveSpots[0].transform.position;
    }
}
