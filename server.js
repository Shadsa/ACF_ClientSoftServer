//Global var
var DBtools = require('./DBtools.js'); //===>inclusion des querys et outils de prefetching
	API=require('./API_OUtlook.js');//==> contient les fonctions de traitement des appels API
	http = require('http');
	url = require('url');
	fs = require('fs');//middleware file input/output
	session = require('cookie-session'); // Charge le middleware de sessions
	bodyParser = require('body-parser'); // Charge le middleware de gestion des paramètres
	multipart = require('connect-multiparty'); //charge le middleware de gestion de fichier d'upload (attention, création de fichier temporaire)
	multipartMiddleware = multipart();
	menu = fs.readFileSync("./views/menu.ejs", "utf8");
	md5 = require('md5');
	csv = require('csv-to-json');
	express = require('express');
	ejs = require('ejs');
	app = express();
	PORT = 8080;


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
app.use(session({secret: 'C&c1&stl@b1t&d4st@g1a1r&'}));//Session Initialisation
app.use(express.static('public'));
app.set('view cache', false);

























					// MAIN APPLICATION \\



//GLOBAL VAR AND FUNCTION



var requestGlobalDisplay = function(req,res,value,QueryType,doc,view){
	if(doc == undefined){
		req.session.message = "Une erreur est survenue lors de la requête";
		redirect("/");
	}else if(QueryType == undefined){
		req.session.message = "Selectionner le type de votre requête !";
		res.redirect("/request"); 

	}else{
		//console.log(doc);
		if(QueryType=="Contact"){
			res.render(view,{username : req.session.username,message:req.session.message ,value:value,doc:doc });
		}else if(QueryType == "Mail"){
			res.render(view,{username : req.session.username,message:req.session.message ,value:value,doc:doc });
		
		}else if(QueryType == "Object"){
			res.render(view,{username : req.session.username,message:req.session.message ,value:value,doc:doc });
		
		}else if(QueryType == "Reminder"){
			res.render(view,{username : req.session.username,message:req.session.message ,value:value,doc:doc });
		
		}else{
			res.render(view,{username : req.session.username,message:req.session.message ,value:value,doc:doc });
		
		}
		
		

	}

			
}












//Affichage des get
app.get('/', function(req, res) {	
	if(req.session.username == undefined){
		res.redirect('/login');		
	}else{
		res.setHeader('Content-Type', 'text/html');
		res.render('mainpage.ejs',{username: req.session.username, message: req.session.message});		
	}   
	
}).get('/makeimport/importForm', function(req, res) {//L'idée est de permetre à un utilisateur d'importé de la data CSV si besoin 
	res.setHeader('Content-Type', 'text/html');
	res.render('CSVimportFormular.ejs',{username: req.session.username, message: req.session.message});

}).get('/makeimport/useData', function(req, res) {//L'idée est de permetre à un utilisateur d'importé de la data CSV si besoin 
	if(req.query.answer == 1){
		DBtools.LoadContact(db,"./documents/CSV/EntrepriseExport.csv",{username: req.session.username, message: req.session.message});
	}		
	res.setHeader('Content-Type', 'text/html');
	res.render('CSVLoaderAnswer.ejs' ,{answer : req.query.answer,username: req.session.username, message: req.session.message});	
	
}).get('/request', function(req, res) {//Route pour la recherche
	res.setHeader('Content-Type', 'text/html');
	res.render('queryFormular.ejs',{username: req.session.username, message: req.session.message});
	
}).get('/todoView', function(req, res) {//Route pour la recherche
	if(req.session.username == undefined){
		req.session.message = "Vous n'êtes pas authentifier";
		res.redirect("/login");
	}
	DBtools.findReminderPerAccount(db,req.session.usermail,function(doc){
		requestGlobalDisplay(req,res,req.session.usermail,"Reminder",doc,'todolistView.ejs');
	})
	
	
}).get('/addondl', function(req, res) {//Route pour la recherche
	 //res.render('todo.ejs', {todolist: req.session.todolist});  => Implémentation du reminder
	
}).get('/register', function(req, res) {//Route pour la recherche
		if(req.session.username != undefined){
			req.session.message = "Vous êtes déja authentifier";
			res.redirect("/");
		}
	 res.render('accountRegister.ejs', {username: req.session.username, message: req.session.message});  
	
}).get('/login', function(req, res) {//Route pour la recherche
	
	res.render('accountLogin.ejs', {username: req.session.username, message: req.session.message}); 	  
	
}).get('/account', function(req, res) {//Route pour la recherche
	 //res.render('todo.ejs', {todolist: req.session.todolist}); 
	
}).get('/signoff', function(req, res) {//Route pour la recherche
	req.session = null;
	res.redirect("/");
})

















//Point d'accée de la requête Mango et redirection vers d'autre traitement coté DB.
.post('/request',function(req,res){
	if(req.body.query != ''){
		var value = req.body.query;		
		var QueryObject=req.body.queryobject;
		var clientQuery = req.body.client;
		if(QueryObject == "Mail"){
			DBtools.multipleQueryEngine(db,"Mail",value,function(doc){
				requestGlobalDisplay(req,res,value,QueryObject,doc,'mailView.ejs');
			});
		}else if(QueryObject=="Contact"){
			if(clientQuery == "client"){
				DBtools.multipleQueryEngine(db,"Contact",value,function(doc){
					requestGlobalDisplay(req,res,value,"prospection",doc,'contactView.ejs');
				});
			}else{
				DBtools.multipleQueryEngine(db,"Contact",value,function(doc){
					requestGlobalDisplay(req,res,value,QueryObject,doc,'contactView.ejs');
				});
			}
		}else if(QueryObject=="Object"){
			DBtools.multipleQueryEngine(db,"Object",value,function(doc){
				requestGlobalDisplay(req,res,value,QueryObject,doc,'objectView.ejs');
			});
		}
		
	}else{
		affichage(undefined);
	}
	
})

//Post d'upload CSV
.post('/makeimport',multipartMiddleware,function(req,res){
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

//Connexion et Login
.post('/register',function(req,res){

		function validateEmail(email) {
  			var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  			return re.test(email);
		}

		if(req.body.query != ''){
			//Check if both password are the same 
			if(req.body.password != req.body.password2){
				req.session.message = "Les deux mot de passe ne sont pas identique !"
				res.redirect('/register');

			//Email Check
			}else if(!validateEmail(req.body.Mail)){
				req.session.message = "Le mail ne correspond pas à un type reconnu !"
				res.redirect('/register');
			}else{
				//Account creation
				DBtools.InsertAccount(db,{Mail:req.body.Mail,Nom:req.body.Name,Prenom:req.body.Surname,Password:md5(req.body.password)},function(err){
					if(err){
						req.session.message = "Une erreur est survenu durant la création du compte, veuillez reessayer."
						res.redirect("/register");
						console.log(err);
					}else{
						req.session.username = req.body.Name+" "+req.body.Surname;
						req.session.usermail = req.body.Mail;
						res.redirect("/");
					}				
				});
			}	
			
		}
		
}).post('/login',function(req,res){
		if(req.body.query != ''){
			DBtools.findAccountPerMail(db,req.body.Mail,function(doc){
				if(doc[0] != undefined ){
					if(md5(req.body.password) == doc[0]["Password"]){
					req.session.username = doc[0]["Nom"]+" "+doc[0]["Prenom"];
					req.session.usermail = doc[0]["Mail"];
					res.redirect("/");
					}else{
						req.session.message = "Mot de passe invalide";
						res.redirect("/login");
					}
				}else{
					req.session.message = "Adresse mail invalide : compte inexistant";
					res.redirect("/login");
				}
				
			});
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
	fs.writeFile("./documents/doctmpmail.json", o, function(err) {
		if(err) {
			return console.log(err);
		}

		console.log("The file was saved!");
	}); 
	res.setHeader('Content-Type', 'text/html');
    res.end('Le mail à bien été envoyé au serveur ! (Response in seerver.js, API part)');
	
}).post('/api/contact',function(req,res){
	var o = JSON.stringify(req.body)
	var jsonObject = req.body;
	fs.writeFile("./documents/doctmpcontact.json", o, function(err) {
		if(err) {
			return console.log(err);
		}

		console.log("The file was saved!");
	}); 
	res.setHeader('Content-Type', 'text/html');
    res.end('Le contact à bien été envoyé au serveur ! (Response in seerver.js, API part)');
	
}).post('/api/data',function(req,res){
	var o = JSON.stringify(req.body)
	var jsonObject = req.body;
	fs.writeFile("./documents/doctmpcontact.json", o, function(err) {
		if(err) {
			return console.log(err);
		}

		console.log("The file was saved!");
	}); 
	res.setHeader('Content-Type', 'text/html');
    res.end('Le contact à bien été envoyé au serveur ! (Response in seerver.js, API part)');
	
}).post('/api/reminder',function(req,res){
	
	var o = JSON.stringify(req.body)
	var jsonObject = req.body;
	fs.writeFile("./documents/doctmpreminder.json", o, function(err) {
		if(err) {
			return console.log(err);
		}

		console.log("The file was saved!");
	}); 
	res.setHeader('Content-Type', 'text/html');
    res.end('Le reminder à bien été envoyé au serveur ! (Response in seerver.js, API part)');
}).post('/api/authentification',function(req,res){	
	var o = JSON.stringify(req.body)
	var jsonObject = req.body;
	var jsonResponse;
	DBtools.findAccountPerMail(db,jsonObject["Mail"],function(doc){
		if(doc[0] != undefined ){
			if(md5(jsonObject["Password"]) == doc[0]["Password"]){
				name = doc[0]["Nom"]+" "+doc[0]["Prenom"];
				jsonResponse = {"User":name,"Auth":true};
			}else{
				jsonResponse ={"Message":"Mauvais mot de passe","Auth":false};
			}				
		}else{
			jsonResponse = {"Message":"Compte inexistant","Auth":false};
		}
		res.setHeader('Content-Type', 'application/json');
    	res.send(JSON.stringify(jsonResponse));
	});
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





