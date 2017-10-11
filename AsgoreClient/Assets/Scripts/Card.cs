using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card{

	public ushort Id;
	public byte Movement;
	public short Hp;
	public short Dmg;
	public Position CardPosition;
	public short Spawn;
	public short Regen;
	public State CardState;
	public ushort ArmyId;
	public SpecialAttack Attack;
	public int Cost;
	public string Name;

	public Card (ushort id, byte movement, short hp, short dmg, Position cardPosition, short spawn, short regen, State cardState, ushort armyId, ushort specialAttackId, int cost, string name) {
		Id = id;
		Movement = movement;
		Hp = hp;
		Dmg = dmg;
		CardPosition = cardPosition;
		Spawn = spawn;
		Regen = regen;
		CardState = cardState;
		ArmyId = armyId;
		Attack = SpecialAttack.createSpecialAttack(specialAttackId);
		Cost = cost;
		Name = name;
	}
	public enum State {
		NORMAL = 0, STANDBY = 1, DODGE = 2, SPECIAL = 3
	}
	public enum Position {
		OWN = 0, FIELD = 1, ENEMY = 2
	}
	public static Card createCharacter(ushort Id) {
		switch (Id) {
		case 0:
			return new Card (0, 1, 5, 1, Position.OWN, 50, 50, State.NORMAL, 1, 1, 1, "Error");

		case 1:
			return new Card (1, 1, 1, 1, Position.OWN, 1, 1, State.NORMAL, 1, 1, 1, "Assassin Dante");

		case 2:
			return new Card (2, 1, 1, 1, Position.OWN, 1, 1, State.NORMAL, 1, 1, 1, "Kickboxing Ale");

		case 3:
			return new Card (3, 1, 1, 1, Position.OWN, 1, 1, State.NORMAL, 1, 1, 1, "Scripter Luke");

		case 4:
			return new Card (4, 1, 1, 1, Position.OWN, 1, 1, State.NORMAL, 1, 1, 1, "Dominik, die Säule");

		case 5:
			return new Card (5, 1, 1, 1, Position.OWN, 1, 1, State.NORMAL, 1, 1, 1, "Sneezing Lukas");

		case 6:
			return new Card (6, 1, 1, 1, Position.OWN, 1, 1, State.NORMAL, 1, 1, 1, "CodeCampLeader Emil");

		case 7:
			return new Card (7, 1, 1, 1, Position.OWN, 1, 1, State.NORMAL, 1, 1, 1, "Bizeps Aaron");

		case 8:
			return new Card (8, 1, 1, 1, Position.OWN, 1, 1, State.NORMAL, 1, 1, 1, "Tetris Celine");

		case 9:
			return new Card (9, 1, 1, 1, Position.OWN, 1, 1, State.NORMAL, 1, 1, 1, "Lan Steffi");

		default:
			return new Card(0, 1, 5, 1, Position.OWN, 50, 50, State.NORMAL, 1, 1, 1, "Error");
		}
	}
}
public class SpecialAttack {
	public ushort Id;
	public byte Cooldown;
	public SpecialAttack (ushort id, byte cooldown) {
		Id = id;
		Cooldown = cooldown;
	}
	public virtual void cast(Card caster) {

	}
	public static SpecialAttack createSpecialAttack (ushort Id) {
		switch (Id){
		case 0:
			return new SpecialAttack(0,255);

		case 1:
			return new TestAttack();

		default:
			return new SpecialAttack(0,255);
		}
	}
}
public class TestAttack : SpecialAttack {
	public TestAttack () : base(1,2) { }
	public override void cast(Card caster)
	{
		caster.Hp++;
	}
}