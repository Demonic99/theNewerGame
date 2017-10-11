using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkRift;

public class SelectDeck : MonoBehaviour {

	public int deckNumber; // wurde im Unity definiert: "Deck 1" -> 1, "Deck 2" -> 2

	public GameObject DeckSelection;

	public void OnButtonPressed(){

		DeckSelection.SetActive (false); //schliesst das Fenster wieder, macht es unsichtbar
		using (DarkRiftWriter writer = new DarkRiftWriter ()) {
			if (deckNumber == 1) {
				writer.Write ((byte)1);
			}
			if (deckNumber == 2) {
				writer.Write ((byte)2);
			}
			Manager.Connection.SendMessageToServer ((byte)TagsNSubjects.Tags.GAMETAG, (ushort)TagsNSubjects.GameSubjects.START, writer);
		}
	}
}
