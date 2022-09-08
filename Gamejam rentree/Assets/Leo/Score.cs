using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreLeft;
    public TextMeshProUGUI ScoreRight;
    public float Multiplier = 1;
    private float Scoring = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.instance.canMove)
        {
            Scoring += Time.deltaTime * 100 * Multiplier;
            Scoring = UnityEngine.Mathf.Round(Scoring);
            UpdateScore();
        }
    }
    void UpdateScore()
    {
        ScoreRight.text = Scoring.ToString();
    }
}
