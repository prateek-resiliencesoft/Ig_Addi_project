$(document).ready(function(){
	$("#open li > *:not(h3)").hide();
	$("#open h3").css("cursor","pointer").click(function (){
		//selezioniamo tutte le risposte
		var risposta = $(this).siblings();
		//mostriamo/nascondiamo le risposte
		risposta.slideToggle("slow");
	});
});
