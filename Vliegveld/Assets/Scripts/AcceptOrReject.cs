using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptOrReject : Button
{
    StateManager Manager;
    Spawner Spawn;

    public bool GoodOrNot;
    public bool flyBool;
    public bool explodeBool;
    public bool badcheck;

    private float speed;

    public GameObject Bakje;

    public GameObject Plane;
    public Animator planeAnim;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        speed = Time.deltaTime * 0.2f;
        Manager = FindObjectOfType<StateManager>();
        Spawn = FindObjectOfType<Spawner>();

        if(Plane.gameObject != null)
        planeAnim = Plane.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Press();

        if (Plane.gameObject != null)
        {
            if (flyBool == true)
            {
                timer += Time.deltaTime;
                if (timer > 2)
                {
                    Plane.transform.position = new Vector3(Mathf.Lerp(Plane.transform.position.x, -12, speed), Mathf.Lerp(Plane.transform.position.y, 10, speed), 0);
                    Plane.transform.localScale = new Vector3(Mathf.Lerp(Plane.transform.localScale.x, 0, speed), Mathf.Lerp(Plane.transform.localScale.y, 0, speed), 1);

                    if(explodeBool == true && Plane.transform.position.y > 5)
                    {
                        planeAnim.SetTrigger("Explode");
                    }

                    if (Plane.transform.localScale.x < 0.05f)
                    {
                        planeAnim.SetTrigger("Normal");
                        flyBool = false;
                        timer = 0;
                    }
                }
            }

            if (flyBool == false)
            {
                Plane.transform.position = new Vector3(-15, 0, 0);
                Plane.transform.localScale = new Vector3(1, 1, 1);
            }
        }
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

            List<GameObject> items;
            items = Spawn.currentItems;

            badcheck = false;
            foreach(GameObject item in items)
            {
                if(item.tag == "Bad")
                {
                    badcheck = true;
                }
            }
            if (badcheck == true && this.gameObject.tag == "Good")
            {
                Manager.planeExplodes = true;
                explodeBool = true;
                flyBool = true;
            }

            if (badcheck == false && this.gameObject.tag == "Good")
            {
                Manager.points += 1;
                flyBool = true;
                explodeBool = false;
            }

            if(badcheck == true && this.gameObject.tag == "Bad")
            {
                Manager.points += 1;
            }

            if (badcheck == false && this.gameObject.tag == "Bad")
            {
                Manager.points -= 1;
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
