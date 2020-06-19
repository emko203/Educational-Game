using UnityEngine;
using System.Collections;

public class livingBirdsDemoScript : MonoBehaviour {
	public lb_BirdController birdControl;
	public Camera camera1;
	public Camera camera2;

	Camera currentCamera;
	bool cameraDirections = true;
	Ray ray;
	RaycastHit[] hits;

	void Start(){
		currentCamera = Camera.main;
		birdControl = GameObject.Find ("_livingBirdsController").GetComponent<lb_BirdController>();
		SpawnSomeBirds();
	}


	void OnGUI() {
		if (GUI.Button(new Rect(10000, 10, 150, 50), "Pause"))
			birdControl.SendMessage("Pause");
		
		if (GUI.Button(new Rect(10000, 70, 150, 30), "Scare All"))
			birdControl.SendMessage("AllFlee");

		if (GUI.Button(new Rect(10000, 110, 150, 50), "Change Camera"))
			ChangeCamera();

		if (GUI.Button(new Rect(10000, 170, 150, 50), "Revive Birds"))
			birdControl.BroadcastMessage("Revive");


		
	}

	IEnumerator SpawnSomeBirds(){
		yield return 2;
		birdControl.SendMessage ("SpawnAmount",10);
	}

	void ChangeCamera(){
		if(camera2.gameObject.activeSelf){
			camera1.gameObject.SetActive(true);
			camera2.gameObject.SetActive(false);
			birdControl.SendMessage("ChangeCamera",camera1);
			cameraDirections = true;
			currentCamera = camera1;
		}else{
			camera1.gameObject.SetActive(false);
			camera2.gameObject.SetActive(true);
			birdControl.SendMessage("ChangeCamera",camera2);
			cameraDirections = false;
			currentCamera = camera2;
		}
	}
}
