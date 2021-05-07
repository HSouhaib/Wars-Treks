using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverControllerUi : MonoBehaviour
{
    public static GameOverControllerUi instance;
    [SerializeField]
    private Canvas playerInfoCanvas, shipAndMeteorInfoCanvas, gameOverCanvas;

    [SerializeField]
    private Text shipsDestroyedFinalInfoTxt, meteorsDestroyedFinalInfoTxt, waveFinalInfoTxt;

    [SerializeField]
    private Text shipsDestroyedHighScoreTxt, meteorDestroyedHighscoreTxt, waveHighScoreTxt;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void OpenGameOverPanel()
    {
        playerInfoCanvas.enabled = false;
        shipAndMeteorInfoCanvas.enabled = false;
        //shortCUT 
        //playerInfoCanvas.enabled = shipAndMeteorInfoCanvas.enabled = false;
        gameOverCanvas.enabled = true;

        int shipsDestroyedFinal = GamePlayControllerUI.instance.GetShipsDestroyedCount();
        int meteorsDestryedFinal = GamePlayControllerUI.instance.GetMeteorsDestroyedCount();
        int wavesCountFinal = GamePlayControllerUI.instance.GetWaveCount();

        wavesCountFinal--;

        shipsDestroyedFinalInfoTxt.text = "x" + shipsDestroyedFinal;
        meteorsDestroyedFinalInfoTxt.text = "x" + meteorsDestryedFinal;
        waveFinalInfoTxt.text = "wave: " + wavesCountFinal;

        //calculate highscore 
        CalculateHighScore(shipsDestroyedFinal, meteorsDestryedFinal, wavesCountFinal);
    }

    public void PlayAgaine()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void CalculateHighScore(int shipsDestroyedCurrent, int meteorsDestroyedCurrent, int waveCountCurrent)
    {
        int shipsDestroyed_HighScore = DataManagerScript.GetData(TagMnager.SHIPS_DESTROYED_DATA);
        int meteorsDestroyed_HighScore = DataManagerScript.GetData(TagMnager.METEORS_DESTROYED_DATA);
        int waveCount_HighScore = DataManagerScript.GetData(TagMnager.WAVE_NUMBER_DATA);

        if (shipsDestroyedCurrent > shipsDestroyed_HighScore)
            DataManagerScript.SaveData(TagMnager.SHIPS_DESTROYED_DATA, shipsDestroyedCurrent);
        if (meteorsDestroyedCurrent > meteorsDestroyed_HighScore)
            DataManagerScript.SaveData(TagMnager.METEORS_DESTROYED_DATA, meteorsDestroyedCurrent);
        if (waveCountCurrent > waveCount_HighScore)
            DataManagerScript.SaveData(TagMnager.WAVE_NUMBER_DATA, waveCountCurrent);

        shipsDestroyedHighScoreTxt.text = "x" + DataManagerScript.GetData(TagMnager.SHIPS_DESTROYED_DATA);
        meteorDestroyedHighscoreTxt.text ="x" + DataManagerScript.GetData(TagMnager.METEORS_DESTROYED_DATA);
        waveHighScoreTxt.text = "wave: " + DataManagerScript.GetData(TagMnager.WAVE_NUMBER_DATA);

    }
}
