using UnityEngine;
using System.Collections;
using DarkRift;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Gamemanager : MonoBehaviour {

	public static Gamemanager Instance;
	public GameObject Deck1Content;
	public GameObject Deck2Content;
	public List <GameObject> Deck1 = new List <GameObject> ();
	public List <GameObject> Deck2 = new List <GameObject> ();
	public GameObject ListObject;
	public RectTransform Spaghettifix;

	public void Awake(){

		Instance = this;
	}

	void Update () {

		if (Globalmanager.deckListsRecieved == true) {

			if (Deck1.Count != 0) {
				foreach (GameObject go in Deck1) {
					Destroy (go);
				}
			}
			if (Deck2.Count != 0) {
				foreach (GameObject go in Deck2) {
					Destroy (go);
				}
			}

			Deck1.Clear ();
			Deck2.Clear ();

			foreach (ushort card in Globalmanager.deckList1) {

				Card Character = Card.createCharacter (card);
				GameObject go = Instantiate (ListObject);
				go.transform.SetParent (Deck1Content.transform, false);
				Deck1.Add (go);
				Spaghettifix.sizeDelta = new Vector2 (1,1);
				Text t = go.GetComponentInChildren<Text> ();
				t.text = Character.Name;
				go.GetComponent<ListObject> ().cardId = card; //ListObject ist hier nicht das GameObject sondern das Script, welches wir im Unity verlinkt haben
			}
			foreach (ushort card in Globalmanager.deckList2) {

				Card Character = Card.createCharacter (card);
				GameObject go = Instantiate (ListObject);
				go.transform.SetParent (Deck2Content.transform, false);
				Deck2.Add (go);
				Spaghettifix.sizeDelta = new Vector2 (1,1);
				Text t = go.GetComponentInChildren<Text> ();
				t.text = Character.Name;
				go.GetComponent<ListObject> ().cardId = card; //ListObject ist hier nicht das GameObject sondern das Script, welches wir im Unity verlinkt haben
			}
			Globalmanager.deckListsRecieved = false;
		}
	}
}
