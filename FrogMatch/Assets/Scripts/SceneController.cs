using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//code borrowed from Stephen Barr from "Make a Simple Card Game in Unity | Book Club Tutorials" https://www.youtube.com/watch?v=E1nO1PbQFXw//
public class SceneController : MonoBehaviour
{
    public const int gridRows = 2;
    public const int gridCols = 5;
    public const float offsetX = 4f;
    public const float offsetY = -5f;

    public int shuffleNum = 0;
    public static System.Random rnd = new();
    List<int> frontIndex = new() {0, 1, 2, 3, 4, 0, 1, 2, 3, 4};

    public MainCard originalCard;
    public Sprite[] images;

    private void Start()
    {
        Vector3 startPos = originalCard.transform.position; //The position of the first card. All other cards are offset from here.

        //int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3};
        //numbers = ShuffleArray(numbers);
        
        for(int j = 0; j < (gridRows); j++)
        {
            for(int i = 0; i < (gridCols); i++)
            {
                MainCard card;
                if(i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard);
                }

                
                if (((j * gridRows) + i) == (gridRows * gridCols) - 1)           
                {
                    break;
                }
                
                ShuffleNum = rnd.Next(0, (frontIndex.Count));
                
                //temp.GetComponent<MainCard>().frontIndex = frontIndex[shuffleNum];
                //frontIndex.Remove(frontIndex[shuffleNum]);
                
                //int index = ((j * gridRows) + i);
                
                int id = frontIndex[shuffleNum];
                card.ChangeSprite(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
        //card.GetComponent<MainCard>().frontIndex = frontIndex[0];
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for(int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }
    
    private MainCard _firstRevealed;
    private MainCard _secondRevealed;

    private int score = 0;
    public Text scoreLabel;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public int ShuffleNum
    {
        get => shuffleNum;
        set => shuffleNum = value;
    }

    public void CardRevealed(MainCard card)
    {
        if(_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if(_firstRevealed.id == _secondRevealed.id)
        {
            score++;
            scoreLabel.text = "Score: " + score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;

    }

    public void Replay()
    {
        SceneManager.LoadScene("FrogMatchEasy");
    }
}

