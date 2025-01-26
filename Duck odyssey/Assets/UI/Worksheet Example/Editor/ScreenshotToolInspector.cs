using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UWEGames.Examples
{
    [CustomEditor(typeof(ScreenshotTool))]
    public class ScreenshotToolInspector : Editor
    {
        // OnInspector GUI
        public override void OnInspectorGUI() //2
        {
            ScreenshotTool tool = (ScreenshotTool)target;
            tool.SuperSize = EditorGUILayout.IntSlider("Super Size", tool.SuperSize, 1, 5);
            tool.FileName = EditorGUILayout.TextField("File Name", tool.FileName);
            tool.UseDateTime = EditorGUILayout.Toggle("Use Date Time", tool.UseDateTime);
            tool.TakeScreenshotOnPlay = EditorGUILayout.Toggle("Take Screenshot On Play", tool.TakeScreenshotOnPlay);
            if (GUILayout.Button("Take Screenshot"))
            {
                string name = tool.UseDateTime ? tool.FileName + tool.GetDateTime() : tool.FileName;
                string finalName = name + ".png";
                Debug.Log(finalName);
                tool?.TakeScreenshot(finalName, tool.SuperSize);
            }
        }

        
    }

}