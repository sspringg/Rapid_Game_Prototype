using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {
	public static Energy S;
	public float stamina, maxStamina;
	Rect StaminaRect;
	Texture2D StaminaTexture;
	// Use this for initialization
	
	void Awake(){
		S = this;
	}
	
	void Start () {
		StaminaRect = new Rect(Screen.width/10, Screen.height * 9/10, Screen.width/3, Screen.height/50);
		StaminaTexture = new Texture2D(1,1);
		StaminaTexture.SetPixel(0,0, Color.yellow);
		StaminaTexture.Apply();
		stamina = maxStamina = 20;
	}
	
	// Update is called once per frame
	void Update () {
		stamina -= Time.deltaTime;
		if(stamina <= 0){
			//end game 
		}
	}
	void OnGUI(){
		float ratio = stamina/ maxStamina;
		float rectWidth = ratio*Screen.width/3;
		StaminaRect.width = rectWidth;
		GUI.DrawTexture(StaminaRect, StaminaTexture);
	
	}
}
