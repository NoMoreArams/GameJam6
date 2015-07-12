using UnityEngine;
using System.Collections;

public class PanelOptions : MonoBehaviour {


    void OnCLickPlay()
    {
        Application.LoadLevel("GameScene");
    }

    void OnClickExit()
    {
        Application.Quit();
    }
}
