using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAndDrop : MonoBehaviour
{
    private bool dragging;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dragging == false)
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if (this.transform.position.x > 16.5f)
            transform.position = new Vector3(16.5f, transform.position.y, transform.position.z);

        if (this.transform.position.x < 2.5f)
            transform.position = new Vector3(2.5f, transform.position.y, transform.position.z);

        if (this.transform.position.y > 8.5f)
            transform.position = new Vector3(transform.position.x, 8.5f, transform.position.z);

        if (this.transform.position.y < -8.5f)
            transform.position = new Vector3(transform.position.x, -8.5f, transform.position.z);
    }

    private void OnMouseDrag()
    {
        dragging = true;
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
