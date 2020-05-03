using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private bool zoomed = true;

    public GameObject paper;
    public GameObject paperback;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Time.deltaTime * 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(zoomed == true)
        {
            paper.transform.position = new Vector3(Mathf.Lerp(paper.transform.position.x, 0, speed), Mathf.Lerp(paper.transform.position.y, 0, speed), 0);
            paper.transform.localScale = new Vector3(Mathf.Lerp(paper.transform.localScale.x, 1, speed), Mathf.Lerp(paper.transform.localScale.y, 1, speed), 1);
            paperback.transform.GetComponent<BoxCollider2D>().enabled = true;
            paperback.transform.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, Mathf.Lerp(paperback.transform.GetComponent<SpriteRenderer>().material.color.a, 1f, Time.deltaTime * 10));
        }

        if (zoomed == false)
        {
            paper.transform.position = new Vector3(Mathf.Lerp(paper.transform.position.x, 2, speed), Mathf.Lerp(paper.transform.position.y, 8, speed), 0);
            paper.transform.localScale = new Vector3(Mathf.Lerp(paper.transform.localScale.x, 0.2f, speed), Mathf.Lerp(paper.transform.localScale.y, 0.2f, speed), 1);
            paperback.transform.GetComponent<BoxCollider2D>().enabled = false;
            paperback.transform.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, Mathf.Lerp(paperback.transform.GetComponent<SpriteRenderer>().material.color.a, 0f, Time.deltaTime * 10));
        }
    }

    private void OnMouseUp()
    {
        zoomed = !zoomed;
    }
}
