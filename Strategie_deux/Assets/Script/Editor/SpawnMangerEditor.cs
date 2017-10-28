using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;

[CustomEditor(typeof(SpawnManager))]
[CanEditMultipleObjects]
public class SpawnMangerEditor : Editor
{
    private SerializedProperty List;
    private int ListSize;
    private GUIStyle style;

    void OnEnable() {
        List = serializedObject.FindProperty("objectPool");

        style = new GUIStyle();
        style.alignment = TextAnchor.MiddleCenter;
        style.fontStyle = FontStyle.Bold;
    }

    public override void OnInspectorGUI() {
        //Update our list
        serializedObject.Update();

        //Choose how to display the list<> Example purposes only
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        //add a new item to the List<> with a button
        style.normal.textColor = GUI.skin.label.normal.textColor;
        EditorGUILayout.LabelField("List Size", style);

        ListSize = List.arraySize;
        ListSize = EditorGUILayout.IntField("Size : ", ListSize);

        if (GUILayout.Button("Add New")) {
            ListSize++;
        }
        else if (GUILayout.Button("Delete All")) {
            ListSize = 0;
        }

        //Resize your list
        if (ListSize != List.arraySize)
        {
            while (ListSize > List.arraySize)
            {
                List.InsertArrayElementAtIndex(List.arraySize);
            }
            while (ListSize < List.arraySize)
            {
                List.DeleteArrayElementAtIndex(List.arraySize - 1);
            }
        }

        style.normal.textColor = Color.gray;
        if (ListSize != 0)
            EditorGUILayout.LabelField("____________________________________________________________________________", style);

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        //Display our list to the inspector window
        for (int i = 0; i < List.arraySize; i++) {
            SerializedProperty ListRef = List.GetArrayElementAtIndex(i);
            SerializedProperty MyGO = ListRef.FindPropertyRelative("_object");

            MyGO.objectReferenceValue = EditorGUILayout.ObjectField("GameObject : ", MyGO.objectReferenceValue, typeof(GameObject), true);

            EditorGUILayout.Space();

            //Remove this index from the List
            if (GUILayout.Button("Remove at index (" + i.ToString() + ")")) {
                List.DeleteArrayElementAtIndex(i);
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
        }

        //Apply the changes to our list
        serializedObject.ApplyModifiedProperties();
    }
}
