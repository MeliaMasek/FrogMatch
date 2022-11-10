using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Code borrowed from and modified https://github.com/kurtkaiser/MemoryVideoTutorial/blob/master/Scriptes/GameControl.cs//
//Code borrowed and modified from https://github.com/kurtkaiser/Scaleable-Memory/blob/main/Assets/Scripts/GameControl.cs//

public class GameControlHard : MonoBehaviour
{
    public GameObject card;
    public Animator Gameover;
    public Animator GameWon;
    public AudioSource MatchSound;
    public AudioSource NoMatchSound;
    public AudioSource GameOverSound;    
    
    List<int> frontIndex = new() { 0, 0, 1, 1, 2, 3, 4, 5, 6, 7, 7, 8, 0, 0, 1, 1, 2, 3, 4, 5, 6, 7, 7, 8};
    public static System.Random rnd = new();
    public int shuffleNum = 0;
    
    CardFlipHard cardOne = null;
    CardFlipHard cardTwo = null;

    private int clicks;
    public Text scoreLabel;
    private IntData clicksHigh;
    public IntData scoreLabelHigh;
    private int pairs;
    public Text pairsLabel;

    public void Start()
    {
        Gameover.Play("GameoverOff");
        GameWon.Play("GameWonOff");
        int startTotal = frontIndex.Count;
        float xPos = -1.85f;
        float yPos = 2.1f;
        for (int i = 0; i < (startTotal - 1); i++)
        {
            shuffleNum = rnd.Next(0, (frontIndex.Count));
            var temp = Instantiate(card, new Vector3(xPos, yPos, 0), Quaternion.identity);
            temp.GetComponent<CardFlipHard>().frontIndex = frontIndex[shuffleNum];
            temp.GetComponent<CardFlipHard>().name = "card" + i;
            frontIndex.Remove(frontIndex[shuffleNum]);
            xPos = xPos + 1.25f;

            if(i == 4 || i == 10 || i == 16)
            {
                xPos = -3.10f;
                yPos = yPos - 1.7f;
            }
        }
        card.GetComponent<CardFlipHard>().frontIndex = frontIndex[0];
    }

    public void AddVisibleFace(CardFlipHard tempCard)
    {
        if (cardOne == tempCard)
        {
            cardOne = null;
        }
        if (cardTwo == tempCard)
        {
            cardTwo = null;
        }
    }

    public bool RemoveVisibleFace(CardFlipHard tempCard)
    {
        bool flipCard = true;
        if (cardOne == null)
        {
            cardOne = tempCard;
        }
        else if(cardTwo == null)
        {
            cardTwo = tempCard;
        }
        else
        {
            flipCard = false;
        }
        return flipCard;
    }

    public void CheckMatch()
    {
        if (Input.GetMouseButtonDown(0))
        //if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            clicks++;
            scoreLabel.text = " " + (40 - clicks);
        }

        if (cardOne != null && cardTwo != null && cardOne.frontIndex == cardTwo.frontIndex)
        {
            cardOne.matched = true;
            cardTwo.matched = true;
            cardOne = null;
            cardTwo = null;
            pairs++;
            pairsLabel.text = " " + (pairs);
            MatchSound.Play();
        }
        
        if (cardOne != null && cardTwo != null && cardOne.frontIndex != cardTwo.frontIndex)
        {
            NoMatchSound.Play();
        }
        
        if (scoreLabel.text == " " + (0) && pairsLabel.text != " " + (12))
        {
            GameOver();
        }
        
        if (pairsLabel.text == " " + (12))
        {
            Gamewon();
        }
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
    
    private void Gamewon()
    {
        GameWon.Play("GameWonOn");
        Gameover.Play("GameoverOff");
        if (clicks > (40 - clicks))
        {
            if (scoreLabelHigh.value < (40 - clicks))
            {
                scoreLabelHigh.value = (40 - clicks);
            }
        }
    }
}