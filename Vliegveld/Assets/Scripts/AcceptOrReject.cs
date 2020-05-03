using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptOrReject : Button
{
    StateManager Manager;
    Spawner Spawn;

    public bool GoodOrNot;

    public GameObject Bakje;
    // Start is called before the first frame update
    void Start()
    {
        Manager = FindObjectOfType<StateManager>();
        Spawn = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Press();
    }

    private void OnMouseDown()
    {
        if (Manager.chosen == false && Manager.CurrentBag != null)
        {
            int temp = Bakje.transform.childCount;
            for(int i = 0; i < temp; i++)
            {
                Transform tempChild = Bakje.transform.GetChild(i);
                tempChild.GetComponent<BoxCollider2D>().enabled = false;
                tempChild.SetParent(Manager.CurrentBag.transform);
            }

            GameObject[] items;
            items = Spawn.Itemlist;

            bool badcheck = false;
            foreach(GameObject item in items)
            {
                if(item.tag == "Bad")
                {
                    badcheck = true;
                }
            }
            if (badcheck == true && this.gameObject.tag == "Good")
                Manager.planeExplodes = true;

            if ((badcheck == false && this.gameObject.tag == "Good") || (badcheck == true && this.gameObject.tag == "Bad"))
                Manager.points += 1;

            if (badcheck == false && this.gameObject.tag == "Bad")
                Manager.points -= 1;

            Manager.accept = GoodOrNot;
            Manager.chosen = true;
        }
    }

    private void OnMouseDrag()
    {
        Clicky();
    }
}
