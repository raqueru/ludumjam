using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramov : MonoBehaviour
{ 
    public GameObject Alvo;
    public float moveSpeed;
    private Transform transfPlayer;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        transfPlayer = Alvo.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(transfPlayer.position.x, transform.position.y, transform.position.z);

        //A: move-se junto com o player 
        transform.position = Vector3.Lerp(transform.position, targetPosition+ offset, moveSpeed * Time.deltaTime);
    }
}