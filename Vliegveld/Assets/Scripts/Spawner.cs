using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Button
{
    StateManager Manager;

    public GameObject[] Itemlist;
    public List<GameObject> currentItems;
    public GameObject[] Bags;
    public GameObject[] People;
    private GameObject currentBag;
    public GameObject currentPerson;

    System.Random rnd;

    public float clientTimer;
    public float itemTimer;

    public float bagSpeed;
    public float personSpeed;

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
        if (currentPerson != null && Manager.bagPersonBool == false)
        {
            personSpeed += 0.1f * Time.deltaTime;
            currentPerson.transform.position = new Vector3(Mathf.Lerp(currentPerson.transform.position.x, 0, personSpeed), currentPerson.transform.position.y, currentPerson.transform.position.z);
        }

        if (currentBag != null)
        {
            bagSpeed += 0.1f * Time.deltaTime;
            currentBag.transform.position = new Vector3(currentBag.transform.position.x, Mathf.Lerp(currentBag.transform.position.y, 0, bagSpeed), currentBag.transform.position.z);

            if (currentBag.transform.position.y < 2)
            {
                Transform[] ItemsInBag;
                ItemsInBag = new Transform[currentBag.transform.childCount-1];
                foreach (Transform item in ItemsInBag)
                {
                    if(item != null)
                    item.transform.GetComponent<dragAndDrop>().enabled = true;
                }
            }
        }
        if (currentPerson == null)
        {
            clientTimer += Time.deltaTime;

            if (clientTimer > 2)
            {
                Manager.PlaySound("Steps");
                spawnPerson();
                clientTimer = 0;
            }
        }

        if(currentBag == null)
        {
            itemTimer += Time.deltaTime;
            if(itemTimer > 4)
            {
                SpawnItems();
                itemTimer = 0;
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
        Manager.PlaySound("Enter");
        bagSpeed = 0;
        Manager.zetTerugNaarNormaal();
        int boxnmbr = rnd.Next(0, Bags.Length);
        GameObject Bag = Instantiate(Bags[boxnmbr], new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        currentItems.Clear();
        for (int i = 0; i < 5; i++)
        {
            int objectnmbr = rnd.Next(0, Itemlist.Length);
            //Debug.Log(objectnmbr);
            GameObject temp = Instantiate(Itemlist[objectnmbr], new Vector3(Random.Range(8.5f, 13f), Random.Range(3f, 5f), 0), new Quaternion(0, 0, 0, 0), Bag.transform);
            temp.transform.GetComponent<dragAndDrop>().enabled = false;
            currentItems.Add(temp);
        }
        Bag.transform.position = new Vector3(0, 12, 0);
        currentBag = Bag;
        Manager.CurrentBag = currentBag;
        Manager.isThereABag = true;
    }

    public void spawnPerson()
    {
        personSpeed = 0;
        Manager.beweegMensenOfzo();
        int peopleNmbr = rnd.Next(0, People.Length);
        GameObject Person = Instantiate(People[peopleNmbr], new Vector3(40, 0, 0), new Quaternion(0, 0, 0, 0));
        currentPerson = Person;
        Manager.currentPerson = currentPerson;
    }

    private void OnMouseDrag()
    {
        Clicky();
    }
}
