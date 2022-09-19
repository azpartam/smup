using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI m_ScoreText;

    private void Start()
    {
        GameMananger.OnScoreChanged += UpdateValue;
    }
    public void UpdateValue()
    { 
        m_ScoreText.text = $"{GameMananger.Instance.Score}";
    }
    private void OnDestroy()
    {
        GameMananger.OnScoreChanged -= UpdateValue;
    }
}
