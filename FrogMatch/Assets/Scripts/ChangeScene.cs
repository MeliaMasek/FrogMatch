using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//code borrowed from Jessespike on Unity Answers https://answers.unity.com/questions/1165543/sound-on-button-onclick-and-loading-and-scene.html
//code borrowed from Hooson "Change Scene On Button Click In 2 Minutes - Easy Unity Tutorial" https://www.youtube.com/watch?v=EMo-MaKkP9s//
public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        StartCoroutine(DelaySceneLoad(sceneID));
        //SceneManager.LoadScene(sceneID);
    }
    
    IEnumerator DelaySceneLoad(int sceneID)
    {
        yield return new WaitForSeconds(.25f);
        SceneManager.LoadScene(sceneID);
    }
}