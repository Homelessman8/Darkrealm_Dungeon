using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndgameMenu : MonoBehaviour
{
    public GameObject endgameUI;

    void Update()
    {
        // has player reach the end
        //endgameUI.SetActive(true);
        //Time.timeScale = 0f;
    }
    public void LevelTwo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("DDFloor2");
        //endgameUI.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuDD");
    }
}
