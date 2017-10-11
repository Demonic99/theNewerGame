using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour {

	public short ArmyId;
	public byte Movement;
	public short Size;
	public short HpPerUnit;
	public short Hp;
	public short Dmg;
	public short Armor;
	public short ArmorPen;
	public byte Initiative;

	public Army (short armyId, byte movement, short size, short hpPerUnit, short dmg, short armor, short armorPen, byte initiative){
		ArmyId = armyId;
		Movement = movement;
		Size = size;
		HpPerUnit = hpPerUnit;
		Hp = (short)(hpPerUnit * size);
		Dmg = dmg;
		Armor = armor;
		ArmorPen = armorPen;
		Initiative = initiative;
	}

	public static Army CreateArmy(ushort armyId, short size){
		switch (armyId){
		case 0:
			return new Army(0, 1, size, 1, 1, 0, 0, 2);
		}
		return new Army(0, 1, size, 1, 1, 0, 0, 2);
	}
}
