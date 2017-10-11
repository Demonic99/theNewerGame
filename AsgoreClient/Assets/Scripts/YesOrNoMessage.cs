using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesOrNoMessage : MonoBehaviour {

	public void Yes () {

		YesOrNo.Instance.Response = 1;
		Destroy (gameObject);
	}

	public void No () {

		YesOrNo.Instance.Response = 2;
		Destroy (gameObject);
	}
}
