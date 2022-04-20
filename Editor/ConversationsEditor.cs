using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


[CustomEditor(typeof(Conversation))]
public class ConversationsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        // var t = (target as Conversation);

        // t.talker = (Conversation.Talker)EditorGUILayout.EnumPopup("Talker", t.talker);
        // GUILayout.Space(10);
        // t.TalkerName = EditorGUILayout.TextField("Talker Name", t.TalkerName);
        // GUILayout.Space(10);

        // if (t.lines.Count > 0)
        // {
        //     for (int i = 0; i < t.lines.Count; i++)
        //     {
        //         t.lines[i] = EditorGUILayout.TextField("Line " + i, t.lines[i]);
        //     }
        // }

        // GUILayout.BeginHorizontal();

        // if (GUILayout.Button("Add Line"))
        // {
        //     t.lines.Add("");
        // }

        // if (GUILayout.Button("Remove Line"))
        // {
        //     t.lines.RemoveAt(t.lines.Count - 1);
        // }
        // GUILayout.EndHorizontal();
        // GUILayout.Space(10);

        // if (GUI.changed)
        // {
        //     EditorUtility.SetDirty(t);
        // }
    }
}
