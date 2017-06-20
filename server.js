//Global var
var DBtools = require('./DBtools.js'); //===>inclusion des querys et outils de prefetching
	http = require('http');
	url = require('url');
	fs = require('fs');//middleware file input/output
	querystring = require('querystring');
	session = require('cookie-session'); // Charge le middleware de sessions
	bodyParser = require('body-parser'); // Charge le middleware de gestion des paramètres


//var Mongo
var MONGODBURL = 'mongodb://localhost:27017/ACF_Test';
	MongoClient = require('mongodb').MongoClient,
    Server = require('mongodb').Server,
    ReplSetServers = require('mongodb').ReplSetServers,
    ObjectID = require('mongodb').ObjectID,
    Binary = require('mongodb').Binary,
    GridStore = require('mongodb').GridStore,
    Grid = require('mongodb').Grid,
    Code = require('mongodb').Code,
    BSON = require('mongodb').BSON,
    assert = require('assert');
var db;



//csv-to-json
var csv = require('csv-to-json');//Charge le parser CSV 
//Express var
var express = require('express');
	 app = express();

//App global var
var PORT = 8080;
//=> Pour set des variable qui ne bouge pas accessible par app peut importe ou, utiliser app.local.nomvariable =...





//Démarrage de la base Mongo, je ne la ferme pas ensuite (accés facile avec db directe). Si utilisateur il y'a, on gère la connexion ici.
MongoClient.connect(MONGODBURL, (err, database) => {
  if (err) return console.log(err)
  db = database
  app.listen(PORT, () => {
    console.log('listening on ' + PORT)
  })
});


				// PARAMETRAGE \\

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
	res.render('menu.ejs', {body: res.render('chambre.ejs')});
	
}).get('/todo', function(req, res) { 
    //res.render('todo.ejs', {todolist: req.session.todolist});  => Implémentation du reminder
	
}).get('/makeimport', function(req, res) {  //L'idée est de permetre à un utilisateur d'importé de la data CSV si besoin 
	res.setHeader('Content-Type', 'text/plain');
    res.end('WIP');
	
}).get('/request', function(req, res) {//Route pour la recherche
	res.setHeader('Content-Type', 'text/html');
	res.render('queryFormular.ejs');
	
}).get('/queryAnswer', function(req, res) {
	res.setHeader('Content-Type', 'text/html');
    res.end('WIP');
})


//Affichage des post et traitement des données MANGO
.post('/request/queryForm',function(req,res){
	if(req.body.query != ''){
		var value = req.body.query;		
		DBtools.findEntreprise(db,value,function(doc){
			res.setHeader('Content-Type', 'text/html');
			res.end('Query :'+value+'===> Result :'+JSON.stringify(doc));
		});
	}else{
		res.setHeader('Content-Type', 'text/html');
		res.end('ERROR');
	}
	
})

//=> ptet changer l'API de palce et la mettre dans un autre fichier ?


// API GET
.get('/api', function(req, res) {
	res.setHeader('Content-Type', 'text/html');
    res.end('WIP');
})

//API POST
.post('/api/json/:outlookdata',function(req,res){
	if(req.body.query != ''){
		var value = req.body.query;		
		DBtools.findEntreprise(db,value,function(doc){
			res.setHeader('Content-Type', 'text/html');
			res.end('Query :'+value+'===> Result :'+JSON.stringify(doc));
		});
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





