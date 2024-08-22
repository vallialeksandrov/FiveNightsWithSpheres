using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loading : MonoBehaviour
{
    private AsyncOperation asyncOperation;

    public void Start() => StartCoroutine(LoadScene());

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(6f);
        asyncOperation = SceneManager.LoadSceneAsync("Game");
        while (!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            yield return 0;
        }
    }
}
