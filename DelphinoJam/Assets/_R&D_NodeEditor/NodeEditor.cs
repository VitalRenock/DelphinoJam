using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
//public class NodeEditor : EditorWindow
//{(
//    //string mystring = "Hello world!";

//    //[MenuItem("Window/Example")]
//    //public static void ShowWindow()
//    //{
//    //	GetWindow<ExampleWindow>("Example");
//    //}

//    //private void OnGUI()
//    //{
//    //	// Window Code
//    //	GUILayout.Label("Label Titre", EditorStyles.boldLabel);
//    //	mystring = EditorGUILayout.TextField("Name", mystring);
//    //}
//}

[ExecuteInEditMode]
public class NodeEditor : EditorWindow
{

    List<Rect> nodes = new List<Rect>();
    List<int> windowsToAttach = new List<int>();
    List<int> attachedWindows = new List<int>();

    Player playerShow/* = new Player()*/;

    [MenuItem("Window/Node editor")]
    static void ShowEditor()
    {
        NodeEditor editor = EditorWindow.GetWindow<NodeEditor>();
    }

	private void OnEnable()
	{
        playerShow = GameObject.FindObjectOfType<Player>();
	}

	void OnGUI()
    {
        if (windowsToAttach.Count == 2)
        {
            attachedWindows.Add(windowsToAttach[0]);
            attachedWindows.Add(windowsToAttach[1]);
            windowsToAttach = new List<int>();
        }

        if (attachedWindows.Count >= 2)
        {
            for (int i = 0; i < attachedWindows.Count; i += 2)
            {
                DrawNodeCurve(nodes[attachedWindows[i]], nodes[attachedWindows[i + 1]]);
            }
        }

        BeginWindows();

        if (GUILayout.Button("Create Node"))
        {
            nodes.Add(new Rect(10, 10, 100, 100));
        }


        for (int i = 0; i < nodes.Count; i++)
        {
            nodes[i] = GUI.Window(i, nodes[i], DrawNodeWindow, "Window " + i);
        }

        EndWindows();
    }


    void DrawNodeWindow(int id)
    {
        if (GUILayout.Button("Attach"))
        {
            windowsToAttach.Add(id);
        }

        GUILayout.Label(playerShow.name);
        //playerShow = EditorGUILayout.PropertyField()

		GUI.DragWindow();
	}


    void DrawNodeCurve(Rect start, Rect end)
    {
        Vector3 startPos = new Vector3(start.x + start.width, start.y + start.height / 2, 0);
        Vector3 endPos = new Vector3(end.x, end.y + end.height / 2, 0);
        Vector3 startTan = startPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Color shadowCol = new Color(0, 0, 0, 0.06f);

        for (int i = 0; i < 3; i++)
        {// Draw a shadow
            Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);
        }

        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 1);
    }
}



public class EssaiNode : Editor
{

}