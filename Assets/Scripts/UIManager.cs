using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public EventSystemCustomLogic eventSystem;
    public Text score;
    public Text score2;
    private int localScore;
    void Start()
    {
        eventSystem.OnGroundTouch.AddListener(increaseScore);
        localScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void increaseScore()
    {
        localScore += 23;
        score.text = localScore.ToString();
        score2.text = localScore.ToString();
    }
}
