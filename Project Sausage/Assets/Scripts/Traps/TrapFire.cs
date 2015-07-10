using UnityEngine;
using System.Collections;

public class TrapFire : TrapMaster {
	
	override
	public void Execute (GameObject other) {
		other.AddComponent<DamageDebuff> ();
	}
}
