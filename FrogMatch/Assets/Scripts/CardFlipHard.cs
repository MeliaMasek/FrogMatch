using UnityEngine;

//Code borrowed and modified from https://github.com/kurtkaiser/MemoryVideoTutorial/blob/master/Scriptes/MainToken.cs//
public class CardFlipHard : MonoBehaviour
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
            if (card.sprite == back)
            {
                if (gamecontrol.GetComponent<GameControlHard>().TwoCards() == false)
                {
                    card.sprite = fronts[frontIndex];
                    gamecontrol.GetComponent<GameControlHard>().AddVisibleFace(frontIndex);
                    matched = gamecontrol.GetComponent<GameControlHard>().CheckMatch();

                    if (gamecontrol.GetComponent<GameControlHard>().TwoCards() == true && matched == false)
                    {
                        NoMatchSound.Play();
                    }
                }
            }
            else
            {
                card.sprite = back;
                gamecontrol.GetComponent<GameControlHard>().RemoveVisibleFace(frontIndex);
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
        if (card.sprite == fronts[frontIndex])
        {
            card.sprite = back;
            //GetComponent<GameControl>();
        }
    }
}