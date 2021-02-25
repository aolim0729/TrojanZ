using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void Bye()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
