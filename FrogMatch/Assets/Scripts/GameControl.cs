using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Code borrowed and modified from https://github.com/kurtkaiser/MemoryVideoTutorial/blob/master/Scriptes/GameControl.cs//
//Code borrowed and modified from https://github.com/kurtkaiser/Scaleable-Memory/blob/main/Assets/Scripts/GameControl.cs//
public class GameControl : MonoBehaviour
{
    public GameObject card;
    public Animator Gameover;
    public Animator GameWon;
    public AudioSource MatchSound;
    public AudioSource NoMatchSound;
    public AudioSource GameOverSound;
    public bool activePlay;
    
    List<int> frontIndex = new() { 0, 1, 2, 3, 4, 0, 1, 2, 3, 4 };
    public static System.Random rnd = new();
    public int shuffleNum = 0;
    
    CardFlip cardOne = null;
    CardFlip cardTwo = null;
    
    private int clicks;
    public Text scoreLabel;
    private IntData clicksHigh;
    public IntData scoreLabelHigh;
    private int pairs;
    public Text pairsLabel;
    
    public void Start()
    {
        activePlay = true;
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
            //temp.GetComponent<CardFlip>().name = "card" + i;
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
    
    public void AddVisibleFace(CardFlip tempCard)
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

    public bool RemoveVisibleFace(CardFlip tempCard)
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
            if (activePlay == false)
            {
                return;
            }
        
        {
            clicks++;
            scoreLabel.text = " " + (20 - clicks);
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
        
        if (scoreLabel.text == " " + (0) && pairsLabel.text != " " + (5))
        {
            GameOver();
        }
        
        if (pairsLabel.text == " " + (5))
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
        activePlay = false;
    }

    private void Gamewon()
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