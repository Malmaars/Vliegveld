using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Itemlist;
    public GameObject[] Bags;
    private GameObject currentBag;
    System.Random rnd;
    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBag != null)
        currentBag.transform.position = new Vector3(currentBag.transform.position.x, Mathf.Lerp(currentBag.transform.position.y, 0, 0.02f), currentBag.transform.position.z);
    }

    private void OnMouseDown()
    {
        SpawnItems();
    }

    public void SpawnItems()
    {
        int boxnmbr = rnd.Next(0, 3);
        GameObject Bag = Instantiate(Bags[boxnmbr], new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        for(int i = 0; i <= 5; i++)
        {
            int objectnmbr = rnd.Next(0, 3);
            Debug.Log(objectnmbr);
            GameObject temp = Instantiate(Itemlist[objectnmbr], new Vector3(Random.Range(-20f,20f), Random.Range(-10f, 10f), 0), new Quaternion(0,0,0,0), Bag.transform);
        }
        Bag.transform.position = new Vector3(0, 120, 0);
        currentBag = Bag;
        
    }
}
