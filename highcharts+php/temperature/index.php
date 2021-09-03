<!DOCTYPE html>
<html>
<head>
<meta http-equiv="refresh" content="60"/> 
	<title>Test</title>  
	<script
	src="https://code.jquery.com/jquery-3.4.1.min.js"
	integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo="   
	crossorigin="anonymous"></script>
	<script src="/highcharts/code/highcharts.js"></script>
</head>
<body>
	<script src="/highcharts/code/modules/exporting.js"></script>
	<script src="/highcharts/code/modules/export-data.js"></script>
	<div id="container" style="width:100%; height:400px;"></div>  
	<script type="text/javascript">
Highcharts.getJSON(
    'tempext.php',
    function (tempext) {
		Highcharts.getJSON(
			'tempint.php',
			function (tempint) {
				Highcharts.getJSON(
					'time.php',
					function (time) {

						Highcharts.chart('container', {

							chart: {
								type: 'line',
								zoomType: 'x',
								scrollablePlotArea: {
									minWidth: 600,
									scrollPositionX: 1
								}
							},

							title: {
								text: 'Variation de la température'
							},
							xAxis: {
								categories: time
							},
							yAxis: {
								title: {
									text: null
								}
							},

							tooltip: {
								crosshairs: true,
								shared: true,
								valueSuffix: '°C'
							},

							legend: {
								enabled: false
							},

							series: [{
								name: 'Exterrieur',
								data: tempext
							}, {
								name: 'Interrieur',
								data: tempint
							}]
						});
					}
				);
			}
		);
    }
);
</script>
</body>
</html>