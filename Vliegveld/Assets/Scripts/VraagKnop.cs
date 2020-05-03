using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VraagKnop : Button
{
    StateManager Manager;

    public GameObject Bakje;

    public Transform voorwerpInBakje;
    private string Vraagtext;
    private string AntwoordText;

    public bool badBool;

    public GameObject mySpeech;
    public GameObject theirSpeech;
    public GameObject CantDoThat;

    public bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {
        Manager = FindObjectOfType<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Press();

        if (Bakje.transform.childCount != 1)
        {
            voorwerpInBakje = null;
            //Ja dat mag dus niet
        }

        if(Bakje.transform.childCount == 1)
        {
            voorwerpInBakje = Bakje.transform.GetChild(0);
        }
    }

    private void OnMouseUp()
    {

        if (voorwerpInBakje != null && badBool == false)
        {
            Vraagtext = voorwerpInBakje.GetComponent<Text>().text;
            AntwoordText = voorwerpInBakje.GetChild(0).GetComponent<Text>().text;

            Transform myChildTemp = mySpeech.transform.GetChild(0);
            myChildTemp.gameObject.GetComponent<TextMeshPro>().text = Vraagtext;

            Transform theirChildTemp = theirSpeech.transform.GetChild(0);
            theirChildTemp.gameObject.GetComponent<TextMeshPro>().text = AntwoordText;
            clicked = true;

            if(voorwerpInBakje.gameObject.tag == "Bad")
            {
                if (Manager.currentPerson != null)
                    Manager.currentPerson.transform.GetComponent<Persoon>().NervousBool = true;
            }
        }

        if (voorwerpInBakje == null)
        {
            if (Bakje.transform.childCount > 1)
            {
                Transform cantTemp = CantDoThat.transform.GetChild(0);
                cantTemp.gameObject.GetComponent<TextMeshPro>().text = "I can only ask about one thing at a time";
            }

            if(Bakje.transform.childCount == 0)
            {
                Transform cantTemp = CantDoThat.transform.GetChild(0);
                cantTemp.gameObject.GetComponent<TextMeshPro>().text = "I don't have anything to ask about";
            }
            badBool = true;
            clicked = true;
        }
    }
    private void OnMouseDown()
    {
        Manager.PlaySound("Button");
    }

    private void OnMouseDrag()
    {
        Clicky();
    }
}
