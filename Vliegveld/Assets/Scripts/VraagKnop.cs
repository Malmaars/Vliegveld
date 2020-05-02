using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VraagKnop : MonoBehaviour
{
    public GameObject Bakje;

    private Transform voorwerpInBakje;
    private string Vraagtext;
    private string AntwoordText;

    public GameObject mySpeech;
    public GameObject theirSpeech;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Bakje.transform.childCount != 1)
        {
            voorwerpInBakje = null;
            return;
            //Ja dat mag dus niet
        }

        if(Bakje.transform.childCount == 1)
        {
            voorwerpInBakje = Bakje.transform.GetChild(0);
        }
    }

    private void OnMouseUp()
    {
        if (voorwerpInBakje != null)
        {
            Vraagtext = voorwerpInBakje.GetComponent<Text>().text;
            AntwoordText = voorwerpInBakje.GetChild(0).GetComponent<Text>().text;

            Transform myChildTemp = mySpeech.transform.GetChild(0);
            myChildTemp.gameObject.GetComponent<TextMeshPro>().text = Vraagtext;

            Transform theirChildTemp = theirSpeech.transform.GetChild(0);
            theirChildTemp.gameObject.GetComponent<TextMeshPro>().text = AntwoordText;
        }
    }
}
