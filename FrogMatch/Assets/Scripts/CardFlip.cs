using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//Code borrowed and modified from https://github.com/kurtkaiser/MemoryVideoTutorial/blob/master/Scriptes/MainToken.cs//
//Code borrowed and modified from https://github.com/kurtkaiser/Scaleable-Memory/blob/main/Assets/Scripts/MainToken.cs//
public class CardFlip : MonoBehaviour
{
    GameObject gamecontrol;
    
    public SpriteRenderer card;
    public Sprite[] fronts;
    public Sprite back;
    public int frontIndex;

    public bool matched = false;

    public void OnMouseDown()
    {
        if (matched == false)
        {
            GameControl controlScript = gamecontrol.GetComponent<GameControl>();
            if (card.sprite == back)
            {
                if (controlScript.RemoveVisibleFace(this))
                {
                    card.sprite = fronts[frontIndex];
                    controlScript.CheckMatch();
                }
            }
            else
            {
                card.sprite = back;
                controlScript.AddVisibleFace(this);
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
        gamecontrol.GetComponent<GameControl>().Awake();
        StartCoroutine(DelaySceneLoad());
    }
    
    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(.15f);
        SceneManager.LoadScene(2);
    }
}