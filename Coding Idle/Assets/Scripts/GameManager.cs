using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Upgrade{
	Clicker,
	Scoreboard,
	Solution,
	UpgradeTable,
	Layout,
}

public class GameManager : MonoBehaviour {
	public static GameManager Instance{ set; get; }

	[SerializeField]
	public Dictionary<Upgrade,int> upgrades = new Dictionary<Upgrade, int> ();
	public List<Upgrade> AvailableUpgrades = new List<Upgrade> ();
	public List<Upgrade> DisplayedUpgrades = new List<Upgrade>();

	[SerializeField]
	public int units{ set; get; }

	public const int unitRange = 20;

	#region Monobehavior Callbacks
	private void Awake(){
		Instance = this;
	}

	private void Start(){
		//Temporary solution till loading and saving are coded
		LoadLocal();
	}

	private void Update(){
		//Log debug information every 20secs //TEMP SOLUTION
		if (Time.fixedTime % 20 == 0) {
			Debug.Log ("Current Clicker level is: " + FetchUpgradeLevel (Upgrade.Clicker));
			Debug.Log ("Current Scoreboard level is: " + FetchUpgradeLevel (Upgrade.Scoreboard));
			Debug.Log ("Current Units" + units.ToString ());
			Debug.Log ("Level 0: " + GetNextCost (0));
			Debug.Log ("Level 1: " + GetNextCost (1));
			Debug.Log ("Level 2: " + GetNextCost (2));
			Debug.Log ("Level 3: " + GetNextCost (3));
			Debug.Log ("Available Upgrades: " + AvailableUpgrades);
		}
			
		UpdateAvailableUpgrades ();
	}
	#endregion

	#region Saving and Loading
	public void SaveLocal(){

	}

	public void LoadLocal(){
		//Temp solution
		upgrades.Add (Upgrade.Clicker, 1);
		upgrades.Add (Upgrade.Scoreboard, 0);
		upgrades.Add (Upgrade.Solution, 1);
		upgrades.Add (Upgrade.UpgradeTable, 1);
		upgrades.Add (Upgrade.Layout, 0);
		units = 0;
	}
	#endregion

	#region Main Functions
	public void GainUnits(){
		int level = FetchUpgradeLevel (Upgrade.Clicker);
		switch (level) {
		case 1:
			units += 1;
			break;
		}
	}

	public void PurchaseUpgrade(Upgrade upgradeType){
		int level = FetchUpgradeLevel (upgradeType);
		if (units >= GetNextCost (level)) {
			units -= GetNextCost (level);
			upgrades [upgradeType] += 1;
			DisplayedUpgrades.Remove (upgradeType);
			Destroy(GameObject.FindGameObjectWithTag(upgradeType.ToString()));
			Debug.Log ("Purchase complete: " + upgradeType.ToString ());
		}
	}

	public int GetNextCost(int level){
		return (int)(5 * Mathf.Sqrt (level)) + 5;
	}

	public int FetchUpgradeLevel(Upgrade upgradeType){
		return upgrades [upgradeType];
	}

	public void UpdateAvailableUpgrades(){
		foreach (KeyValuePair<Upgrade,int> cur in upgrades) {
			if (units >= GetNextCost(cur.Value)) {
				if (!AvailableUpgrades.Contains (cur.Key) && !DisplayedUpgrades.Contains(cur.Key)) {
					AvailableUpgrades.Add (cur.Key);
				}
			}
		}
	}

	#endregion
}
