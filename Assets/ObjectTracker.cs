using System.Linq;
using UnityEditor;
using UnityEngine;

public class ObjectTracker: MonoBehaviour {
    private void OnDrawGizmos()
    {
        TrackObjects();
    }


    private static void TrackObjects()
    {
        MonoBehaviour[] gameObjects = FindObjectsOfType<MonoBehaviour>();
        
        foreach (MonoBehaviour mono in gameObjects)
        {
            var attributes = mono
                .GetType()
                .GetCustomAttributes( typeof(TrackerAttribute),false);

            if (attributes.Length > 0)
            {
                var trackerAttribute =
                    attributes
                    .Cast<TrackerAttribute>()
                    .First();
            
                var position = mono.transform.position;
                
                Handles.Label(position, trackerAttribute.TrackingName,new GUIStyle("ToolbarButton"));
            }
        }
    }
}