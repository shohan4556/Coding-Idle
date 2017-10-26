<?
	$key = $_GET['key'];
?>
<!DOCTYPE html>
<html>
<head>
	<title></title>
	<meta charset="utf-8">
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css" integrity="sha384-PsH8R72JQ3SOdhVi3uxftmaW6Vc51MKb0q5P2rRUpPvrszuE4W1povHYgTpBfshb" crossorigin="anonymous">
	<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
</head>
<style>
	.hidden{
    	display: none;
    }
</style>
<body>
	<div id="clicker-group">
    	<button id="clicker">Gain Units</button>
    </div>
    <div id="units-group">
    	<p id="units">6</p>
    </div>
    <div id="upgrades-group">
    	<table id="upgrades-table">
        	<tr id="header">
            	<td><b>Upgrade Name</b></td>
                <td><b>Level</b></td>
            </tr>
            <tr id="scoreboard-row">
            	<td>Scoreboard</td>
                <td>level(<span id="scoreboard-level">6</span>)</td>
                <td><button id="purchase-scoreboard">Buy: <span id="scoreboard-cost"></span> Units</button></td>
            </tr>
            <tr id="tableheader-row">
            	<td>Table Header</td>
                <td>level(<span id="tableheader-level">6</span>)</td>
                <td><button id="purchase-tableheader">Buy: <span id="tableheader-cost"></span> Units</button></td>
            </tr>
        </table>
    </div>
    
    <script src="js/main.js<? echo $key; ?>"></script>
    <script>
    	Start();
    </script>
</body>
</html>
