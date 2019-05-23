using UnityEditor;
using UnityEngine;

namespace USM.Unity.Middleware
{
  public partial class USMDevTools : EditorWindow
  {
    private int tab;
    void OnGUI()
    {
      tab = GUILayout.Toolbar(tab, new string[] { "Action Log", "State Tree" });
      switch (tab)
      {
        case 1:
          stateTab();
          break;
        case 0:
        default:
          actionTab();
          break;
      }
    }

    public void OnInspectorUpdate()
    {
      Repaint();
    }
  }
}
