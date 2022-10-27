using UnityEngine;
using UnityEngine.SceneManagement;

//Code borrowed and modified from https://github.com/kurtkaiser/MemoryVideoTutorial/blob/master/Scriptes/MainToken.cs//
public class CardFlip : MonoBehaviour
{
    GameObject gamecontrol;
    public SpriteRenderer card;
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
       SceneManager.GetActiveScene(); SceneManager.LoadScene(2);
    }
}