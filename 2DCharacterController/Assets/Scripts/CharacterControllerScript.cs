using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;

    Animator anim;
    Rigidbody2D rigidbody2d = new Rigidbody2D();

	void Start ()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //private Rigidbody2D GetComponent(Rigidbody2D rigidbody2d)
    //{
    //    throw new NotImplementedException();
    //}

    void FixedUpdate ()
    {
		float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rigidbody2d.velocity = new Vector2(move * maxSpeed, rigidbody2d.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
