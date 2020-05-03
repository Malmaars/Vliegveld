using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persoon : MonoBehaviour
{
    public Sprite Idle1;
    public Sprite Idle2;
    public Sprite Nervous;
    public float Clock;
    public bool switcheroo = false;
    public bool NervousBool;

    // Start is called before the first frame update
    void Start()
    {
        randomClock();
    }

    // Update is called once per frame
    void Update()
    {
        Clock -= Time.deltaTime;

        if(Clock < 0f)
        {
            if (switcheroo == false)
            {
                this.GetComponent<SpriteRenderer>().sprite = Idle2;
                shortClock();
            }

            if(switcheroo == true)
            {
                this.GetComponent<SpriteRenderer>().sprite = Idle1;
                randomClock();
            }
            switcheroo = !switcheroo;
        }

        if(NervousBool == true)
        {
            this.GetComponent<SpriteRenderer>().sprite = Nervous;
            Clock = -1f;
        }
    }

    void randomClock()
    {
        Clock = Random.Range(2f, 4f);
    }

    void shortClock()
    {
        Clock = Random.Range(0.5f, 1f);
    }
}
