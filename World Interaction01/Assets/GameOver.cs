using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverUI;

    void Update()
    {
        // is player dead
        //GameOverUI.SetActive(true);
        //Time.timeScale = 0f;
    }
    // if dead and health = zero
    // gg and gameover
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuDD");
    }


}
