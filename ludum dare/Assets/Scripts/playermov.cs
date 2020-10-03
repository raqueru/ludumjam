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
    public Transform ground;
    public Transform foreground;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

         rb.transform.position = rb.position + Vector2.right * playerspeed * Time.fixedDeltaTime; //movimenta o personagem
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.velocity = jumpforce * Vector2.up;


        }
        changelayer();
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

    void changelayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {

            Vector3 playerpos = new Vector3(transform.position.x, 0, 0);
            //get the extents
            var foregroundhalfy = foreground.GetComponent<BoxCollider2D>().bounds.extents.y;
            //get the center
            var foregroundcentery = foreground.GetComponent<BoxCollider2D>().bounds.center.y;
            //get the up border
            float foregroundyupper = foregroundcentery + foregroundhalfy;
            //get the lower border
           

            //Vector3 groundpos = new Vector3(0, yCenter, 0);
            // transform.position=Vector3.Lerp(playerpos,groundpos, 5 * Time.deltaTime);

            transform.position = new Vector2(transform.position.x,foregroundyupper);
            this.gameObject.layer = 8;

        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            var groundhalfy = ground.GetComponent<BoxCollider2D>().bounds.extents.y;
            //get the center
            var groundcentery = ground.GetComponent<BoxCollider2D>().bounds.center.y;
            //get the up border
            float groundyupper = groundcentery + groundhalfy;
            transform.position = new Vector2(transform.position.x, groundyupper);
            this.gameObject.layer = 0;
        }
    }
}
