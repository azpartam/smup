using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnClickQuitButton()
    {
        GameMananger.Instance.QuitGame();
    }
    public void OnClickStartButton()
    {
        GameMananger.Instance.StartGame();
    }
}
