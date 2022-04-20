using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


[CustomEditor(typeof(Conversation))]
[CanEditMultipleObjects]
public class ConversationsEditor : Editor
{
    SerializedProperty onStartConversation;
    SerializedProperty onNextLine;
    SerializedProperty onEndConversation;

    bool showEvents = false;


    private void OnEnable()
    {
        onStartConversation = serializedObject.FindProperty("onStartConversation");
        onNextLine = serializedObject.FindProperty("onNextLine");
        onEndConversation = serializedObject.FindProperty("onEndConversation");

    }

    public override void OnInspectorGUI()
    {
        var t = (target as Conversation);
        serializedObject.Update();

        t.talker = (Conversation.Talker)EditorGUILayout.EnumPopup("Talker", t.talker);
        GUILayout.Space(10);
        t.TalkerName = EditorGUILayout.TextField("Talker Name", t.TalkerName);
        GUILayout.Space(10);

        for (int i = 0; i < t.Lines.Count; i++)
        {
            t.Lines[i] = EditorGUILayout.TextField("Line " + i, t.Lines[i]);
        }
        GUILayout.BeginHorizontal();


        if (GUILayout.Button("Add Line"))
        {
            t.Lines.Add("");
        }

        if (GUILayout.Button("Remove Line"))
        {
            t.Lines.RemoveAt(t.Lines.Count - 1);
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(10);

        showEvents = EditorGUILayout.Foldout(showEvents, "Events");

        if (showEvents)
        {
            EditorGUILayout.PropertyField(onStartConversation);
            EditorGUILayout.PropertyField(onNextLine);
            EditorGUILayout.PropertyField(onEndConversation);
        }









        if (GUI.changed)
        {
            EditorUtility.SetDirty(t);
        }

        serializedObject.ApplyModifiedProperties();



    }
}
