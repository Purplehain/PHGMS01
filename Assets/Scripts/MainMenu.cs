using UnityEngine;
using System.Collections;


public class MainMenu : MonoBehaviour {
	private bool mainScene = true;
	private bool voxelScene = false;
	private bool dungeonScene = false;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}

	void OnGUI()
	{
		if(mainScene){
			if(GUILayout.Button("3D Voxel Engine")){
				Application.LoadLevel(1);
			}
			if(GUILayout.Button ("2D Dungeon Generator")){
				Application.LoadLevel (2);
			}
			if(GUILayout.Button ("Pathfinding"))
			{
				Application.LoadLevel (3);
			}
		} else
		{
			if(GUILayout.Button ("Zurück")){
				Application.LoadLevel (0);
			}
		}
	}
}
