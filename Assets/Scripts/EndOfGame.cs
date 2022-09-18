using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI m_FinalScoreText;
    [SerializeField]
    TMPro.TextMeshProUGUI m_FinalScreenTitle;

    private void Start()
    {
        m_FinalScoreText.SetText($"Final Score {GameMananger.Instance.Score}");
        if (GameMananger.Instance.gameState == GameMananger.GameState.GameOver)
            m_FinalScreenTitle.SetText("Game Over!");
        else if (GameMananger.Instance.gameState == GameMananger.GameState.GameFinished)
            m_FinalScreenTitle.SetText("You finished!");

    }
    

}
