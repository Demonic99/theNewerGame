using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DarkRift;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour {


	public void Start(){
		Manager.Connection.onData += OnDataRecieved;
	}

	public void OnDestroy(){
		Manager.Connection.onData -= OnDataRecieved;
	}

	public InputField nameField;
	public InputField pwField;

	public void Login(){
		using(DarkRiftWriter writer = new DarkRiftWriter()){
			writer.Write (nameField.text);
			writer.Write (pwField.text);
			Manager.Connection.SendMessageToServer ((byte)TagsNSubjects.Tags.LOGINTAG, (ushort)TagsNSubjects.LoginSubjects.LOGINSUBJECT, writer);
		}
	}

	public void OnDataRecieved(byte tag, ushort subject,object data){
		if (tag == (byte)TagsNSubjects.Tags.LOGINTAG) {

			if (subject == (ushort)TagsNSubjects.LoginSubjects.LOGINSUCCESS) {
				using (DarkRiftReader reader = data as DarkRiftReader) {
					Globalmanager.id = reader.ReadInt32 ();
				}

			}
			SceneManager.LoadScene ("Lobby");
			if (subject == (ushort)TagsNSubjects.LoginSubjects.LOGINFAILED) {
				Debug.Log ("login failed");
			}
		}
	}

	public void RegisterButton () {
		// wird ausgeführt beim Klick auf den "Register"-Knopf (Verknüpfung im Unity)
		SceneManager.LoadScene ("Register");
	}
}
