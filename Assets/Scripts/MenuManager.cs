﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void menuMan() {
        SceneManager.LoadScene("SampleScene");
    }

    public void exit(){
        Application.Quit();
    }
}
