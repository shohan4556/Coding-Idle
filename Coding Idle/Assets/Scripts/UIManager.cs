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
	public GameObject[] layout;

	#region Monobehavior Callbacks
	private void Awake(){
		Instance = this;
	}

	private void Update(){
		UpdateUI ();
	}

	#endregion

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
			scoreboards [scoreboardLevel - 1].GetComponentInChildren<Text> ().text = "Units: " + GameManager.Instance.units.ToString ();
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
		//TEMP SOLUTION

		GameObject currentTable = upgradeTable[upgradeTableLevel - 1];
		GameObject content = currentTable.GetComponentInChildren<Text>().gameObject;
		if(GameManager.Instance.AvailableUpgrades != null){
			foreach(Upgrade upg in GameManager.Instance.AvailableUpgrades){
				int displayCount = GameManager.Instance.DisplayedUpgrades.Count;
				Transform newTransform = content.transform;
				GameObject go = Instantiate(upgradePrefab,newTransform);
				go.tag = upg.ToString();
				go.GetComponent<RectTransform>().position += new Vector3(0,-78 * displayCount,0);
				go.GetComponentInChildren<Text>().text = upg.ToString() + "(level: " + GameManager.Instance.upgrades[upg] + ")";
				go.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "Buy for " + GameManager.Instance.GetNextCost(GameManager.Instance.upgrades[upg]).ToString() + " units";
				go.GetComponentInChildren<Button>().onClick.AddListener(delegate() {
					GameManager.Instance.PurchaseUpgrade(upg);
				});
					
				GameManager.Instance.DisplayedUpgrades.Add(upg);
			}
			GameManager.Instance.AvailableUpgrades.Clear();
		}
		#endregion

		#region Layout
		int layoutLevel = GameManager.Instance.FetchUpgradeLevel(Upgrade.Layout);
		if(GameManager.Instance.FetchUpgradeLevel(Upgrade.Layout) != 0){
			layout[layoutLevel - 1].SetActive(true);
			foreach(GameObject go in layout){
				if(go != layout[layoutLevel - 1]){
					go.SetActive(false);
				}
			}

			if(layoutLevel == 1){
				solution[solutionLevel - 1].GetComponent<RectTransform>().position = new Vector3(185,177,0);
			}
		}
		#endregion
	}
}
