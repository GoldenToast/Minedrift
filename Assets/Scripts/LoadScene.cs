using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public string landingButton;
	public string sceneName; 
	private bool ready;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton (landingButton) && ready ) {
			SceneManager.LoadScene(sceneName);
		}
	}

	void OnTriggerEnter(Collider other){
		ready = true;
	}

	void OnTriggerExit(Collider other){
		ready = false;
	}
}
