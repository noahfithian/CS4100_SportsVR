using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class SceneChanger : NetworkBehaviour
{
    private string _sceneName;

    public void SetSceneNumberOne() => _sceneName = "Duck Dodgers";
    public void SetSceneNumberTwo() => _sceneName = "Sword Play";
    public void SetSceneNumberThree() => _sceneName = "Stack Attack";

    public void ChangeScene()
    {
        NetworkManager.Singleton.SceneManager.LoadScene(_sceneName, LoadSceneMode.Single);
    }
}
