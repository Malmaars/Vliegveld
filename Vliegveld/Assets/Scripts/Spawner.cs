using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Button
{
    StateManager Manager;

    public GameObject[] Itemlist;
    public GameObject[] Bags;
    private GameObject currentBag;
    System.Random rnd;

    public float clientTimer;
    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
        Manager = FindObjectOfType<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Press();
        if(currentBag != null)
        currentBag.transform.position = new Vector3(currentBag.transform.position.x, Mathf.Lerp(currentBag.transform.position.y, 3, Time.deltaTime * 2), currentBag.transform.position.z);

        if(currentBag == null)
        {
            clientTimer += Time.deltaTime;

            if (clientTimer > 2)
            {
                clientTimer = 0;
                SpawnItems();
            }
        }
    }

    private void OnMouseDown()
    {
    //    if(Manager.isThereABag == false)
    //    SpawnItems();
    }

    public void SpawnItems()
    {
        int boxnmbr = rnd.Next(0, 3);
        GameObject Bag = Instantiate(Bags[boxnmbr], new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        for(int i = 0; i < 5; i++)
        {
            int objectnmbr = rnd.Next(0, 3);
            Debug.Log(objectnmbr);
            GameObject temp = Instantiate(Itemlist[objectnmbr], new Vector3(Random.Range(-4f,4f), Random.Range(-2f, 2f), 0), new Quaternion(0,0,0,0), Bag.transform);
        }
        Bag.transform.position = new Vector3(9.5f, 15, 0);
        currentBag = Bag;
        Manager.CurrentBag = currentBag;
        Manager.isThereABag = true;
    }

    private void OnMouseDrag()
    {
        Clicky();
    }
}
