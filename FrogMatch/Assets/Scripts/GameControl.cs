using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Code borrowed from https://github.com/kurtkaiser/MemoryVideoTutorial/blob/master/Scriptes/GameControl.cs//
public class GameControl : MonoBehaviour
{
    GameObject card;
    List<int> frontIndex = new() { 0, 1, 2, 3, 4, 0, 1, 2, 3, 4 };
    public static System.Random rnd = new();
    public int shuffleNum = 0;
    int[] visibleFront = { -1, -2 };
    public AudioSource MatchSound;
    private int clicks;
    private int clicksHigh;
    public Text scoreLabel;
    public Text scoreLabelHigh;
    public Sprite back;
    public Animator Gameover;

    public void Start()
    {
        Gameover.Play("GameoverOff");
        int startTotal = frontIndex.Count;
        float xPos = -3f;
        float yPos = 2f;
        for (int i = 0; i < (startTotal - 1); i++)
        {
            shuffleNum = rnd.Next(0, (frontIndex.Count));
            var temp = Instantiate(card, new Vector3(xPos, yPos, 0), Quaternion.identity);
            temp.GetComponent<CardFlip>().frontIndex = frontIndex[shuffleNum];
            frontIndex.Remove(frontIndex[shuffleNum]);
            xPos = xPos + 3;
            if (i == (startTotal / 2 - 2))
            {
                xPos = -6f;
                yPos = -2f;
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
        //Gameover.Play("GameoverOff");

        if (Input.GetMouseButtonDown(0))
            clicks++;
        scoreLabel.text = " " + (10 - clicks);
        scoreLabelHigh.text = " " + (10 - clicksHigh);

        if (visibleFront[0] == visibleFront[1])
        {
            visibleFront[0] = -1;
            visibleFront[1] = -2;
            match = true;
            MatchSound.Play();

        }
        return match;
    }

    private void Awake()
    {
        card = GameObject.Find("Card");
    }
}

