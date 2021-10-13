using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Back_Button : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
