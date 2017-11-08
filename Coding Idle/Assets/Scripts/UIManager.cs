using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public static UIManager Instance{ set; get; }

	public GameObject upgradePrefab;

	public GameObject[] clickers;
	public GameObject[] scoreboards;
	public GameObject[] solution;
	public GameObject[] upgradeTable;

	private void Awake(){
		Instance = this;
	}

	private void Update(){
		UpdateUI ();
	}

	public void UpdateUI(){
		#region Clicker
		//Get level of clicker
		int clickerLevel = GameManager.Instance.FetchUpgradeLevel(Upgrade.Clicker);
		//Make sure correct clicker is always displayed
		clickers[clickerLevel - 1].SetActive(true);
		//Make sure no other clickers are displayed
		foreach(GameObject go in clickers){
			if(go != clickers[clickerLevel - 1]){
				go.SetActive(false);
			}
		}
		#endregion

		#region Scoreboard
		//Get level of scoreboard
		int scoreboardLevel = GameManager.Instance.FetchUpgradeLevel (Upgrade.Scoreboard);
		//Check if scoreboard has been bought
		if (GameManager.Instance.FetchUpgradeLevel (Upgrade.Scoreboard) != 0) {
			//Display correct scoreboard
			scoreboards [scoreboardLevel - 1].SetActive (true);
			//Make sure scoreboard is displaying correct value
			scoreboards [scoreboardLevel - 1].GetComponentInChildren<Text> ().text = GameManager.Instance.units.ToString ();
			//Make sure no other scoreboards are being displayed
			foreach (GameObject go in scoreboards) {
				if (go != scoreboards [scoreboardLevel - 1]) {
					go.SetActive (false);
				}
			}
		}
		#endregion

		#region Solution
		int solutionLevel = GameManager.Instance.FetchUpgradeLevel(Upgrade.Solution);
		solution[solutionLevel - 1].SetActive(true);
		foreach(GameObject go in solution){
			if(go != solution[solutionLevel - 1]){
				go.SetActive(false);
			}
		}

		#endregion

		#region UpgradeTable
		int upgradeTableLevel = GameManager.Instance.FetchUpgradeLevel(Upgrade.UpgradeTable);
		upgradeTable[upgradeTableLevel - 1].SetActive(true);
		foreach(GameObject go in upgradeTable){
			if(go != upgradeTable[upgradeTableLevel - 1]){
				go.SetActive(false);
			}
		}

		//TODO
		//Add a way to find the currently active table and add new upgrades prefab there

		#endregion
	}
}
