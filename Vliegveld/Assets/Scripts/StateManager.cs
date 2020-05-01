using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public int acceptInt;
    public bool accept;
    public bool chosen = false;
    public bool isItActuallyGoodTho;

    public bool isThereABag = false;

    public GameObject CurrentBag;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (chosen == true)
        {
            if (accept == true)
            {
                acceptInt = -1;
                //Good boy points
            }

            if (accept == false)
            {
                //Bad bad
                acceptInt = 1;
            }

            CurrentBag.transform.position = new Vector3(Mathf.Lerp(CurrentBag.transform.position.x, 40 * acceptInt, Time.deltaTime * 2), CurrentBag.transform.position.y, CurrentBag.transform.position.z);

            if (CurrentBag.transform.position.x < -30 || CurrentBag.transform.position.x > 30)
            {
                Destroy(CurrentBag);
                if(accept == isItActuallyGoodTho)
                {
                    //puntje erbij
                }
                if(accept != isItActuallyGoodTho)
                {
                    //puntje eraf
                }
                chosen = false;
                isThereABag = false;
            }
        }
    }
}
