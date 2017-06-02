//Global var
var DBtools = require('./DBtools.js'); //===>
var http = require('http');
var url = require('url');
var fs = require('fs');
var querystring = require('querystring');
var session = require('cookie-session'); // Charge le middleware de sessions
var bodyParser = require('body-parser'); // Charge le middleware de gestion des paramètres


//var Mongo
var MongoClient = require('mongodb').MongoClient;
var assert = require('assert');
var ObjectId = require('mongodb').ObjectID;
var MONGODBURL = 'mongodb://localhost:27017/ACF_Test';
var express = require('express');
var db;

//csv-to-json
var csv = require('csv-to-json');//Charge le parser CSV 

//Express var
var app = express();

//App global var
var PORT = 8080;
//=> Pour set des variable qui ne bouge pas accessible par app peut importe ou, utiliser app.local.nomvariable =...





//Paramétrage de l'appli
MongoClient.connect(MONGODBURL, (err, database) => {
  if (err) return console.log(err)
  db = database
  app.listen(PORT, () => {
    console.log('listening on ' + PORT)
  })
});


/** bodyParser.urlencoded(options)
 * Parses the text as URL encoded data (which is how browsers tend to send form data from regular forms set to POST)
 * and exposes the resulting object (containing the keys and values) on req.body
 */
app.use(bodyParser.urlencoded({
    extended: true
}));

/**bodyParser.json(options)
 * Parses the text as JSON and exposes the resulting object on req.body.
 */
app.use(bodyParser.json());






					// MAIN APPLICATION \\


app.use(session({secret: 'C&c1&stl@b1t&d4st@g1a1r&'}))//Session Initialisation
//Session Manipulation
/*
.use(function(req, res, next){
    if (typeof(req.session.todolist) == 'undefined') {
        req.session.todolist = [];
    }
    next();
})*/

//Affichage des gets
.get('/', function(req, res) {
    res.setHeader('Content-Type', 'text/plain');
    res.end('Vous êtes à l\'accueil');
	
}).get('/todo', function(req, res) { 
    //res.render('todo.ejs', {todolist: req.session.todolist});  =>Implémentation du reminder
	
}).get('/makeimport', function(req, res) {  //L'idée est de permetre à un utilisateur d'importé de la data CSV si besoin 
	res.setHeader('Content-Type', 'text/plain');
    res.end('WIP');
	
}).get('/request', function(req, res) {
	res.setHeader('Content-Type', 'text/html');
	res.render('queryFormular.ejs');
	
}).get('/queryAnswer', function(req, res) {
	res.setHeader('Content-Type', 'text/html');
    res.end('WIP');
})


//Affichage des post et traitement des données
.post('/request/queryForm',function(req,res){
	if(req.body.query != ''){
		var value = req.body.query;
		res.setHeader('Content-Type', 'text/html');
		res.end(""+req.body.query);
		DBtools.findEntreprise(db,req.body.query,function(){});
		//console.log(typeof DBtools.findEntreprise);
		console.log(typeof DBtools.findEntreprise); // => 'function'
	}else{
		res.setHeader('Content-Type', 'text/html');
		res.end('ERROR');
	}
	
})



		//		Test de route indépendante \\

//Test du render ejs
.get('/etage/:etagenum/chambre', function(req, res) {
    res.render('chambre.ejs', {etage: req.params.etagenum});
})

//Test du parsing CSV en Json
.get('/csv/:CSVName', function(req, res) {
	var obj = {
		filename: "\documents\\CSV\\"+req.params.CSVName+".csv"
	};
	var callback = function(err, json) {
		res.setHeader('Content-Type', 'text/plain');
		res.end(""+JSON.stringify(json));
	};
	csv.parse(obj,callback);
	
})

// ... Tout le code de gestion des routes se trouve au-dessus

.use(function(req, res, next){
    res.setHeader('Content-Type', 'text/plain');
    res.send(404, 'Page introuvable !');
});





