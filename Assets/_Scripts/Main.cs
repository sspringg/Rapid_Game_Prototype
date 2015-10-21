using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public static Main S;
	// Use this for initialization
	public bool inDialog;
	private int placeInDialog = 0;
	void Awake(){
		S = this;
	}
	void Start () {
		HideDialogBox();
		inDialog = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!inDialog){
			HideDialogBox();
		}
		else if(inDialog){
			if(Input.GetKeyDown(KeyCode.Return)){
				Play_Dialog();
			}
		}
		
	}
	public void ShowMessage(string message){
		GameObject dialogBox = transform.Find("Text").gameObject;
		Text goText = dialogBox.GetComponent<Text>();
		goText.text = message;
		inDialog = true;
	}
	// Update is called once per frame
	public void HideDialogBox(){
		Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
		noAlpha.a = 0;
		GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;
		gameObject.SetActive(false);
		inDialog = false;
	}
	public void Play_Dialog(){
		string sentance = CurrentText();
		if(sentance == "EXIT"){
			HideDialogBox();
			return;
		}
		Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
		noAlpha.a = 255;
		GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;
		ShowMessage(sentance);
	}
	private string CurrentText() {
		switch(placeInDialog){ 
			case 0:
				placeInDialog = 1;
				return "You swing through the trees so gracefully";
			case 1:
				placeInDialog = 2;
				return "Once getting near a branch, hold down the mouse to grab on";
			case 2:
				placeInDialog = 3;
				return "The release trajectory is determined by the time of release";
			case 3:
				placeInDialog = 4;
				return "and lateral velocity is determined by position of mouse click";
			case 4:
				placeInDialog = 5;
				return "You get tired out there swinging so make sure to collect the glowing bananas for energy";
			case 5:
				placeInDialog = 6;
				return "Better get ready to start swinging";
			case 6:
				placeInDialog = 7;
				inDialog = false;
				return "EXIT";
				
				
		
		}
	}
}
