using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Collider2D trigger;
    public bool circleKey = true;
    public bool triangleKey = true;
    public bool pLeft;
    public bool pRight;
    public bool pDown;
    public bool pUp;
    public bool isPressed = false;
    public float pressSpeed = 1;
    private bool press;
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        startPos = rb.position; 
        press = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (press)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            
            gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;

            if (pLeft && !isPressed)
            {
                transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
                isPressed = true;
            }
            else if (pRight && !isPressed)
            {
                transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
                isPressed = true;
            }
            else if (pDown && !isPressed)
            {
                transform.position = new Vector2 (transform.position.x, transform.position.y - 0.1f);
                isPressed = true;
            }
            else if (pUp && !isPressed)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
                isPressed = true;
            }

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (press && (rb.position != startPos))
        {
            isPressed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Triangle") && triangleKey)
            {
                press = true;
            }
            else if (collision.gameObject.CompareTag("Circle") && circleKey)
            {
                press = true;
            }
        }
    }

}
