using UnityEngine;
using UnityEngine.SceneManagement;


//code borrowed from Hooson "Change Scene On Button Click In 2 Minutes - Easy Unity Tutorial" off of youtube.
public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
