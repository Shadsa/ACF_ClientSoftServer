//Global var
var DBtools = require('./DBtools.js'); //===>inclusion des querys et outils de prefetching
	http = require('http');
	url = require('url');
	fs = require('fs');//middleware file input/output
	querystring = require('querystring');
	session = require('cookie-session'); // Charge le middleware de sessions
	bodyParser = require('body-parser'); // Charge le middleware de gestion des paramètres
	multipart = require('connect-multiparty'); //charge le middleware de gestion de fichier d'upload (attention, création de fichier temporaire)
	multipartMiddleware = multipart();
	menu = fs.readFileSync("./views/menu.ejs", "utf8");


//var Mongo
var MongoDBName = 'ACF_DB',
	MONGODBURL = 'mongodb://localhost:27017/'+MongoDBName;
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





//Démarrage de la base Mongo, je ne la ferme pas ensuite (accés facile avec db directe). Si utilisateur 
//il y'a, on gère la connexion ici. Crée la BD si inexistante
MongoClient.connect(MONGODBURL, (err, database) => {
  if (err) return console.log(err)
  db = database;
  DBtools.DBInitialisation(db);  
  app.listen(PORT, () => {
    console.log('listening on ' + PORT);
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

//Affichage des get
.get('/', function(req, res) {
	
    res.setHeader('Content-Type', 'text/html');
	res.render('mainpage.ejs');
	
}).get('/makeimport/importForm', function(req, res) {//L'idée est de permetre à un utilisateur d'importé de la data CSV si besoin 
		res.setHeader('Content-Type', 'text/html');
		res.render('CSVimportFormular.ejs');

}).get('/makeimport/useData', function(req, res) {//L'idée est de permetre à un utilisateur d'importé de la data CSV si besoin 
		if(req.query.answer == 1){
			DBtools.LoadContact(db,"./documents/CSV/EntrepriseExport.csv");
		}		
		res.setHeader('Content-Type', 'text/html');
		res.render('CSVLoaderAnswer.ejs' ,{answer : req.query.answer});	
	
}).get('/request', function(req, res) {//Route pour la recherche
	res.setHeader('Content-Type', 'text/html');
	res.render('queryFormular.ejs');
	
}).get('/contactView', function(req, res) {//Route pour la recherche
	res.setHeader('Content-Type', 'text/html');
	res.render('queryFormular.ejs');
	
}).get('/mailView', function(req, res) {//Route pour la recherche
	res.setHeader('Content-Type', 'text/html');
	res.render('queryFormular.ejs');
	
}).get('/todoView', function(req, res) {//Route pour la recherche
	 //res.render('todo.ejs', {todolist: req.session.todolist});  => Implémentation du reminder
	
})






















//Point d'accée de la requête Mango et redirection vers d'autre traitement coté DB.
.post('/request/queryForm',function(req,res){
	if(req.body.query != ''){
		var value = req.body.query;		
		var QueryObject=req.body.queryobject;
		var doc;
		var display = function(doc){
			if(doc == undefined){
				res.setHeader('Content-Type', 'text/html');
				res.end(menu+'<p>ERROR !!! CHECK LOG</p>');
			}else{
				console.log(doc)
				res.setHeader('Content-Type', 'text/html');
				res.end(menu+'<p>Asked query :</p>'+QueryObject+'<p>Query With Multiple Engine  :'+value+'===> Result :'+JSON.stringify(doc["ContactPerEntreprise"])+'</p>');
			} 
			if(doc.ContactPerEntreprise != []){

			}

			if(doc.ContactPerMail != []){

			}

			if(doc.ContactPerMail != []){
				
			}

			
		}
		if(QueryObject == "Mail"){
			DBtools.multipleQueryEngine(db,"Mail",value,display);
		}else if(QueryObject=="Contact"){
			DBtools.multipleQueryEngine(db,"Contact",value,display);
		}else if(QueryObject=="Object"){
			DBtools.multipleQueryEngine(db,"Object",value,display);
		}
		
	}else{
		affichage(undefined);
	}
	
})

//Post d'upload CSV
.post('/makeimport/handler',multipartMiddleware,function(req,res){
	if(req.files.query != ''){
		var path = req.files.query.path
		var file = fs.readFileSync(path);
		fs.writeFile("./documents/CSV/EntrepriseExport.csv",file,function(err) {
			if(err) {
				return console.log(err);
			}
			fs.unlinkSync(path); // a cause d'une copie temporaire crée par le middleware.
		});
		res.setHeader('Content-Type', 'text/html');
		res.render('CSVLoader.ejs');
	}
	
})

















					////////// API PART \\\\\\\\\\\\\

// API GET
.get('/api', function(req, res) {
	res.setHeader('Content-Type', 'text/html');
    res.end('WIP');
}).get('/api/json', function(req, res) {
	var o = JSON.stringify(req.body)
	fs.writeFile("./documents/doc.json", o, function(err) {
		if(err) {
			return console.log(err);
		}

		console.log("The file was saved!");
	}); 
	res.setHeader('Content-Type', 'text/html');
    res.end('WIP');
})

//API POST
.post('/api/mail',function(req,res){
	var o = JSON.stringify(req.body)
	var jsonObject = req.body;
	fs.writeFile("./documents/doctmp.json", o, function(err) {
		if(err) {
			return console.log(err);
		}

		console.log("The file was saved!");
	}); 
	res.setHeader('Content-Type', 'text/html');
    res.end('Le mail à bien été envoyé au serveur !');
	
}).post('/api/contact',function(req,res){
	
	
}).post('/api/reminder',function(req,res){
	
	
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





