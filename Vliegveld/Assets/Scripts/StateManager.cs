using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StateManager : MonoBehaviour
{
    public int acceptInt;
    public bool accept;
    public bool chosen = false;
    public bool isItActuallyGoodTho;

    public bool isThereABag = false;
    public bool bagPersonBool = false;

    public bool planeExplodes = false;
    public int points = 0;

    public float waitTillEnd;
    private float AwaySpeed;
    private float peopleSpeed;

    public GameObject CurrentBag;
    public GameObject currentPerson;

    public GameObject Ondergrond;
    public GameObject Vliegveld;
    public GameObject askButton;
    public GameObject goodButton;
    public GameObject badButton;
    public GameObject Bakje;

    public GameObject PointCount;

    public AudioClip footsteps, bagentry, bagaway, itemdrop, plane, button, explosion;
    public AudioSource Audiosrc;
    // Start is called before the first frame update
    void Awake()
    {
        Audiosrc = transform.GetComponent<AudioSource>();
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
            AwaySpeed += 0.05f * Time.deltaTime;
            CurrentBag.transform.position = new Vector3(Mathf.Lerp(CurrentBag.transform.position.x, 50 * acceptInt, AwaySpeed), CurrentBag.transform.position.y, CurrentBag.transform.position.z);

            if (CurrentBag.transform.position.x < -40 || CurrentBag.transform.position.x > 40)
            {
                PlaySound("Steps");
                Destroy(CurrentBag);
                bagPersonBool = true;
                AwaySpeed = 0;
            }
        }

        if (bagPersonBool == true)
        {
            beweegMensenOfzo();
            peopleSpeed += 0.1f * Time.deltaTime;
            currentPerson.transform.position = new Vector3(Mathf.Lerp(currentPerson.transform.position.x, 50 * acceptInt, peopleSpeed), currentPerson.transform.position.y, currentPerson.transform.position.z);
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
                peopleSpeed = 0;
            }
        }

        PointCount.GetComponent<TextMeshPro>().text = "Points : " + points;

        if(points >= 10)
        {
            waitTillEnd += Time.deltaTime;

            if(waitTillEnd > 2)
            {
                SceneManager.LoadScene(sceneName: "GoodEnd");
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

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Steps":
                Audiosrc.PlayOneShot(footsteps);
                break;
            case "Enter":
                Audiosrc.PlayOneShot(bagentry);
                break;
            case "Away":
                Audiosrc.PlayOneShot(bagaway);
                break;
            case "Item":
                Audiosrc.PlayOneShot(itemdrop);
                break;
            case "Plane":
                Audiosrc.PlayOneShot(plane);
                break;
            case "Button":
                Audiosrc.PlayOneShot(button);
                break;
            case "Explode":
                Audiosrc.PlayOneShot(explosion);
                break;
        }
    }
}
