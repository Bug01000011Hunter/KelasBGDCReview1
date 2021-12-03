using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;
    private void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        float x, y;
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (x != 0)
            sr.flipX = x < 0;

        //if (x < 0)
        //{
        //    //kiri
        //    sr.flipX = true;
        //}
        //else if (x > 0) 
        //{
        //    //kanan
        //    sr.flipX = false;
        //}

        bool isSides;
        isSides = (x < 0) || (x > 0);

        anim.SetBool("isSides", isSides);
        anim.SetFloat("SpeedY", y);

        bool isIdle;
        isIdle = x == 0 && y == 0;

        anim.SetBool("isIdle", isIdle);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
        }

    }
    int loopCount;
    public void CountLoop()
    {
        loopCount++;
        Debug.Log("The animation has looped " + loopCount.ToString() + " times!");
    }
}
