using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptOrReject : Button
{
    StateManager Manager;

    public bool GoodOrNot;

    public GameObject Bakje;
    // Start is called before the first frame update
    void Start()
    {
        Manager = FindObjectOfType<StateManager>();
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
            Manager.accept = GoodOrNot;
            Manager.chosen = true;
        }
    }

    private void OnMouseDrag()
    {
        Clicky();
    }
}
