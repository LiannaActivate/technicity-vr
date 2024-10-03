using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void GoToStartingClassroomScene()
    {
        SceneManager.LoadScene("_StartingClassroomScene(MainMenu)");
    }
}