using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniEnemy2 : MonoBehaviour
{
    public Transform leftTarget;// Reference to player object (set in inspector)
    public Transform rightTarget;
    public float moveSpeed = 10f; // Enemy movement speed
    public float targetRange = 2f; // Minimum distance from player
    private Vector2 newPos;
    private Rigidbody2D rb;
    private bool isFlip = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (transform.position.x < 2)
        {
            if (isFlip == false)
            {
                transform.Rotate(0f, 180f, 0f);
            }
            isFlip = true;
     

        }
        if (transform.position.x > 12)
        {
            if (isFlip == true)
            {
                transform.Rotate(0f, 180f, 0f);
            }
            isFlip = false;
         
        }
        if (isFlip)
        {
            Vector2 target = new Vector2(rightTarget.position.x, transform.position.y);
            newPos = Vector2.MoveTowards(rb.position, target, moveSpeed * Time.deltaTime);

        }
        if (!isFlip)
        {
            Vector2 target = new Vector2(leftTarget.position.x, transform.position.y);

            newPos = Vector2.MoveTowards(rb.position, target, moveSpeed * Time.deltaTime);
        }
        rb.MovePosition(newPos);

    }
}