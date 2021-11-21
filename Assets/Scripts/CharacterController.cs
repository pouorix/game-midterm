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
   public EventSystemCustomLogic eventSystem;
   private float touchedGround;
   private float lastY;
   private float deltaY;
   private bool isOnFloor;
   private bool canJump;
    void Start()
    {
        moveVector = new Vector3(1 * factor, 0, 0);
        lastY = transform.position.y;
        isOnFloor = false;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        deltaY = transform.position.y - lastY;
        lastY = transform.position.y;
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
        if (isOnFloor && deltaY<0 && canJump)
        {
            canJump = false;
            rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
        }
        else if (isOnFloor && deltaY==0 && canJump)
        {
            canJump = false;
            StartCoroutine(ChangeFindingText());
        }
        Debug.Log(isOnFloor);
        Debug.Log(deltaY);
        Debug.Log(canJump);



    }

    IEnumerator ChangeFindingText()
    {
        yield return new WaitForSecondsRealtime(.2f);
        if (deltaY==0)
        {
            rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
            canJump = true;
            // canJump = false;
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("ground"))
        {
            isOnFloor = true;
            if (touchedGround != other.gameObject.transform.position.y)
            {
                eventSystem.OnGroundTouch.Invoke();
            }

            touchedGround = other.gameObject.transform.position.y;

        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isOnFloor = false;
            canJump = true;
        }
    }
}
