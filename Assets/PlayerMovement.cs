using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    float xInput = 0f;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        FlipPlayer();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                xInput = -1.0f;
            }
            else
            {
                xInput = 1.0f;
            }

        }
        else
        {
            xInput = 0f;
        }
        rb.AddForce(transform.right*xInput*100.0f);
        
    }
    void FlipPlayer()
    {
        if (rb.velocity.x <= 0)
        {
            sprite.flipX = true;
        }
        else if (rb.velocity.x >= 0)
        {
            sprite.flipX = false;
        }
    }
}
