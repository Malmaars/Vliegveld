using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechMovement : MonoBehaviour
{
    public bool moveWay = false;
    public bool littlePoofForw = false;
    public bool littlePoofBack = true;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Time.deltaTime * 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveWay == true)
        {
            if (littlePoofForw == false)
            {
                this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 108, moveSpeed), Mathf.Lerp(this.transform.localScale.y, 18, moveSpeed), 1);
                if (this.transform.localScale.x > 105 && this.transform.localScale.y > 16)
                {
                    littlePoofForw = true;
                }
            }

            if(littlePoofForw == true)
            {
                this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 90, moveSpeed), Mathf.Lerp(this.transform.localScale.y, 15, moveSpeed), 1);
                littlePoofBack = false;
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
                littlePoofForw = false;
            }
        }
    }
}
