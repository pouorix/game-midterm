using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 moveVector;
    public float factor = 0.01f;
    public Rigidbody2D rb;
    public float jumpAmount = 0.5f;
    void Start()
    {
        moveVector = new Vector3(1 * factor, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += moveVector;
            if (gameObject.transform.localScale.x>0)
            {
                gameObject.transform.localScale = new Vector3(-1 * gameObject.transform.localScale.x,
                    gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= moveVector;
            if (gameObject.transform.localScale.x<0)
            {
                gameObject.transform.localScale = new Vector3(-1 * gameObject.transform.localScale.x,
                    gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
        }

    }
}
