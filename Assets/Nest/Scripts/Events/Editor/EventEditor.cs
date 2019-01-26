using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Event))]
public class EventEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Event e = target as Event;

        if (GUILayout.Button("Raise Event"))
            e.Raise();
    }
}
