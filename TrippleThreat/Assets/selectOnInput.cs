using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class selectOnInput : MonoBehaviour {
	public EventSystem eventSystem;
	public GameObject selectedObject;
	private bool buttonSelected;

	void start(){
	
	}

	void Update(){
		if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false) {
			eventSystem.SetSelectedGameObject (selectedObject);
			buttonSelected = true;
		}
	
	}
	private void OnDisable(){
		buttonSelected = false;
	}
}
