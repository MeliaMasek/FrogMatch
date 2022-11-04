using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//Code borrowed and modified from https://github.com/kurtkaiser/MemoryVideoTutorial/blob/master/Scriptes/MainToken.cs//
public class CardFlipMed : MonoBehaviour
{
    GameObject gamecontrol;
    
    public SpriteRenderer card;
    public Sprite[] fronts;
    public Sprite back;
    public AudioSource NoMatchSound;
    public int frontIndex;

    private bool matched = false;

    public void OnMouseDown()
    {
        if (matched == false)
        {
            if (card.sprite == back)
            {
                if (gamecontrol.GetComponent<GameControlMed>().TwoCards() == false)
                {
                    card.sprite = fronts[frontIndex];
                    gamecontrol.GetComponent<GameControlMed>().AddVisibleFace(frontIndex);
                    matched = gamecontrol.GetComponent<GameControlMed>().CheckMatch();

                    if (gamecontrol.GetComponent<GameControlMed>().TwoCards() == true && matched == false)
                    {
                        NoMatchSound.Play();
                    }
                }
            }
            else
            {
                card.sprite = back;
                gamecontrol.GetComponent<GameControlMed>().RemoveVisibleFace(frontIndex);
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
        gamecontrol.GetComponent<GameControlMed>().Awake();
        StartCoroutine(DelaySceneLoad());
    }
    
    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(.15f);
        SceneManager.LoadScene(3);
    }
}