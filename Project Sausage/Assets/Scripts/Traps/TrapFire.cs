using UnityEngine;
using System.Collections;

public class TrapFire : TrapMaster {
	
	override
	public void Execute (GameObject other) {
		DamageDebuff buff = other.AddComponent<DamageDebuff> ();
		buff.Execute (tAttr.damage);
	}
}
