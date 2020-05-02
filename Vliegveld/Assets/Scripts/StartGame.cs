﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : Button
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
        SceneManager.LoadScene(sceneName: "InGame");
    }

    private void OnMouseDrag()
    {
        Clicky();
    }
}
