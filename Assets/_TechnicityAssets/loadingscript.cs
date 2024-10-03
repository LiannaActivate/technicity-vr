using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingBar : MonoBehaviour
{
    public Slider loadingSlider;
    public float loadingSpeed = 0.5f;

    private void Awake() // Changed from Start to Awake
    {
        StartCoroutine(LoadAndTransition());
    }

    private IEnumerator LoadAndTransition()
    {
        loadingSlider.value = 0;

        while (loadingSlider.value < 1f)
        {
            loadingSlider.value += loadingSpeed * Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene("_StartingClassroomScene(MainMenu)");
    }
}