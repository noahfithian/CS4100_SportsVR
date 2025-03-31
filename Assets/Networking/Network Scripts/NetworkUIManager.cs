using UnityEngine;
using Unity.Netcode;

public class NetworkUIManager : MonoBehaviour
{
    public void JoinGame() => NetworkManager.Singleton.StartClient();
    public void HostGame() => NetworkManager.Singleton.StartHost();
    
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
