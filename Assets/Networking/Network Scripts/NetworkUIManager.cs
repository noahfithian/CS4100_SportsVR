using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class NetworkUIManager : MonoBehaviour
{
    [SerializeField]
    private string minigameScene;

    public void JoinGame() {
        NetworkManager.Singleton.StartClient();
        SceneManager.LoadScene(minigameScene);
    }

    public void HostGame() {
        NetworkManager.Singleton.StartHost();
        SceneManager.LoadScene(minigameScene);
    }
    
    public void QuitGameClient()
    {
        NetworkManager.Singleton.Shutdown();
        Debug.Log("Player Ended Game");
    }

    public void QuitGameHost()
    {
        NetworkManager.Singleton.Shutdown();
        Debug.Log("Host Ended Game");
    }
}
