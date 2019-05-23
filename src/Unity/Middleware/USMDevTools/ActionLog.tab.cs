using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace USM.Unity.Middleware
{
  public partial class USMDevTools : EditorWindow
  {
    Queue<(string type, string name, string payload)> actions = new Queue<(string, string, string)>();
    Vector2 scrollPosition = new Vector2 { x = 0, y = 0 };
    int expandedAction;

    void actionTab()
    {
      Color bgColor = GUI.backgroundColor;
      Color color = GUI.color;

      GUIStyle outerBoxStyle = new GUIStyle(GUI.skin.box);
      outerBoxStyle.padding = new RectOffset(0, 0, 0, 0);

      GUIStyle font = new GUIStyle(GUI.skin.label);
      font.fontStyle = FontStyle.Bold;

      GUIStyle innerBoxStyle = new GUIStyle(GUI.skin.box);
      innerBoxStyle.padding = new RectOffset(10, 10, 5, 5);
      innerBoxStyle.margin = new RectOffset(0, 0, 0, 0);

      GUIStyle payloadBox = new GUIStyle(GUI.skin.box);
      payloadBox.padding = new RectOffset(15, 15, 15, 15);
      payloadBox.margin = new RectOffset(0, 0, 0, 0);
      payloadBox.normal.background = Texture2D.whiteTexture;

      scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

      int i = 0;
      foreach (var action in actions)
      {
        GUI.backgroundColor = new Color(0, 0, 0, .1f);
        EditorGUILayout.BeginVertical(outerBoxStyle, GUILayout.ExpandWidth(true));

        EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));

        GUI.backgroundColor = new Color(0, 0, 0, .35f);
        EditorGUILayout.BeginVertical(innerBoxStyle);
        font.normal.textColor = Color.white;
        GUILayout.Label($"[{action.type}]", font);
        EditorGUILayout.EndVertical();
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        EditorGUILayout.BeginVertical(innerBoxStyle, GUILayout.ExpandWidth(true));
        font.normal.textColor = Color.black;
        if (GUILayout.Button($"{action.name}", font))
        {
          expandedAction = i;
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndHorizontal();

        if (i == expandedAction)
        {
          GUI.backgroundColor = new Color(0, 0, 0, .7f);
          EditorGUILayout.BeginHorizontal(payloadBox, GUILayout.ExpandWidth(true));
          font.normal.textColor = Color.white;
          font.fontSize = 12;
          GUILayout.Label(action.payload, font);
          EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.EndVertical();
        GUI.backgroundColor = bgColor;

        i++;
      }

      EditorGUILayout.EndScrollView();
    }

    public void addAction(
      string actionType,
      string actionName,
      string payload
    )
    {
      if (actions.Count == 50)
      {
        actions.Dequeue();
      }

      actions.Enqueue((actionType, actionName, payload));
    }
  }
}
