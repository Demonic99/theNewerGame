using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Globalmanager : MonoBehaviour {

	public static int id;

	public static List<string> availablePlayers = new List<string>();

	public static bool availablePlayersUpdated;

	public static List<ushort> availableCards = new List<ushort> ();

	public static bool availableCardsUpdated;

	public static readonly int deckSize = 10;

	public static List<ushort> deckList1 = new List<ushort> ();

	public static List<ushort> deckList2 = new List<ushort> ();

	public static bool deckListsRecieved;
}
