using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool pressBool;

    public Sprite notPressed;
    public Sprite pressed;

    // Update is called once per frame
    public virtual void Press()
    {
        if (pressBool == true)
            GetComponent<SpriteRenderer>().sprite = pressed;

        if (pressBool == false)
            GetComponent<SpriteRenderer>().sprite = notPressed;

        pressBool = false;
    }

    public virtual void Clicky()
    {
        pressBool = true;
    }
}
