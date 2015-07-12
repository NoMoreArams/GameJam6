using UnityEngine;
using System.Collections;

public class PanelOptions : MonoBehaviour {


    public void OnCLickPlay()
    {
        Application.LoadLevel(3);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
