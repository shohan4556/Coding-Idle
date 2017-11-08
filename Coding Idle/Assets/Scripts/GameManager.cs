using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Upgrade{
	Clicker,
	Scoreboard,
	Solution,
	UpgradeTable,
}

public class GameManager : MonoBehaviour {
	public static GameManager Instance{ set; get; }

	[SerializeField]
	public Dictionary<string,int> upgrades = new Dictionary<string, int> ();

	[SerializeField]
	public int units{ set; get; }

	#region Monobehavior Callbacks
	private void Awake(){
		Instance = this;
	}

	private void Start(){
		//Temporary solution till loading and saving are coded
		LoadLocal();
	}

	private void Update(){
		//Log debug information every 5secs //TEMP SOLUTION
		if (Time.fixedTime % 5 == 0) {
			Debug.Log ("Current Clicker level is: " + FetchUpgradeLevel (Upgrade.Clicker));
			Debug.Log ("Current Scoreboard level is: " + FetchUpgradeLevel (Upgrade.Scoreboard));
			Debug.Log ("Current Units" + units.ToString ());
		}
	}
	#endregion

	#region Saving and Loading
	public void SaveLocal(){

	}

	public void LoadLocal(){
		//Temp solution
		upgrades.Add ("Clicker", 1);
		upgrades.Add ("Scoreboard", 1);
		upgrades.Add ("Solution", 1);
		upgrades.Add ("UpgradeTable", 1);
		units = 0;
	}
	#endregion
	 
	public void GainUnits(){
		int level = FetchUpgradeLevel (Upgrade.Clicker);
		switch (level) {
		case 1:
			units += 1;
			break;
		}
	}

	public int FetchUpgradeLevel(Upgrade upgradeType){
		switch (upgradeType) {
		case Upgrade.Clicker:
			return upgrades ["Clicker"];
		case Upgrade.Scoreboard:
			return upgrades ["Scoreboard"];
		case Upgrade.Solution:
			return upgrades ["Solution"];
		case Upgrade.UpgradeTable:
			return upgrades ["UpgradeTable"];
		default:
			return 0;
		}
	}
}
