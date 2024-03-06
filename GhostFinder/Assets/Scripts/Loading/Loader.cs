using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    private class LoadingMonoBehaviour : MonoBehaviour { }

    private static Action onLoaderCallback;
    private static AsyncOperation loadingAsyncOperation;

    public enum Scene
    {
        Level0,
        Loading,
        MainMenu,
        SampleScene,        
    }

    public static void Load(Scene scene)
    {       
        onLoaderCallback = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
            
        };

        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    public static void Load(int sceneIndex)
    {
        onLoaderCallback = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(sceneIndex));
        };

        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    private static IEnumerator LoadSceneAsync(Scene scene)
    {
        yield return null;
        
        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        while(!loadingAsyncOperation.isDone) 
        { 
            yield return null;
        }
    }

    private static IEnumerator LoadSceneAsync(int sceneIndex)
    {
        yield return null;

        loadingAsyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!loadingAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static float GetLoadingProgress()
    {
        if(loadingAsyncOperation != null)
        {
            return loadingAsyncOperation.progress;
        }
        else 
        { 
            return 1.0f; 
        }
    }

    public static void LoaderCallback()
    {
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
