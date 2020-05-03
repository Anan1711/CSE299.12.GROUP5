using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NScoreManager : MonoBehaviour
{
    public static NScoreManager instance;
    public TextMeshProUGUI text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void ChangeScore(int CoinValue)
    {
        score += CoinValue;
        text.text =( "X" + score.ToString());
    }


}