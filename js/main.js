var User = {
	username: "",
    units: 0,
    totalUnits: 0,
},
UI = {
	clicker:{
    	button: document.getElementById("clicker"),
    	level: 1,
    },
    units:{
    	text: document.getElementById("units"),
    },
    unitsgroup:{
    	id: "units-group",
    	text: document.getElementById("units-group"),
    },
    upgradesgroup:{
    	id: "upgrades-group",
        container: document.getElementById("upgrades-group"),
        table: document.getElementById("upgrades-table"),
        scoreboard:{
        	row: "scoreboard-row",
        	level: document.getElementById("scoreboard-level"),
            cost: document.getElementById("scoreboard-cost"),
        },
        tableheader: {
        	row: "tableheader-row",
            level: document.getElementById("tableheader-level"),
            cost: document.getElementById("tableheader-cost"),
        },
    },
},
Upgrades = {
	Scoreboard:{
    	bought: false,
        cost: 5,
        level: 1,
    },
    TableHeader:{
    	bought: false,
        cost: 20,
        level: 1,
    },
}

//Unplemented code needs
//to be called when loading
//screen is added
function Start(){
	UI.clicker.button.onclick = function(){
    	GainUnits();
    }
    
    UI.units.text.innerHTML = User.units;
    
    UpdateUI();
}

function Update(){
	UI.units.text.innerHTML = User.units;
    UpdateUI();
}

function UpdateUI(){
	if(Upgrades.Scoreboard.bought == true){
    	$("#" + UI.unitsgroup.id).removeClass('hidden');
        $("#" + UI.upgradesgroup.scoreboard.row).addClass('hidden');
    }else{
    	$("#" + UI.unitsgroup.id).addClass('hidden');
        if(User.totalUnits >= 3){
        	$("#" + UI.upgradesgroup.scoreboard.row).removeClass('hidden');
        }else{
        	$("#" + UI.upgradesgroup.scoreboard.row).addClass('hidden');
        }
    }
    
    if(Upgrades.TableHeader.bought == true){
    	$("#header").removeClass('hidden');
        $("#" + UI.upgradesgroup.tableheader.row).addClass('hidden');
    }else{
    	$("#header").addClass('hidden');
        if(User.totalUnits >= 10){
        	$("#" + UI.upgradesgroup.tableheader.row).removeClass('hidden');
        }else{
        	$("#" + UI.upgradesgroup.tableheader.row).addClass('hidden');
        }
    }
}

function GainUnits(){
	User.units += 1;
    User.totalUnits += 1;
}

setInterval(Update,1000);