using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI m_ScoreText;

    public void SetValue(int _newValue)
    { 
        m_ScoreText.text = $"{_newValue}";
    }
}
