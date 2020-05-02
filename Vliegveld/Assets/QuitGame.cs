using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : Button
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

    private void OnMouseUp()
    {
        Application.Quit();
    }

    private void OnMouseDrag()
    {
        Clicky();
    }
}
