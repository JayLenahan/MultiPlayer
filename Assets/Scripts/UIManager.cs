using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  public static UIManager instance;
  public static GameObject LoginCanvas;

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
    LoginCanvas = GameObject.Find("MainPanel");
    DontDestroyOnLoad(this);
  }
}
