using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Canvas mainMenuCanvas, highScoreCanvas;

    [SerializeField]
    private Text shipsDestroyedHighScore, meteorsDestroyedHighScore, waveSurvivedHighScore;


    private void Start()
    {

    }
    public void PlayGame()
    {
        //SceneManager.LoadScene(TagMnager.GAMEPLAY_LEVEL_NAME);
        SceneManager.LoadScene(1);
    }

    public void OpenCloseHighScoreCanvas(bool open)
    {
        mainMenuCanvas.enabled = !open;
        highScoreCanvas.enabled = open;

        if (open)
            DisplayHighScore();
    }
   
    void DisplayHighScore()
    {
        shipsDestroyedHighScore.text = "x" + DataManagerScript.GetData(TagMnager.SHIPS_DESTROYED_DATA);
        meteorsDestroyedHighScore.text = "x"  + DataManagerScript.GetData(TagMnager.METEORS_DESTROYED_DATA);
        waveSurvivedHighScore.text = "Waves Survived: " + DataManagerScript.GetData(TagMnager.WAVE_NUMBER_DATA);
    }
}// class

