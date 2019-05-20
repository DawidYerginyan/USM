using UnityEngine;
using UnityEditor;

public class USMDevTools : EditorWindow
{
  [MenuItem("Window/USM Developer Tools")]
  public static void open()
  {
    GetWindow<USMDevTools>("Unity State Manager Developer Tools");
  }
}
