using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Itemlist;
    public GameObject[] Bags;
    System.Random rnd;
    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SpawnItems();
    }

    public void SpawnItems()
    {
        int boxnmbr = rnd.Next(0, 3);
        GameObject Bag = Instantiate(Bags[boxnmbr], new Vector3(0, 8, 0), new Quaternion(0, 0, 0, 0));
        for(int i = 0; i < 10; i++)
        {
            int objectnmbr = rnd.Next(0, 3);
            Debug.Log(objectnmbr);
            GameObject temp = Instantiate(Itemlist[objectnmbr], new Vector3(Random.Range(-2f,2f), Random.Range(-1f, 1f), 0), new Quaternion(0,0,0,0), Bag.transform);
        }
        Bag.transform.position = 
    }
}
