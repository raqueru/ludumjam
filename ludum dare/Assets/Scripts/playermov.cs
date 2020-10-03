using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermov : MonoBehaviour
{
    public float jumpforce;
    public float playerspeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
          rb.transform.position = rb.position + Vector2.right*playerspeed * Time.fixedDeltaTime; //movimenta o personagem
          if (Input.GetKey(KeyCode.Space)&& grounded){
            rb.velocity = jumpforce * Vector2.up;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
}
