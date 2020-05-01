using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Itemlist;
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
        for(int i = 0; i < 10; i++)
        {
            int objectnmbr = rnd.Next(0, 3);
            Debug.Log(objectnmbr);
            Instantiate(Itemlist[objectnmbr], new Vector3(0, 0, 0), new Quaternion(0,0,0,0));
        }
    }
}
