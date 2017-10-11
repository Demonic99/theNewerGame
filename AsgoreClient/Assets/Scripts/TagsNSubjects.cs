using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagsNSubjects : MonoBehaviour {

	public enum Tags
	{
		LOGINTAG = 0, REGISTERTAG = 1, MATCHMAKING_TAG = 2, CARDTAG = 3, GAMETAG = 4
	}
			
	public enum LoginSubjects
	{
		LOGINSUBJECT = 0, LOGINSUCCESS = 1, LOGINFAILED = 2, REGISTER = 3
	}

	public enum RegisterSubjects
	{
		REGISTERSUCCESS = 0, REGISTERFAILEDUSERNAME = 1, REGISTERFAILEDEMAIL = 2
	}

	public enum MatchmakingSubjects
	{
		OPPONENTSLIST = 0, FRIENDSLIST = 1, GAMESTART = 2, GAMESTARTFAILED = 3, CHALLENGE = 4, CHALLENGEDECLINED = 5
	}

	public enum CardSubjects
	{
		AVAILABLECARDS = 0, Deck1Built = 1, Deck2Built = 2
	}

	public enum GameSubjects
	{
		START = 0
	}
}
