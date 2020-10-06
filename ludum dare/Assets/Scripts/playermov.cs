using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    private bool foregrounded = false;
    public float fallMultiplier;
    public bool canchange;
    private Animator animator;
    public float JumpTime;
    float lerpDuration = 0.2f;
    private float timer;

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

        if (!grounded)
        {
            timer += Time.deltaTime;
            if (timer >= JumpTime)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
        }
        else if (grounded)
        {
            timer = 0;

            canchange = true;
            changelayer();
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            animator.SetBool("jumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    IEnumerator lerpcode(float ypos, int layer, bool fore, int layerpos)
    {
        Vector2 NewPos;

        this.gameObject.layer = layer;
        foregrounded = fore;
        this.GetComponent<SpriteRenderer>().sortingOrder = layerpos;

        float timeElapsed = 0;
        rb.gravityScale = 0;
        while (timeElapsed < lerpDuration)
        {
            Vector2 StartPos = new Vector2(transform.position.x, transform.position.y);
            NewPos = new Vector2(transform.position.x, ypos + 0.1f);

            transform.position = Vector2.Lerp(transform.position, NewPos, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }
        NewPos = new Vector2(transform.position.x, ypos + 0.1f);
        transform.position = NewPos;
        rb.gravityScale = 1;
     

    }


    void changelayer()
    {
        float playerboxhalf = GetComponent<BoxCollider2D>().bounds.extents.y;

        if (Input.GetKey(KeyCode.UpArrow) && !foregrounded)
        {
            float foregroundhalfy = foreground.GetComponent<BoxCollider2D>().bounds.extents.y;
            float foregroundcentery = foreground.GetComponent<BoxCollider2D>().bounds.center.y;
            float foregroundyupper = foregroundcentery + foregroundhalfy;
            Vector3 NewPos = new Vector3(transform.position.x, foregroundyupper + playerboxhalf);
            StartCoroutine(lerpcode(foregroundyupper + playerboxhalf, 8, true, 0));


        }

        else if (Input.GetKey(KeyCode.DownArrow) && foregrounded)
        {
            float groundhalfy = ground.GetComponent<BoxCollider2D>().bounds.extents.y;
            float groundcentery = ground.GetComponent<BoxCollider2D>().bounds.center.y;
            float groundyupper = groundcentery + groundhalfy;
            Vector2 NewPos = new Vector2(transform.position.x, groundcentery + playerboxhalf);
            StartCoroutine(lerpcode(groundyupper + playerboxhalf, 0, false, 1));

        }
    }
}
