using UnityEngine;
using System.Collections;
using DarkRift;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ListObject : MonoBehaviour {

	public ushort cardId;

	public void OnButtonClicked(){

		if (gameObject.tag == "AvailableCard") {

			Card Character = Card.createCharacter (cardId);
			GameObject go = Instantiate (Lobbymanager.Instance.ListObject);
			go.tag = "CardInDeck";
			go.transform.SetParent (Lobbymanager.Instance.DeckListContent.transform, false);
			Lobbymanager.Instance.DeckList.Add (go);
			Lobbymanager.Instance.Spaghettifix.sizeDelta = new Vector2 (1,1);
			Text t = go.GetComponentInChildren<Text> ();
			t.text = Character.Name;
			go.GetComponent<ListObject> ().cardId = cardId;
		}

		if (gameObject.tag == "CardInDeck") {

			Card Character = Card.createCharacter (cardId);
			GameObject go = Instantiate (Lobbymanager.Instance.ListObject);
			go.tag = "AvailableCard";
			go.transform.SetParent (Lobbymanager.Instance.AvailableCardContent.transform, false);
			Lobbymanager.Instance.AvailableCards.Add (go);
			Lobbymanager.Instance.Spaghettifix.sizeDelta = new Vector2 (1,1);
			Text t = go.GetComponentInChildren<Text> ();
			t.text = Character.Name;
			go.GetComponent<ListObject> ().cardId = cardId;
		}

		if (gameObject.tag == "Player") {

			using (DarkRiftWriter writer = new DarkRiftWriter()) {

				writer.Write (gameObject.GetComponentInChildren<Text> ().text);
				Manager.Connection.SendMessageToServer ((byte)TagsNSubjects.Tags.MATCHMAKING_TAG, (ushort)TagsNSubjects.MatchmakingSubjects.CHALLENGE, writer);
			}
		}

		Destroy (gameObject);
	}
}
