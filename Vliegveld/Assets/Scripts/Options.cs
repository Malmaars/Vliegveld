using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : Button
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Press();
    }

    private void OnMouseDrag()
    {
        Clicky();
    }
}
