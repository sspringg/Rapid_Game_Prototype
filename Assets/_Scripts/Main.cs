using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Main : MonoBehaviour {
	public static Main S;
	// Use this for initialization
	public bool inDialog;
	public int placeInDialog = 0;
	public bool waitingOnChoice = false;
	void Awake(){
		S = this;
	}
	void Start () {
		inDialog = true;
		Play_Dialog();
	}
	
	// Update is called once per frame
	void Update (){
		if(inDialog && Input.GetKeyDown(KeyCode.Space))
			Play_Dialog();
		else if(waitingOnChoice && Input.GetKeyDown(KeyCode.Alpha1))
			Application.LoadLevel("Scene0");
		else if(waitingOnChoice && Input.GetKeyDown(KeyCode.Alpha2))
			Application.Quit();
	}
	public void ShowMessage(string message){
		GameObject dialogBox = GameObject.Find("Dialog").transform.Find("Text").gameObject;
		Text goText = dialogBox.GetComponent<Text>();
		goText.text = message;
	}
	// Update is called once per frame
	public void HideDialogBox(){
		Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
		noAlpha.a = 0;
		GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;
		Monkey.S.rb.AddForce(Vector3.forward * 20);
		Monkey.S.rb.AddForce(Vector3.up * 10);
		inDialog = false;
	}
	public void Play_Dialog(){
		inDialog = true;
		Monkey.S.rb.velocity = new Vector3(0,0,0);
		string sentance = CurrentText();
		if(sentance == "EXIT"){
			GameObject dialogBox = GameObject.Find("Dialog").transform.Find("Text").gameObject;
			Text goText = dialogBox.GetComponent<Text>();
			goText.text = "";
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
				return "You get tired swinging so make sure to collect the glowing bananas for energy";
			case 5:
				placeInDialog = 6;
				return "Use A and S keys to change speed of rotation while in the Air so you can grab with the hand";
			case 6:
				placeInDialog = 7;
				return "Better get ready to start swinging";
			case 7:
				placeInDialog = 8;
				inDialog = false;
				HideDialogBox();
				//init scoring
				Color noAlpha = GameObject.Find("ScoreBackground").GetComponent<GUITexture>().color;
				noAlpha.a = 255;
				GameObject.Find("ScoreBackground").GetComponent<GUITexture>().color = noAlpha;
				GameObject dialogBox = GameObject.Find("Score").transform.Find("Text").gameObject;
				Text goText = dialogBox.GetComponent<Text>();
				goText.text = Monkey.S.distTravelled.ToString();
				//end
				Energy.S.gameObject.SetActive(true);
				return "EXIT";
			case 8:
				placeInDialog = 9;
				Energy.S.gameObject.SetActive(false);
				return "Slippery Fingers missing the branch?";
			case 9:
				placeInDialog = 10;
				return "I know you can do better than 'score' next time" ;
			case 10:
				placeInDialog = 20;
				waitingOnChoice = true;
				return "Press 1 to play again or 2 to quit";
			case 11:
				placeInDialog = 9;
				Energy.S.gameObject.SetActive(false);
				return "Owww! That's gonna hurt" ;
			case 12:
				placeInDialog = 9;
				Energy.S.gameObject.SetActive(false);
				return "Keep working hard and you'll learn how to use your energy" ;
			case 20:
				placeInDialog = 9;
				inDialog = false;
				HideDialogBox();
				return "EXIT" ;
			default:
				return "";
				
				
		
		}
	}
}
