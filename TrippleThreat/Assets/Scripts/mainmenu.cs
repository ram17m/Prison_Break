using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class mainmenu : MonoBehaviour {

	public void LoadByIndex(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}
}
