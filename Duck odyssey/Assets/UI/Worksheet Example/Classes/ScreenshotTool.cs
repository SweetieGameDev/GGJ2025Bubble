using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace UWEGames.Examples
{
    public class ScreenshotTool : MonoBehaviour
    {
        private bool takeScreenshotOnPlay = true;
        private int superSize = 1;
        private string fileName = "Screenshot";
        private bool useDateTime = true;

        public void TakeScreenshot(string fileName, int sizeMod)
        {
            ScreenCapture.CaptureScreenshot(fileName, sizeMod);
        }

        private void Start()
        {
            if (takeScreenshotOnPlay)
            {
                Debug.Log("Taking screenshot on play");
                string name = useDateTime ? fileName + GetDateTime() : fileName;
                string finalName = name + ".png";
                Debug.Log(finalName);
                TakeScreenshot(finalName, superSize);
            }
        }

        public string GetDateTime()
        {
            return DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();
        }

        public int SuperSize
        {
            get => superSize;
            set => superSize = value;
        }

        public string FileName
        {
            get => fileName;
            set => fileName = value;
        }

        public bool UseDateTime
        {
            get => useDateTime;
            set => useDateTime = value;
        }

        public bool TakeScreenshotOnPlay
        {
            get => takeScreenshotOnPlay;
            set => takeScreenshotOnPlay = value;
        }
    }

}