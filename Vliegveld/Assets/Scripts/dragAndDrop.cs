using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAndDrop : MonoBehaviour
{
    StateManager manager;
    private bool dragging;

    public GameObject Poof;
    public Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        Poof = transform.GetChild(1).gameObject;
        anim = Poof.GetComponent<Animator>();
        manager = FindObjectOfType<StateManager>();
    }

    private void OnMouseDown()
    {
        anim.Play("PoofLeegAnim");
    }

    private void OnMouseDrag()
    {
        dragging = true;
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        transform.localScale = new Vector3(2, 2, 1);
        transform.GetComponent<SpriteRenderer>().sortingOrder = 9;

        if (this.transform.position.x > 16f)
            transform.position = new Vector3(16f, transform.position.y, transform.position.z);

        if (this.transform.position.x < 3f)
            transform.position = new Vector3(3f, transform.position.y, transform.position.z);

        if (this.transform.position.y > 8f)
            transform.position = new Vector3(transform.position.x, 8f, transform.position.z);

        if (this.transform.position.y < -8f)
            transform.position = new Vector3(transform.position.x, -8f, transform.position.z);
    }

    private void OnMouseUp()
    {
        dragging = false;
        transform.localScale = new Vector3(1.5f, 1.5f, 1);
        transform.GetComponent<SpriteRenderer>().sortingOrder = -4;
        anim.SetTrigger("DoThePoof");
        manager.PlaySound("Item");
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        Debug.Log(transform.position.x);
    }
}
