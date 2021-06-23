using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;

  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else if (instance != this)
    {
      Debug.Log("Instance already exists, destroying object!");
      Destroy(this);
    }
    DontDestroyOnLoad(this);
  }

  private void Update()
  {
    if (NetworkManager.Singleton.IsServer)
    {
      UIManager.LoginCanvas.SetActive(false);
    }
  }



  void OnGUI()
  {
    GUILayout.BeginArea(new Rect(10, 10, 300, 300));
    if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
    {
      StartButtons();
    }
    else
    {
      StatusLabels();

      SubmitNewPosition();
    }

    GUILayout.EndArea();
  }

  static void StartButtons()
  {
    if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
  }

  public void ConnectedToServer()
  {
    NetworkManager.Singleton.StartClient();
  }

  static void StatusLabels()
  {
    var mode = NetworkManager.Singleton.IsHost ?
        "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

    GUILayout.Label("Transport: " +
        NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
    GUILayout.Label("Mode: " + mode);
  }

  static void SubmitNewPosition()
  {
    if (GUILayout.Button(NetworkManager.Singleton.IsServer ? "Move" : "Request Position Change"))
    {
      if (NetworkManager.Singleton.ConnectedClients.TryGetValue(NetworkManager.Singleton.LocalClientId,
          out var networkedClient))
      {
        var player = networkedClient.PlayerObject.GetComponent<NetworkPlayer>();
        if (player)
        {
          player.Move();
        }
      }
    }
  }

  public void QuitGame()
  {
    Application.Quit();
  }
}
