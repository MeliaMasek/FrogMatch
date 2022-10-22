using UnityEngine;

//Code borrowed from https://github.com/kurtkaiser/MemoryVideoTutorial
public class CardFlip : MonoBehaviour
{
    GameObject gamecontrol; 
    SpriteRenderer card;
    public Sprite[] fronts;
    public Sprite back;
    public int frontIndex;
    public bool matched = false;
    public AudioSource NoMatchSound;

    public void OnMouseDown()
    {
        if (matched == false)
        {
            if(card.sprite == back)
            {
                if (gamecontrol.GetComponent<GameControl>().TwoCards() == false)
                {
                    card.sprite = fronts[frontIndex];
                    gamecontrol.GetComponent<GameControl>().AddVisibleFace(frontIndex);
                    matched = gamecontrol.GetComponent<GameControl>().CheckMatch();
                    
                    if (gamecontrol.GetComponent<GameControl>().TwoCards() == true && matched == false)
                    {
                        NoMatchSound.Play();
                    }
                }
            }
            else
            {
                card.sprite = back;
                gamecontrol.GetComponent<GameControl>().RemoveVisibleFace(frontIndex);
            }
        }
    }
    private void Awake()
    {
        gamecontrol = GameObject.Find("GameControl");
        card = GetComponent<SpriteRenderer>();
    }
    public void Reset()
    {
        if(card.sprite == fronts[frontIndex])
        {
            card.sprite = back;
        }
    }
} 
