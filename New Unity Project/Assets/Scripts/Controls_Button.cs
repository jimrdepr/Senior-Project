using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controls_Button : MonoBehaviour
{
    public void SeeControls()
    {
        SceneManager.LoadScene("Controls");
    }
}
