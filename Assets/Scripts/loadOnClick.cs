using UnityEngine;
using System.Collections;

public class loadOnClick : MonoBehaviour {

	
	//For switching scenes on main menu
	//int level - Index of scene based on build settings
	public void loadScene(int level){

		Application.LoadLevel (level);
	}
}
