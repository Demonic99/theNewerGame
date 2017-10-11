using UnityEngine;
using System.Collections;
using DarkRift;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {


	public static DarkRiftConnection Connection = new DarkRiftConnection();
	[SerializeField]
	int port = 4296;
	[SerializeField]
	string IP = "localhost";



	void OnApplicationQuit (){

		if (Connection.isConnected == true) {
			Connection.Disconnect ();
		}
		Manager.Connection.onData -= OnDataRecieved;
	}


	public void Awake(){

		if (Connection.isConnected == true) {
			Destroy (gameObject);
			return;
		}
		DontDestroyOnLoad (gameObject);
		Connection.Connect (IP, port);
		Manager.Connection.onData += OnDataRecieved;

	}

	public IEnumerator Reconnect(){

		while (Connection.isConnected == false) {

			Connection.Connect (IP, port);
			yield return new WaitForSeconds (5);

		}

	}

	void Update(){

		Connection.Receive ();
		if (Connection.isConnected == false) {

			//connecting
			StartCoroutine ("Reconnect");


		}

	}

	public void OnDataRecieved(byte tag, ushort subject, object data){

		if (tag == (byte)TagsNSubjects.Tags.MATCHMAKING_TAG) {

			if (subject == (ushort)TagsNSubjects.MatchmakingSubjects.OPPONENTSLIST) {

				using (DarkRiftReader reader = data as DarkRiftReader) {
					int n;
					n = reader.ReadInt32 ();
					string[] nn = new string[n];
					nn = reader.ReadStrings ();
					Globalmanager.availablePlayers.Clear ();
					Globalmanager.availablePlayers.AddRange (nn);
					Globalmanager.availablePlayersUpdated = true;
				}
			}
		}

		if (tag == (byte)TagsNSubjects.Tags.CARDTAG) {

			if (subject == (ushort)TagsNSubjects.CardSubjects.AVAILABLECARDS) {

				using (DarkRiftReader reader = data as DarkRiftReader) {
					ushort n;
					n = reader.ReadUInt16 ();
					List<ushort> cardIds = new List<ushort> ();
					for (int i = 0; i < n; i++) {
						cardIds.Add (reader.ReadUInt16 ());
					}
					Globalmanager.availableCards.Clear ();
					Globalmanager.availableCards.AddRange (cardIds);
					Globalmanager.availableCardsUpdated = true;
				}
			}
		}

		if (tag == (byte)TagsNSubjects.Tags.MATCHMAKING_TAG) {
			
			if (subject == (ushort)TagsNSubjects.MatchmakingSubjects.CHALLENGE) {
				string challenger;
				using (DarkRiftReader reader = data as DarkRiftReader) {

					challenger = reader.ReadString ();
				}
				StartCoroutine (Challenge (challenger));
			}

			if (subject == (ushort)TagsNSubjects.MatchmakingSubjects.GAMESTART) {

				SceneManager.LoadScene ("Game");
				using (DarkRiftReader reader = data as DarkRiftReader) {
					List<ushort> deck1 = new List<ushort> ();
					List<ushort> deck2 = new List<ushort> ();
					for (int i = 0; i < Globalmanager.deckSize; i++) {
						deck1.Add (reader.ReadUInt16 ());
					}
					for (int i = 0; i < Globalmanager.deckSize; i++) {
						deck2.Add (reader.ReadUInt16 ());
					}
					Globalmanager.deckList1 = deck1;
					Globalmanager.deckList2 = deck2;
					Globalmanager.deckListsRecieved = true;
				}
			}

			if (subject == (ushort)TagsNSubjects.MatchmakingSubjects.GAMESTARTFAILED) {

				Error.Instance.PopUp ("Opponent Not Found");
			}
		}
	}

	public IEnumerator Challenge (string opponent) {
		// wir brauchen eine Funktion, die getrennt von der Gamelogik läuft, da wir die Funktion Update anhalten müssen.
		// wird diese jedoch angehalten, kann man auch keine Knöpfe mehr drücken, also die Herausforderung nicht mehr akzeptieren/verneinen.

		YesOrNo.Instance.PopUp ("You got challenged by: " + opponent, "Accept", "Decline");
		while (YesOrNo.Instance.Response == 0) {
			yield return new WaitForEndOfFrame ();
		}
		if (YesOrNo.Instance.Response == 1) {

			using (DarkRiftWriter writer = new DarkRiftWriter ()) {

				writer.Write (opponent);
				Connection.SendMessageToServer ((byte)TagsNSubjects.Tags.MATCHMAKING_TAG, (ushort)TagsNSubjects.MatchmakingSubjects.GAMESTART, writer);
			}
		}
		if (YesOrNo.Instance.Response == 2) {

			using (DarkRiftWriter writer = new DarkRiftWriter ()) {

				Connection.SendMessageToServer ((byte)TagsNSubjects.Tags.MATCHMAKING_TAG, (ushort)TagsNSubjects.MatchmakingSubjects.CHALLENGEDECLINED, writer);
			}
		}
	}
}