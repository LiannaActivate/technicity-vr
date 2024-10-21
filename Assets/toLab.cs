using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader3 : MonoBehaviour
{
    public GameObject LoaderUI;
    public Slider progressSlider;

    private void Update()
    {
        // Automatically start loading if the LoaderUI is active.
        if (LoaderUI.activeSelf && !loadingStarted)
        {
            LoadScene(4); // Automatically load the scene at index 2, which is "02_MainMenu Scene" in your build settings.
        }
    }

    private bool loadingStarted = false;

    public void LoadScene(int index)
    {
        if (!loadingStarted)
        {
            loadingStarted = true;
            StartCoroutine(LoadScene_Coroutine(index));
        }
    }

    private IEnumerator LoadScene_Coroutine(int index)
    {
        progressSlider.value = 0;
        LoaderUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;
        float progress = 0;

        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;
            if (progress >= 0.9f)
            {
                progressSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
