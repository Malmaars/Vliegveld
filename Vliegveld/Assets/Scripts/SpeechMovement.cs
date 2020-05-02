using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechMovement : MonoBehaviour
{
    VraagKnop Vraag;

    public bool moveWay = false;
    public bool littlePoofForw = false;
    public bool littlePoofBack = true;

    public float waitForTime = 0;
    public float howlong;

    public float waitTillStop = 0;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Vraag = FindObjectOfType<VraagKnop>();
        moveSpeed = Time.deltaTime * 5;
        littlePoofBack = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveWay = Vraag.clicked;

        if(moveWay == true)
        {
            waitForTime += Time.deltaTime;

            if (waitForTime > howlong)
            {
                if (littlePoofForw == false)
                {
                    this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 108, moveSpeed), Mathf.Lerp(this.transform.localScale.y, 18, moveSpeed), 1);
                    if (this.transform.localScale.x > 105 && this.transform.localScale.y > 16)
                    {
                        littlePoofForw = true;
                    }
                }

                if (littlePoofForw == true)
                {
                    this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 90, moveSpeed), Mathf.Lerp(this.transform.localScale.y, 15, moveSpeed), 1);
                    littlePoofBack = false;
                    waitTillStop += Time.deltaTime;
                }
            }

            if(waitTillStop > 2)
            {
                waitTillStop = 0;
                Vraag.clicked = false;
            }
        }

        if(moveWay == false)
        {
            if(littlePoofBack == false)
            {
                this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 108, moveSpeed), Mathf.Lerp(this.transform.localScale.y, 18, moveSpeed), 1);
                if (this.transform.localScale.x > 105 && this.transform.localScale.y > 16)
                {
                    littlePoofBack = true;
                }
            }

            if (littlePoofBack == true)
            {
                this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 0, moveSpeed), Mathf.Lerp(this.transform.localScale.y, 0, moveSpeed), 1);

                if(this.transform.localScale.x < 0.3f)
                {
                    this.transform.localScale = new Vector3(0, 0, 1);
                    littlePoofForw = false;
                    waitForTime = 0;
                    waitTillStop = 0;
                }
            }
        }
    }
}
