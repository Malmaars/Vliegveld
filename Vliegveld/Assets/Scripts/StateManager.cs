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
    public bool bagPersonBool = false;

    public GameObject CurrentBag;
    public GameObject currentPerson;

    public GameObject Ondergrond;
    public GameObject Vliegveld;
    public GameObject askButton;
    public GameObject goodButton;
    public GameObject badButton;
    public GameObject Bakje;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (chosen == true && CurrentBag != null)
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
                bagPersonBool = true;
            }
        }

        if (bagPersonBool == true)
        {
            beweegMensenOfzo();
            currentPerson.transform.position = new Vector3(Mathf.Lerp(currentPerson.transform.position.x, 50 * acceptInt, Time.deltaTime * 2), currentPerson.transform.position.y, currentPerson.transform.position.z);
            if (currentPerson.transform.position.x < -20 || currentPerson.transform.position.x > 20)
            {
                Destroy(currentPerson);
                bagPersonBool = false;
                chosen = false;
                isThereABag = false;
                if (accept == isItActuallyGoodTho)
                {
                    //puntje erbij
                }
                if (accept != isItActuallyGoodTho)
                {
                    //puntje eraf
                }
                zetTerugNaarNormaal();
            }
        }
    }

    public void beweegMensenOfzo()
    {
        Ondergrond.GetComponent<SpriteRenderer>().sortingOrder = 1;
        askButton.GetComponent<SpriteRenderer>().sortingOrder = 2;
        goodButton.GetComponent<SpriteRenderer>().sortingOrder = 2;
        badButton.GetComponent<SpriteRenderer>().sortingOrder = 2;
        Bakje.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    public void zetTerugNaarNormaal()
    {
        Ondergrond.GetComponent<SpriteRenderer>().sortingOrder = -10;
        askButton.GetComponent<SpriteRenderer>().sortingOrder = -6;
        goodButton.GetComponent<SpriteRenderer>().sortingOrder = -6;
        badButton.GetComponent<SpriteRenderer>().sortingOrder = -6;
        Bakje.GetComponent<SpriteRenderer>().sortingOrder = -6;
    }
}
