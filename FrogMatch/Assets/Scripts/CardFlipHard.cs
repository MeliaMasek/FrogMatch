using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//Code borrowed and modified from https://github.com/kurtkaiser/MemoryVideoTutorial/blob/master/Scriptes/MainToken.cs//
//Code borrowed and modified from https://github.com/kurtkaiser/Scaleable-Memory/blob/main/Assets/Scripts/MainToken.cs//

public class CardFlipHard : MonoBehaviour
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
        gamecontrol.GetComponent<GameControlHard>().Awake();
        StartCoroutine(DelaySceneLoad());
    }
    
    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(.15f);
        SceneManager.LoadScene(4);
    }
}