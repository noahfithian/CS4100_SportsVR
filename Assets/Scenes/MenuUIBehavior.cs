using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class MenuUIBehavior : MonoBehaviour
{
    [SerializeField]
    private string minigameScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        SceneManager.LoadScene(minigameScene);
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        SceneManager.LoadScene(minigameScene);
    }
}
