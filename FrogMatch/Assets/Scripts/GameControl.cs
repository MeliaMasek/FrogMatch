using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Code borrowed and modified from https://github.com/kurtkaiser/MemoryVideoTutorial/blob/master/Scriptes/GameControl.cs//
public class GameControl : MonoBehaviour
{
    public GameObject card;
    List<int> frontIndex = new() { 0, 1, 2, 3, 4, 0, 1, 2, 3, 4 };
    public static System.Random rnd = new();
    public int shuffleNum = 0;
    int[] visibleFront = { -1, -2 };
    public AudioSource MatchSound;
    public AudioSource GameOverSound;
    private int clicks;
    private IntData clicksHigh;
    private int pairs;
    public Text pairsLabel;
    public Text scoreLabel;
    public IntData scoreLabelHigh;
    public Sprite back;
    public Animator Gameover;
    public Animator GameWon;
    public GameObject CanvasHighscore;
    public void Start()
    {
        Gameover.Play("GameoverOff");
        GameWon.Play("GameWonOff");
        int startTotal = frontIndex.Count;
        float xPos = -1.5f;
        float yPos = 1.3f;
        for (int i = 0; i < (startTotal - 1); i++)
        {
            shuffleNum = rnd.Next(0, (frontIndex.Count));
            var temp = Instantiate(card, new Vector3(xPos, yPos, 0), Quaternion.identity);
            temp.GetComponent<CardFlip>().frontIndex = frontIndex[shuffleNum];
            temp.GetComponent<CardFlip>().name = "card" + i;
            frontIndex.Remove(frontIndex[shuffleNum]);
            xPos = xPos + 1.5f;
            
            if (i == (startTotal / 2 - 2))
            {
                xPos = -3f;
                yPos = -1.3f;
            }
        }
        card.GetComponent<CardFlip>().frontIndex = frontIndex[0];
    }
    
    public bool TwoCards()
    {
        bool cardsup = visibleFront[0] >= 0 && visibleFront[1] >= 0;
        return cardsup;
    }

    public void AddVisibleFace(int index)
    {
        if (visibleFront[0] == -1)
        {
            visibleFront[0] = index;
        }
        else if (visibleFront[1] == -2)
        {
            visibleFront[1] = index;
        }
    }

    public void RemoveVisibleFace(int index)
    {
        if (visibleFront[0] == index)
        {
            visibleFront[0] = -1;
        }
        else if (visibleFront[1] == index)
        {
            visibleFront[1] = -2;
        }
    }

    public bool CheckMatch()
    {
        bool match = false;
        //GetComponent<CardFlip>().FlipBackOver();

        if (Input.GetMouseButtonDown(0))
        //if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            clicks++;
            scoreLabel.text = " " + (20 - clicks);
            //scoreLabelHigh.text = " " + (clicksHigh);
        }
        
        if (visibleFront[0] == visibleFront[1])
        {
            visibleFront[0] = -1;
            visibleFront[1] = -2;
            match = true;
            pairs++;
            pairsLabel.text = " " + (pairs);
            MatchSound.Play();
        }
        if (scoreLabel.text == " " + (0) && pairsLabel.text != " " + (5))
        {
            GameOver();
        }
        
        if (pairsLabel.text == " " + (5))
        {
            Gamewon();
        }
        return match;
    }

    public void Awake()
    {
        card = GameObject.Find("Card");
    }

    private void GameOver()
    {
       Gameover.Play("GameoverOn");
       GameOverSound.Play();
    }

    public void Gamewon()
    {
        GameWon.Play("GameWonOn");
        Gameover.Play("GameoverOff");
        if (clicks > (20 - clicks))
        {
            if (scoreLabelHigh.value < (20 - clicks))
            {
                scoreLabelHigh.value = (20 - clicks);
            }
        }
    }
}