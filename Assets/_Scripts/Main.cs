using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Main : MonoBehaviour {
	public static Main S;
	// Use this for initialization
	public bool inDialog;
	private int placeInDialog = 0;
	void Awake(){
		S = this;
	}
	void Start () {
		inDialog = true;
		Play_Dialog();
	}
	
	// Update is called once per frame
	void Update (){
		if(Input.GetKeyDown("space"))
			print("bums");
		print("inDialog: " + inDialog);
		if(inDialog && Input.GetKey(KeyCode.A))
			print("enter");
	}
	public void ShowMessage(string message){
		GameObject dialogBox = GameObject.Find("Canvas").transform.Find("Text").gameObject;
		Text goText = dialogBox.GetComponent<Text>();
		goText.text = message;
		print(message);
		inDialog = true;
	}
	// Update is called once per frame
	public void HideDialogBox(){
		Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
		noAlpha.a = 0;
		GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;
		
		Monkey.S.rb.velocity = Monkey.S.beforePause;
		
		gameObject.SetActive(false);
		inDialog = false;
	}
	public void Play_Dialog(){
		Monkey.S.beforePause = Monkey.S.rb.velocity;
		Monkey.S.rb.velocity = new Vector3(0,0,0);
		string sentance = CurrentText();
		if(sentance == "EXIT"){
			HideDialogBox();
			return;
		}
		Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
		print(noAlpha);
		noAlpha.a = 255;
		GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;
		ShowMessage(sentance);
	}
	private string CurrentText() {
		switch(placeInDialog){ 
			case 0:
				placeInDialog = 1;
				return "You swing through the trees so gracefully [SpaceBar]";
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
				return "Use A and S keys to change speed of rotation while in the Air to make sure you grab with hand";
			case 6:
				placeInDialog = 7;
				return "Better get ready to start swinging";
			case 7:
				placeInDialog = 8;
				inDialog = false;
				HideDialogBox();
				return "EXIT";
			default:
			return "";
				
				
		
		}
	}
}
