using UnityEngine;
using UnityEngine.SceneManagement;


//code borrowed from Hooson "Change Scene On Button Click In 2 Minutes - Easy Unity Tutorial" https://www.youtube.com/watch?v=EMo-MaKkP9s//
public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
