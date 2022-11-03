using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Code borrowed from and modified https://github.com/kurtkaiser/MemoryVideoTutorial/blob/master/Scriptes/GameControl.cs//
public class GameControlHard : MonoBehaviour
{
    GameObject card;
    List<int> frontIndex = new() { 0, 0, 1, 1, 2, 3, 4, 5, 6, 7, 7, 8, 0, 0, 1, 1, 2, 3, 4, 5, 6, 7, 7, 8};
    public static System.Random rnd = new();
    public int shuffleNum = 0;
    int[] visibleFront = { -1, -2 };
    public AudioSource MatchSound;
    public AudioSource GameOverSound;
    private int clicks;
    private int clicksHigh;
    private int pairs;
    public Text pairsLabel;
    public Text scoreLabel;
    public Text scoreLabelHigh;
    public Sprite back;
    public Animator Gameover;
    public Animator GameWon;

    public void Start()
    {
        Gameover.Play("GameoverOff");
        GameWon.Play("GameWonOff");
        int startTotal = frontIndex.Count;
        float xPos = -1.85f;
        float yPos = 2.31f;
        for (int i = 0; i < (startTotal - 1); i++)
        {
            shuffleNum = rnd.Next(0, (frontIndex.Count));
            var temp = Instantiate(card, new Vector3(xPos, yPos, 0), Quaternion.identity);
            temp.GetComponent<CardFlipHard>().frontIndex = frontIndex[shuffleNum];
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

        if (Input.GetMouseButtonDown(0))
        //if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            clicks++;
            scoreLabel.text = " " + (40 - clicks);
            scoreLabelHigh.text = " " + (clicksHigh);
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
        
        if (scoreLabel.text == " " + (0) && pairsLabel.text != " " + (12))
        {
            GameOver();
        }
        
        if (pairsLabel.text == " " + (12))
        {
            Gamewon();
        }
        return match;
    }

    private void Awake()
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
        //GameOverSound.Play();
    }
}