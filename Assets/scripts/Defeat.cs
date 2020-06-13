using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Defeat : MonoBehaviour {

    public Player player1;
    public Player player2;
    public GameObject DefeatPanel;
	
	void Update ()
    {
	   if(player1.hp<=0 && player2.hp<=0)
        {
            DefeatPanel.SetActive(true);
        } 
	}

    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
