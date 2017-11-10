using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Clicker : MonoBehaviour {

	[SerializeField]
	public int units{ set; get; }
	/*---------------------------------- */
	public Animator _animator;
	/*----------------------------------- */

	// Use this for initialization
	void Start () {
		
	}
	
	
	public void clickGainUnit()
	{
		units +=1;
		if(units==5){
			_animator.SetBool("PopUp", true);
		}
	}

}
