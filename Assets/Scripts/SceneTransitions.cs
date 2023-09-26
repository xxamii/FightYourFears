using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : Singleton<SceneTransitions>
{
    [SerializeField] private Scene _currentScene;
    [SerializeField] private SceneFader _fader;

    public Scene CurrentScene => _currentScene;

    public event Action OnSceneLoaded;
    public event Action OnSceneUnloaded;

    private bool _canLoad = true;

    [SerializeField] private Scene _startScene;
    private Scene _sceneToLoad;

    private void Start()
    {
        if (_startScene != Scene.None)
        {
            LoadScene(_startScene);
        }
    }

    public void Restart()
    {
        LoadScene(_currentScene);
    }

    public void LoadScene(Scene scene)
    {
        if (_canLoad)
        {
            if (_currentScene != Scene.None)
            {
                UnloadScene(_currentScene);
            }

            _sceneToLoad = scene;
            _fader.FadeOut();
        }
    }

    public void LoadCurrent()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneToLoad.ToString(), LoadSceneMode.Additive);

        if (operation != null)
        {
            _currentScene = _sceneToLoad;
            _canLoad = false;
            operation.completed += OnLoadSceneComplete;
        }
        else
        {
            Debug.LogError("Could not load scene " + _sceneToLoad.ToString());
        }
    }

    public void UnloadScene(Scene scene)
    {
        if (scene != Scene.None)
        {
            AsyncOperation operation = SceneManager.UnloadSceneAsync(scene.ToString());

            if (operation == null)
            {
                Debug.LogError("Could not unload scene" + scene.ToString());
            }
            else
            {
                operation.completed += OnUnloadSceneComplete;
            }
        }

    }

    private void OnLoadSceneComplete(AsyncOperation operation)
    {
        OnSceneLoaded?.Invoke();
        _canLoad = true;
        _currentScene = _sceneToLoad;
        _sceneToLoad = Scene.None;
        _fader.FadeIn();
    }

    private void OnUnloadSceneComplete(AsyncOperation operation)
    {
        OnSceneUnloaded?.Invoke();
    }
}
