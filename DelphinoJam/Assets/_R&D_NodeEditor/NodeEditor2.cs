using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class NodeEditor2 : EditorWindow
{
	List<PlayerNode> playerNodes = new List<PlayerNode>();
    List<EnemyNode> enemyNodes = new List<EnemyNode>();

	Player[] players;
    Enemy[] enemies;


	private void OnEnable()
	{
		//AddPlayerNodes(FindPlayers());
		AddEnemyNodes(FindEnemies());
	}

	private void OnGUI()
	{
        BeginWindows();

		SpawnNodes();
		//SpawnPlayerNodes();
        //SpawnEnemyNodes();

        EndWindows();
    }

	#region Affichage de la fenêtre principale

	[MenuItem("Window/NodesEditor2")]
	static void ShowEditor()
	{
		NodeEditor2 nodeEditor2 = EditorWindow.GetWindow<NodeEditor2>();
	}

	#endregion

	#region Finds Objects

	Player[] FindPlayers() { return players = FindObjectsOfType<Player>(); }
	Enemy[] FindEnemies() { return enemies = FindObjectsOfType<Enemy>(); }

	#endregion

	#region Fonctions des noeuds

    void DrawNode(int id)
    {
        GUI.DragWindow();
    }
	void SpawnNodes()
	{
		for (int i = 0; i < playerNodes.Count; i++)
			playerNodes[i].Rect = GUI.Window(i, playerNodes[i].Rect, DrawNode, playerNodes[i].Title);

		for (int i = 0; i < enemyNodes.Count; i++)
			enemyNodes[i].Rect = GUI.Window(i, enemyNodes[i].Rect, DrawNode, enemyNodes[i].Title);
	}


	void AddPlayerNodes(Player[] players)
	{
		foreach (Player player in players)
			playerNodes.Add(new PlayerNode(new Rect(10, 10, 100, 100), player));
	}
	//void SpawnPlayerNodes()
	//{
	//	for (int i = 0; i < playerNodes.Count; i++)
	//		playerNodes[i].Rect = GUI.Window(i, playerNodes[i].Rect, DrawNode, playerNodes[i].Title);
	//}

	void AddEnemyNodes(Enemy[] enemies)
	{
		foreach (Enemy enemy in enemies)
			enemyNodes.Add(new EnemyNode(new Rect(10, 10, 100, 100), enemy));
	}
	//void SpawnEnemyNodes()
	//{
	//	for (int i = 0; i < enemyNodes.Count; i++)
	//		enemyNodes[i].Rect = GUI.Window(i, enemyNodes[i].Rect, DrawNode, enemyNodes[i].Title);
	//}

	#endregion

	#region Dessin d'une courbe

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

	#endregion

}
public class PlayerNode
{
	public Rect Rect;
	public string Title;

	Player player;

	public PlayerNode(Rect rect, Player player)
	{
		Rect = rect;
		this.player = player;
		Title = player.name;
	}
}
public class EnemyNode
{
    public Rect Rect;
    public string Title;

    Enemy enemy;

	public EnemyNode(Rect rect, Enemy enemy)
	{
		Rect = rect;
		this.enemy = enemy;
		Title = enemy.name;
	}
}