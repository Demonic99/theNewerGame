using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkRift;

public class SaveDeck : MonoBehaviour {

	public int deckNumber; // wurde im Unity definiert: "Save as Deck 1" -> 1, "Save as Deck 2" -> 2

	public GameObject BuildingDecks;

	public void OnButtonPressed(){

		foreach (GameObject go in Lobbymanager.Instance.DeckList) {
			Lobbymanager.Instance.Deck.Add (go.GetComponent<ListObject> ().cardId);
		}
		if (Lobbymanager.Instance.Deck.Count != Globalmanager.deckSize) {
			Lobbymanager.Instance.Deck.Clear ();
			Error.Instance.PopUp ("The Deck Size shold be" + Globalmanager.deckSize.ToString());
			return;
		}
		BuildingDecks.SetActive (false); //schliesst das Fenster wieder, macht es unsichtbar
		using (DarkRiftWriter writer = new DarkRiftWriter ()) {
			foreach (ushort card in Lobbymanager.Instance.Deck){
				writer.Write (card);
			}
			if (deckNumber == 1) {
				Manager.Connection.SendMessageToServer ((byte)TagsNSubjects.Tags.CARDTAG, (ushort)TagsNSubjects.CardSubjects.Deck1Built, writer);
			}
			if (deckNumber == 2) {
				Manager.Connection.SendMessageToServer ((byte)TagsNSubjects.Tags.CARDTAG, (ushort)TagsNSubjects.CardSubjects.Deck2Built, writer);
			}
		}
	}
}
