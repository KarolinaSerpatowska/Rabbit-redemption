using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;

    public bool ispausa = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && ispausa==false)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
            ispausa = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ispausa == true)
        {
            menu.SetActive(false);
            Time.timeScale = 1;
            ispausa = false;
        }
    }

    public void Continue()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void End()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
