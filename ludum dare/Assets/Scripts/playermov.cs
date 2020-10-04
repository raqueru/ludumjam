﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermov : MonoBehaviour
{
    public float jumpforce;
    public float playerspeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool grounded;
    public Transform ground;
    public Transform foreground;
    public bool foregrounded = false;
    public float fallMultiplier;
    public Vector2 temp;
    public bool canchange;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.transform.position = rb.position + Vector2.right * playerspeed * Time.fixedDeltaTime; //movimenta o personagem
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            animator.SetBool("jumping", true);
            rb.velocity = jumpforce * Vector2.up;
            canchange = false;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        if (grounded)
        {
            animator.SetBool("jumping", false);
            canchange =true;
            StartCoroutine(changelayer());
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    IEnumerator changelayer()
    {
        float playerboxhalf = GetComponent<BoxCollider2D>().bounds.extents.y;
        Vector3 playerpos = new Vector3(transform.position.x, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow) && !foregrounded)
        {
            float foregroundhalfy = foreground.GetComponent<BoxCollider2D>().bounds.extents.y;
            float foregroundcentery = foreground.GetComponent<BoxCollider2D>().bounds.center.y;
            float foregroundyupper = foregroundcentery + foregroundhalfy;
            Vector2 NewPos = new Vector2(transform.position.x, foregroundyupper + playerboxhalf);
            transform.position = Vector2.Lerp(transform.position, NewPos, 30 * Time.deltaTime);
            this.gameObject.layer = 8;
            foregrounded = true;
            yield return new WaitForSeconds(0.1f);
        }

        else if (Input.GetKey(KeyCode.DownArrow) && foregrounded)
        {
            float groundhalfy = ground.GetComponent<BoxCollider2D>().bounds.extents.y;
            float groundcentery = ground.GetComponent<BoxCollider2D>().bounds.center.y;
            float groundyupper = groundcentery + groundhalfy;
            Vector2 NewPos = new Vector2(transform.position.x, groundyupper + playerboxhalf);
            transform.position = Vector2.Lerp(transform.position, NewPos, 30 * Time.deltaTime);
            yield return new WaitForSeconds(0.0001f);
            this.gameObject.layer = 0;
            foregrounded = false;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
