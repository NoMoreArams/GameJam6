using UnityEngine;
using System.Collections;

public class TrapHoney : TrapMaster {

	override
	public void Execute (GameObject other) {
		if (other.GetComponent<HoneyDebuff>() == null) 
			other.AddComponent<HoneyDebuff> ();
	}
}
