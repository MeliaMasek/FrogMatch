using System.Collections.Generic;
using UnityEngine;

//Code borrowed from https://github.com/kurtkaiser/MemoryVideoTutorial
public class GameControl : MonoBehaviour
{
    GameObject card;
    List<int> frontIndex = new() {0, 1, 2, 3, 0, 1, 2, 3};
    public static System.Random rnd = new();
    public int shuffleNum = 0;
    int[] visibleFront = { -1, -2 }; 
    
    void Start()
    {
        int startTotal = frontIndex.Count;
        float xPos = 1f;
        float yPos = 1.25f;
        for(int i = 0; i < 7; i++)
        {
            shuffleNum = rnd.Next(0, (frontIndex.Count));
            var temp = Instantiate(card, new Vector3(xPos, yPos, 0),        Quaternion.identity);
            temp.GetComponent<CardFlip>().frontIndex = frontIndex[shuffleNum];
            frontIndex.Remove(frontIndex[shuffleNum]);
            xPos = xPos + 3;
            if (i == (startTotal/2 - 2))
            {
                xPos = 1f;
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

    public void AddVisableFace(int index)
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

    public void RemoveVisableFace(int index)
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
        if (visibleFront[0] == visibleFront[1])
        {
            visibleFront[0] = -1;
            visibleFront[1] = -2;
            match = true;
        }
        return match;
    }
    
    private void Awake()
    {
        card = GameObject.Find("Card");
    }
}

