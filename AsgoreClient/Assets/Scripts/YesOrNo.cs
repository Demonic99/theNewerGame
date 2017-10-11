using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesOrNo : MonoBehaviour{

	public static YesOrNo Instance;
	public GameObject YesOrNoMessage;
	public byte Response;

	public void Awake (){

		Instance = this;
		DontDestroyOnLoad (this);
	}

	public void PopUp (string message, string yes, string no){

		Response = 0;
		GameObject go = (GameObject)Instantiate (YesOrNoMessage, GameObject.Find("Canvas").transform);
		go.GetComponentsInChildren<Text> () [0].text = message;
		go.GetComponentsInChildren<Text> () [1].text = yes;
		go.GetComponentsInChildren<Text> () [2].text = no;
	}
}