using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkRift;

public class DeckbuildButton : MonoBehaviour {

	public GameObject BuildingDecks;

	public void OnButtonPressed(){
		BuildingDecks.SetActive (true);
		using (DarkRiftWriter writer = new DarkRiftWriter ()) {
			Manager.Connection.SendMessageToServer ((byte)TagsNSubjects.Tags.CARDTAG, (ushort)TagsNSubjects.CardSubjects.AVAILABLECARDS, writer);
		}
		
	}
}
