using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Error : MonoBehaviour{

	public static Error Instance;
	public GameObject ErrorMessage;

	public void Awake (){

		Instance = this;
		DontDestroyOnLoad (this);
	}

	public void PopUp (string message){

		GameObject go = (GameObject)Instantiate (ErrorMessage, GameObject.Find("Canvas").transform);
		go.GetComponentInChildren<Text> ().text = message;
	}
}
