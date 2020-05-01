using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptOrReject : MonoBehaviour
{
    StateManager Manager;

    public bool GoodOrNot;
    // Start is called before the first frame update
    void Start()
    {
        Manager = FindObjectOfType<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        if (Manager.chosen == false || Manager.CurrentBag != null)
        {
            Manager.accept = GoodOrNot;
            Manager.chosen = true;
        }
    }
}
