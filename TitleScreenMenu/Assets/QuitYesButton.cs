using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitYesButton : MonoBehaviour
{

    public void OnButtonPress()
    {
        Debug.Log("click");
        Application.Quit();
    }   
}
