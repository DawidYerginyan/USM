using UnityEngine;
using UnityEditor;

namespace USM.Unity.Middleware
{
  public partial class USMDevTools : EditorWindow
  {
    string stateString = "";

    void stateTab()
    {
      Color bgColor = GUI.backgroundColor;

      GUIStyle font = new GUIStyle(GUI.skin.label);
      font.fontStyle = FontStyle.Bold;
      font.normal.textColor = Color.white;
      font.fontSize = 14;

      GUIStyle boxStyle = new GUIStyle(GUI.skin.box);
      boxStyle.padding = new RectOffset(20, 20, 20, 20);

      GUI.backgroundColor = new Color(0, 0, 0, .7f);
      scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, boxStyle, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
      GUILayout.Label(stateString, font);
      EditorGUILayout.EndScrollView();
      GUI.backgroundColor = bgColor;
    }

    public void setStateString(string stateString)
    {
      this.stateString = stateString;
    }
  }
}
