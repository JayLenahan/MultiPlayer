using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMapping : MonoBehaviour
{
  public static KeyMapping instance;

  public Dictionary<Inputs, KeyCode> KeyBindingDict = new Dictionary<Inputs, KeyCode>() {
    { Inputs.Left, KeyCode.A },
    { Inputs.Right, KeyCode.D },
    { Inputs.Up, KeyCode.W },
    { Inputs.Down, KeyCode.S },
    { Inputs.Sprint, KeyCode.LeftShift },
    { Inputs.One, KeyCode.Alpha1 },
    { Inputs.Two, KeyCode.Alpha2 },
    { Inputs.Three, KeyCode.Alpha3 },
    { Inputs.Four, KeyCode.Alpha4 },
    { Inputs.Five, KeyCode.Alpha5 },
    { Inputs.Six, KeyCode.Alpha6 },
    { Inputs.Seven, KeyCode.Alpha7 },
    { Inputs.Eight, KeyCode.Alpha8 },
    { Inputs.Inventory, KeyCode.Tab },
  };

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

  public void SetMappings()
  {

  }

  public enum Inputs
  {
    Left,
    Right,
    Up,
    Down,
    Sprint,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Inventory
  }
}