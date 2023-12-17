using System.Linq;
using TMPro;
using UnityEngine;
using System;

// Source: https://github.com/dilmerv/UnityMultiplayerPlayground/blob/master/Assets/Scripts/Core/Logger.cs
public class Logger : Core.Singleton.Singleton<Logger>
{
    [SerializeField]
    private TextMeshProUGUI debugAreaText = null;

    [SerializeField]
    private bool enableDebug = false;

    [SerializeField]
    private int maxLines = 15;

    void Awake() {
        if (debugAreaText == null) {
            debugAreaText = GetComponent<TextMeshProUGUI>();
        }
        debugAreaText.text = string.Empty;
        Debug.Log("Debugger awake");
    }

    void OnEnable() {
        debugAreaText.enabled = enableDebug;
        enabled = enableDebug;

        if (enabled) {
            debugAreaText.text += $"<color=\"white\">{DateTime.Now.ToString("HH:mm:ss.fff")} {this.GetType().Name} enabled</color>\n";
        }
    }

    public void LogInfo(string message) {
        ClearLines();
        Debug.Log("Logged Info");
        debugAreaText.text += $"<color=\"green\">{DateTime.Now.ToString("HH:mm:ss.fff")} {message}</color>\n";
    }

    public void LogError(string message) {
        ClearLines();
        debugAreaText.text += $"<color=\"red\">{DateTime.Now.ToString("HH:mm:ss.fff")} {message}</color>\n";
    }

    public void LogWarning(string message) {
        ClearLines();
        debugAreaText.text += $"<color=\"yellow\">{DateTime.Now.ToString("HH:mm:ss.fff")} {message}</color>\n";
    }

    private void ClearLines() {
        if (debugAreaText.text.Split('\n').Count() >= maxLines) {
            debugAreaText.text = string.Empty;
        }
    }
}