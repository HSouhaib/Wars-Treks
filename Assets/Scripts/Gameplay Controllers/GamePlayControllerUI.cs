using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GamePlayControllerUI : MonoBehaviour
{

    public static GamePlayControllerUI instance;

    [SerializeField]
    private Text waveInfoTxt, shipsDestroyedInfoTxt, meteorsDestroyedInfoTxt;

    private int waveCount, shipDestroyedCount, meteorDestroyedCount;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // public void SetWave(){
    //    waveCount++;
    //    waveInfoTxt.text = "Wave:" + waveCount;
   
    // }

    //public void SetShipDestroyed()
    //{
    //    shipDestroyedCount++;
     
    //    shipsDestroyedInfoTxt.text = shipDestroyedCount + "x";
    // }

    //public void SetMeteorsDestroyed ()
    //{
    //    meteorDestroyedCount++;
    //    meteorsDestroyedInfoTxt.text = meteorDestroyedCount + "x";
    
    //} 

    public int GetShipsDestroyedCount()
    {
        return shipDestroyedCount;
    }

    public int GetMeteorsDestroyedCount()
    {
        return meteorDestroyedCount;
    }

    public int GetWaveCount()
    {
        return waveCount;
    }

    public void SetInfoUI(int infoType)
    {
        switch(infoType)
        {
            case 1:
                waveCount++;
                waveInfoTxt.text = "Wave:" + waveCount;
                break;
            case 2:
                shipDestroyedCount++;
                shipsDestroyedInfoTxt.text = shipDestroyedCount + "x";
                break;
            case 3:
                meteorDestroyedCount++;
                meteorsDestroyedInfoTxt.text = meteorDestroyedCount + "x";
                break;

        }
    }

}//classs 














