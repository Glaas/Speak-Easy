using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


[CustomEditor(typeof(DialogueContainer))]
[CanEditMultipleObjects]
public class DialogueContainerEditor : Editor
{
    SerializedProperty conversations;

    private void OnEnable()
    {
        conversations = serializedObject.FindProperty("conversations");
    }
    public override void OnInspectorGUI()
    {
        var t = (target as DialogueContainer);
        serializedObject.Update();

        t.prefabUI = (GameObject)EditorGUILayout.ObjectField("Prefab UI", t.prefabUI, typeof(GameObject), false);

        t.NPC_color = EditorGUILayout.ColorField("NPC Color", t.NPC_color);


        for (int i = 0; i < conversations.arraySize; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(conversations.GetArrayElementAtIndex(i), new GUIContent("Conversation " + i));
            if (GUILayout.Button("Remove"))
            {
                conversations.DeleteArrayElementAtIndex(i);
            }
            EditorGUILayout.EndHorizontal();
        }
        if (GUILayout.Button("Add Conversation"))
        {
            t.conversations.Add(t.conversations[0]);
        }
        serializedObject.ApplyModifiedProperties();




    }
}
