using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2f;
    private Vector2 lastDirection;
    public float range = 5f;       //5 unit
    public float dashSpeed = 10f;  //10 unit/sec
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    bool canMove;
    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        Vector2 input;

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();

        if (input != Vector2.zero)
        {
            lastDirection = input;
        }  // direction
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canMove = false;

            rb.velocity = lastDirection * dashSpeed;
            StartCoroutine(DelayDash());

            return;
        } //dash

        rb.velocity = input * speed;  // movement
    }
    IEnumerator DelayDash()
    {
        yield return new WaitForSeconds(range / dashSpeed);
        canMove = true;
    }
}
