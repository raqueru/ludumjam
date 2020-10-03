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
    private bool foregrounded = false;


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
        float playerboxhalf = GetComponent<BoxCollider2D>().bounds.extents.y;
        Vector3 playerpos = new Vector3(transform.position.x, 0, 0);
        if (Input.GetKeyDown(KeyCode.UpArrow)&&!foregrounded)
        {
            float foregroundhalfy = foreground.GetComponent<BoxCollider2D>().bounds.extents.y;
            float foregroundcentery = foreground.GetComponent<BoxCollider2D>().bounds.center.y;
            float foregroundyupper = foregroundcentery + foregroundhalfy;
            transform.position = new Vector2(transform.position.x,foregroundyupper+ playerboxhalf);
            this.gameObject.layer = 8;
            foregrounded = true;

        }

        else if (Input.GetKeyDown(KeyCode.DownArrow)&&foregrounded)
        {
            float groundhalfy = ground.GetComponent<BoxCollider2D>().bounds.extents.y;
            //get the center
            float groundcentery = ground.GetComponent<BoxCollider2D>().bounds.center.y;
            //get the up border
            float groundyupper = groundcentery + groundhalfy;
            transform.position = new Vector2(transform.position.x,groundyupper+playerboxhalf);
            this.gameObject.layer = 0;
            foregrounded = false;
        }
    }
}
