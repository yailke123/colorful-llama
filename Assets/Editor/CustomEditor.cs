using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class CustomEditor : Editor
{
    [MenuItem("Tools/Toggle Inspector Lock %l")] // Ctrl + L
    public static void ToggleInspectorLock()
    {
        EditorWindow inspectorToBeLocked = EditorWindow.mouseOverWindow; // "EditorWindow.focusedWindow" can be used instead
 
        Type projectBrowserType = Assembly.GetAssembly(typeof(UnityEditor.Editor)).GetType("UnityEditor.ProjectBrowser");
 
        Type inspectorWindowType = Assembly.GetAssembly(typeof(UnityEditor.Editor)).GetType("UnityEditor.InspectorWindow");
 
        PropertyInfo propertyInfo;
        if (inspectorToBeLocked.GetType() == projectBrowserType)
        {
            propertyInfo = projectBrowserType.GetProperty("isLocked", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        }
        else if (inspectorToBeLocked.GetType() == inspectorWindowType)
        {
            propertyInfo = inspectorWindowType.GetProperty("isLocked");
        }
        else
        {
            return;
        }
 
        bool value = (bool)propertyInfo.GetValue(inspectorToBeLocked, null);
        propertyInfo.SetValue(inspectorToBeLocked, !value, null);
        inspectorToBeLocked.Repaint();
    }

    [MenuItem("Tools/Add Inspector %k")] // Ctrl + L
    public static void AddInspectorTab() {
        // Retrieve the existing Inspector tab, or create a new one if none is open
        EditorWindow inspectorWindow = EditorWindow.GetWindow( typeof( Editor ).Assembly.GetType( "UnityEditor.InspectorWindow" ) );
        // Get the size of the currently window
        Vector2 size = new Vector2( inspectorWindow.position.width, inspectorWindow.position.height );
        // Clone the inspector tab (optionnal step)
        inspectorWindow = Instantiate( inspectorWindow );
        // Set min size, and focus the window
        inspectorWindow.minSize = size;
        inspectorWindow.Show();
        inspectorWindow.Focus();
    }
    
}
