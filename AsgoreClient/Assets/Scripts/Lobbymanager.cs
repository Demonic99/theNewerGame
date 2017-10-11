using UnityEngine;
using System.Collections;
using DarkRift;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Lobbymanager : MonoBehaviour {
	
	public static Lobbymanager Instance;
	public GameObject PlayerContent;
	public GameObject AvailableCardContent;
	public GameObject DeckListContent;
	public GameObject ListObject;
	public List <GameObject> AvailablePlayers = new List <GameObject> ();
	public List <GameObject> AvailableCards = new List <GameObject> ();
	public List <GameObject> DeckList = new List <GameObject> ();
	public List <ushort> Deck = new List <ushort> ();
	public RectTransform Spaghettifix;


	public void Awake(){

		Instance = this;
		// sobald der Lobbymanager gestartet wird, macht er eine Instanz von sich selbst, welche static ist,
		// sodass wir von anderen Scripts (hier: ListObject) aus trotzdem auf die non-static Variabeln zugreifen können
		// sog. Singleton
	}

	public void Update(){
		
		if (Globalmanager.availablePlayersUpdated == true) {

			foreach (GameObject go in AvailablePlayers) {

				Destroy (go);
			}

			AvailablePlayers.Clear();

			foreach (string player in Globalmanager.availablePlayers) {

				GameObject go = Instantiate (ListObject);
				go.tag = "Player";
				go.transform.SetParent (PlayerContent.transform, false);
				AvailablePlayers.Add (go);
				Spaghettifix.sizeDelta = new Vector2 (1,1); // Bugfix eines Unityfehlers
				Text t = go.GetComponentInChildren<Text> (); // fügt dem GameObject ein weiteres vom Typ Text als Tochter-Objekt hinzu
				t.text = player;
			}
			Globalmanager.availablePlayersUpdated = false;
		}

		if (Globalmanager.availableCardsUpdated == true) {

			if (AvailableCards.Count != 0) {
				foreach (GameObject go in AvailableCards) {
					Destroy (go);
				}
			}
			if (DeckList.Count != 0) {
				foreach (GameObject go in DeckList) {
					Destroy (go);
				}
			}
			AvailableCards.Clear ();
			DeckList.Clear ();
			Deck.Clear ();

			foreach (ushort card in Globalmanager.availableCards) {

				Card Character = Card.createCharacter (card);
				GameObject go = Instantiate (ListObject);
				go.tag = "AvailableCard";
				go.transform.SetParent (AvailableCardContent.transform, false);
				AvailableCards.Add (go);
				Spaghettifix.sizeDelta = new Vector2 (1,1);
				Text t = go.GetComponentInChildren<Text> ();
				t.text = Character.Name;
				go.GetComponent<ListObject> ().cardId = card; //ListObject ist hier nicht das GameObject sondern das Script, welches wir im Unity verlinkt haben
			}
			Globalmanager.availableCardsUpdated = false;
		}
	}
}