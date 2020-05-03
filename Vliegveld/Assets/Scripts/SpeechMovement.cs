using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechMovement : MonoBehaviour
{
    VraagKnop Vraag;
    StateManager Manager;

    public bool moveWay = false;
    public bool littlePoofForw = false;
    public bool littlePoofBack = true;

    public bool AmITheCant;

    public float waitForTime = 0;
    public float howlong;

    public float waitTillStop = 0;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Vraag = FindObjectOfType<VraagKnop>();
        Manager = FindObjectOfType<StateManager>();
        littlePoofBack = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = Time.deltaTime * 5;
        moveWay = Vraag.clicked;

        if (AmITheCant == false && Vraag.badBool == false)
        {
            if (moveWay == true)
            {
                waitForTime += Time.deltaTime;

                if (waitForTime > howlong)
                {
                    if (littlePoofForw == false)
                    {
                        this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 1.3f, moveSpeed), Mathf.Lerp(this.transform.localScale.y, 1.3f, moveSpeed), 1);
                        if (this.transform.localScale.x > 1.2f && this.transform.localScale.y > 1.2f)
                        {
                            littlePoofForw = true;
                        }
                    }

                    if (littlePoofForw == true)
                    {
                        this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 1, moveSpeed), Mathf.Lerp(this.transform.localScale.y, 1, moveSpeed), 1);
                        littlePoofBack = false;
                        waitTillStop += Time.deltaTime;
                    }
                }

                if (waitTillStop > 3)
                {
                    waitTillStop = 0;
                    Vraag.clicked = false;
                }
            }

            if (moveWay == false)
            {
                if (littlePoofBack == false)
                {
                    this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 1.3f, moveSpeed), Mathf.Lerp(this.transform.localScale.y, 1.3f ,moveSpeed), 1);
                    if (this.transform.localScale.x > 1.2f && this.transform.localScale.y > 1.2f)
                    {
                        littlePoofBack = true;
                    }
                }

                if (littlePoofBack == true)
                {
                    this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 0, moveSpeed), Mathf.Lerp(this.transform.localScale.y, 0, moveSpeed), 1);

                    if (this.transform.localScale.x < 0.1f)
                    {
                        if(Manager.currentPerson != null)
                        Manager.currentPerson.transform.GetComponent<Persoon>().NervousBool = false;

                        this.transform.localScale = new Vector3(0, 0, 1);
                        littlePoofForw = false;
                        waitForTime = 0;
                        waitTillStop = 0;
                    }
                }
            }
        }

        if(AmITheCant == true && Vraag.badBool == true)
        {
            if (moveWay == true)
            {
                waitForTime += Time.deltaTime;

                if (waitForTime > howlong)
                {
                    if (littlePoofForw == false)
                    {
                        this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 1.3f, moveSpeed), Mathf.Lerp(this.transform.localScale.y, 1.3f, moveSpeed), 1);
                        if (this.transform.localScale.x > 1.2f && this.transform.localScale.y > 1.2f)
                        {
                            littlePoofForw = true;
                        }
                    }

                    if (littlePoofForw == true)
                    {
                        this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 1, moveSpeed), Mathf.Lerp(this.transform.localScale.y, 1, moveSpeed), 1);
                        littlePoofBack = false;
                        waitTillStop += Time.deltaTime;
                    }
                }

                if (waitTillStop > 2)
                {
                    waitTillStop = 0;
                    Vraag.clicked = false;
                }
            }

            if (moveWay == false)
            {
                if (littlePoofBack == false)
                {
                    this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 1.3f, moveSpeed), Mathf.Lerp(this.transform.localScale.y, 1.3f, moveSpeed), 1);
                    if (this.transform.localScale.x > 1.2f && this.transform.localScale.y > 1.2f)
                    {
                        littlePoofBack = true;
                    }
                }

                if (littlePoofBack == true)
                {
                    this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 0, moveSpeed), Mathf.Lerp(this.transform.localScale.y, 0, moveSpeed), 1);

                    if (this.transform.localScale.x < 0.1f)
                    {
                        this.transform.localScale = new Vector3(0, 0, 1);
                        littlePoofForw = false;
                        Vraag.badBool = false;
                        waitForTime = 0;
                        waitTillStop = 0;
                    }
                }
            }
        }
    }
}
