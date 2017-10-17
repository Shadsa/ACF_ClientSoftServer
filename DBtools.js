/*findEntreprise : function(db,query,callback) {
var cursor =db.collection('test').find({"Entreprise":""+query[0]});
   cursor.each(function(err, doc) {
      assert.equal(err, null);
      if (doc != null) {
         console.dir(doc);
      } else {
         callback();
      }
   });
}	
	
};*/

//var Mongo
var MongoDBName = 'ACF_DB',
    MongoImportExec = "\"C:/Program Files/MongoDB/Server/3.4/bin/mongoimport.exe\""
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
var exec = require('child_process').exec;



/* DOCUMENTATION & Diary 
	Pour faire de la recherche partiel sur mongo, il existe des expression reguliére permettant de trouvé des
	strings matchant un substring donnée.
	=> Use option i => /query/i


	Documentation Database & data format :

	Client :
-	NomEntreprise
-	Adresse+complément (toutenun)
-	CP
-	Ville
-	Civilité
-	Nom
-	Tel
-	Mail
-	Fonction
-	Client (bool)

Reminder : 
-	Date
-	ObjetNote
-	Validation (effectuer ou non)
-	Propriétaire du reminder (gestion de compte)

Mails : 
-	Sender ( a plats, et pas en sous tableau
	o	Nome
	o	Mail
-	Objet
-	Body
-	CC
-	BCC
-	Date


Piece jointe (Data):
-	ID
-	Contact (mail de l’envoyeur)
-	Date
-	StockPath ?


Compte client :
-	Mail (vérification de mail ptet ?)
-	Nom
-	Prenom
- Md5 hash = Password





*/


















var DBInitialisation = function(db) {
    //Creation de la base déja faite dans le server.js
    db.createCollection("Reminder", function(err, res) {
       if (err) throw err;
      else console.log("Table created!");
    });
     db.createCollection("Contact", function(err, res) {
       if (err) throw err;
      else console.log("Table created!");
    });
     db.createCollection("Mail", function(err, res) {
       if (err) throw err;
      else console.log("Table created!");
    });
		 db.createCollection("Data", function(err, res) {
       if (err) throw err;
      else console.log("Table created!");
		});
		db.createCollection("Account", function(err, res) {
       if (err) throw err;
      else console.log("Table created!");
    });
   
	}


	//INSERT FUNCTION
  var InsertReminder = function(db,query,callback) {
		db.collection('Reminder').insertOne(query,function(err,res){
			if (err) throw err;
			else console.log("Table Reminder uptaded with a new entry");
			callback(err);
		});
	
	}
  var InsertData= function(db,query,callback) {
			db.collection('Data').insertOne(query,function(err,res){
			if (err) throw err;
			else console.log("Table Data uptaded with a new entry");
			callback(err);
		});
		
	}
	var InsertMail= function(db,query,callback) {
		db.collection('Mail').insertOne(query,function(err,res){
			if (err) throw err;
			else console.log("Table Mail uptaded with a new entry");
			callback(err);
		});
	}
  var InsertContact= function(db,query,callback) {
		db.collection('Contact').insertOne(query,function(err,res){
			if (err) throw err;
			else console.log("Table Contact uptaded with a new entry");
			callback(err);
		});
		
	}
	var InsertAccount= function(db,query,callback) {
		db.collection('Account').insertOne(query,function(err,res){
			if (err) throw err;
			else console.log("Table Account uptaded with a new entry");
			callback(err);
		});
		
	}


	//UPDATE Function




	//DELETE Function

	var DeleteReminderByReminderObject = function(db,query,callback) {
		db.collection('Reminder').deleteMany({ReminderObject:query},function(err,res){
			if (err) throw err;
      else console.log("Table Reminder uptaded with a deleted entry");
		});
		callback();
	}
		var DeleteReminderByDateLTE = function(db,query,callback) {
		db.collection('Reminder').deleteMany({ReminderObject:{$lte:query}},function(err,res){
			if (err) throw err;
      else console.log("Table Reminder uptaded with a deleted entry");
		});
		callback();
	}
	var DeleteReminderByDateE = function(db,query,callback) {
		db.collection('Reminder').deleteMany({ReminderObject:{$eq:query}},function(err,res){
			if (err) throw err;
      else console.log("Table Reminder uptaded with a deleted entry");
		});
		callback();
	}
	var DeleteReminderByDateGTE = function(db,query,callback) {
		db.collection('Reminder').deleteMany({ReminderObject:{$gte:query}},function(err,res){
			if (err) throw err;
      else console.log("Table Reminder uptaded with a deleted entry");
		});
		callback();
	}
  var DeleteData= function(db,query,callback) {
			db.collection('Data').deleteMany({ID:query},function(err,res){
			if (err) throw err;
      else console.log("Table Data uptaded with a deleted entry");
		});
		callback();
	}
	var DeleteMailBySubject= function(db,query,callback) {
		db.collection('Mail').deleteMany({Subject:query},function(err,res){
			if (err) throw err;
      else console.log("Table Mail uptaded with a deleted entry");
		})
		callback();
	}
	var DeleteMailBySenderMail= function(db,query,callback) {
		db.collection('Mail').deleteMany({SenderMail:query},function(err,res){
			if (err) throw err;
      else console.log("Table Mail uptaded with a deleted entry");
		})
		callback();
	}
	var DeleteMailBySenderName= function(db,query,callback) {
		db.collection('Mail').deleteMany({SenderMail:query},function(err,res){
			if (err) throw err;
      else console.log("Table Mail uptaded with a deleted entry");
		})
		callback();
	}
  var DeleteContactByEntreprise= function(db,query,callback) {
		db.collection('Contact').deleteMany({Entreprise:query},function(err,res){
			if (err) throw err;
      else console.log("Table Contact uptaded with a deleted entry");
		});
		callback();
	}
	var DeleteContactByName= function(db,query,callback) {
		db.collection('Contact').deleteMany({Nom:query},function(err,res){
			if (err) throw err;
      else console.log("Table Contact uptaded with a deleted entry");
		});
		callback();
	}
	var DeleteContactByTel= function(db,query,callback) {
		db.collection('Contact').deleteMany({Tel:query},function(err,res){
			if (err) throw err;
      else console.log("Table Contact uptaded with a deleted entry");
		});
		callback();
	}
	var DeleteContactByMail= function(db,query,callback) {
		db.collection('Contact').deleteMany({Mail:query},function(err,res){
			if (err) throw err;
      else console.log("Table Contact uptaded with a deleted entry");
		});
		callback();
	}
	var DeleteAccount= function(db,query,callback) {
		db.collection('Account').deleteMany(query,function(err,res){
			if (err) throw err;
      else console.log("Table Account uptaded with a deleted entry");
		});
		callback();
	}



	//Functional module
  var LoadContact= function(db,CSVPath,callback) {
    db.collection('Contact').deleteMany({});
    var cmd = MongoImportExec+" --db "+MongoDBName+" --collection Contact  --type csv --headerline --file \""+__dirname+"/documents/CSV/EntrepriseExport.csv\""
    exec(cmd, function(error, stdout, stderr) {
        if(error != null){
          console.log(error);
					callback(error);
        }else{
          console.log("Contact rewrite done sucefully")
					callback();
        }
    });
		callback();
	}
	var AddContactFromCSV= function(db,CSVPath,callback) {
		var cmd = MongoImportExec+" --db "+MongoDBName+" --collection Contact  --type csv --headerline --file \""+__dirname+"/documents/CSV/EntrepriseExport.csv\""
    exec(cmd, function(error, stdout, stderr) {
        if(error != null){
          console.log(error);
					callback(error);
        }else{
          console.log("Contacts add to database")
					callback();
        }
    });
		
	}

	// QUERY Function
	var findReminderPerAccount= function(db,query,callback) {
		//Match complet sur mail uniquement
		var cursor =db.collection('Reminder').find({Owner: query});
		var doc = [];
		var i=0;
		cursor.each(function(err,item) {
			assert.equal(err, null);
		  if (item != null) {
				doc[i] = item;
				i++;
			}else{				
				callback(doc);
			}
		});
	}
	var findAccountPerMail= function(db,query,callback) {
		//Match complet sur mail uniquement
		var cursor =db.collection('Account').find({Mail: query});
		var doc = [];
		var i=0;
		cursor.each(function(err,item) {
			assert.equal(err, null);
		  if (item != null) {
				doc[i] = item;
				i++;
			}else{				
				callback(doc);
			}
		});
	}
	var findContactPerEntreprise= function(db,query,callback) {
		var val = query;
		//permet d'obtenir des matchs incomplet (regexp) et des matchs complet
		var cursor =db.collection('Contact').find({Entreprise: new RegExp(val)}); //{ $regex: 'pattern', $options: '<options>' } => a test pour enlever le case sensitive
		var doc = [];
		var i=0;
		cursor.each(function(err,item) {
			assert.equal(err, null);
		  if (item != null) {
				doc[i] = item;
				i++;
			}else{
				
				callback(doc);
			}
		});
	}
  var findContactPerName= function(db,query,callback) {
		var val = query;
		//permet d'obtenir des matchs incomplet (regexp) et des matchs complet
		var cursor =db.collection('Contact').find({Name: new RegExp(val)});
		var doc = [];
		var i=0;
		cursor.each(function(err,item) {
			assert.equal(err, null);
		  if (item != null) {
				doc[i] = item;
				i++;
			}else{				
				callback(doc);
			}
		});
	}
  var findContactPerMail= function(db,query,callback) {
		var val = query;
		//permet d'obtenir des matchs incomplet (regexp) et des matchs complet
		var cursor =db.collection('Contact').find({Mail: new RegExp(val)});
		var doc = [];
		var i=0;
		cursor.each(function(err,item) {
			assert.equal(err, null);
		  if (item != null) {
				doc[i] = item;
				i++;
			}else{
				callback(doc);
			}
		});
	}
  var findContactPerClientAttribute= function(db,query,callback) {
    var client;
    if(query = 1)
      client = "o";
      else
      client = "n";
    
		var cursor =db.collection('Contact').find({Client : client});
		var doc = [];
		var i=0;
		cursor.each(function(err,item) {
			assert.equal(err, null);
		  if (item != null) {
				doc[i] = item;
				i++;
			}else{
				callback(doc);
			}
		});
	}













  var multipleQueryEngine= function(db,type,query,callback) {
		var metadoc = [];
		if(type = "Contact"){
			findContactPerEntreprise(db,query,function(doc1){
				metadoc["ContactPerEntreprise"] = doc1;
					findContactPerName(db,query,function(doc2){
						metadoc["ContactPerName"] = doc2;
							findContactPerMail(db,query,function(doc3){
								metadoc["ContactPerMail"] = doc3;								
									callback(metadoc);
							});
					});
			});

		}else if(type = "Reminder") {

		}else if(type = "Mail"){

		}else if(type = "Object"){

		}else if(type = "prospection"){
			findContactPerClientAttribute(db,query,function(doc){metadoc["ClientProspectionSearch"]=doc});
		}
	
	}
  var extrapolationEngine = function(db,query) {
		
	}








/*EXPORT*/


module.exports = {
	DBInitialisation:DBInitialisation,
	InsertContact:InsertContact,
	InsertData:InsertData,
	InsertMail:InsertMail,
	InsertReminder:InsertReminder,
	InsertAccount:InsertAccount,
	LoadContact:LoadContact,
	findContactPerClientAttribute:findContactPerClientAttribute,
	findContactPerEntreprise:findContactPerEntreprise,
	findContactPerMail:findContactPerMail,
	findContactPerName:findContactPerName,
	findAccountPerMail:findAccountPerMail,
	findReminderPerAccount:findReminderPerAccount,
	AddContactFromCSV:AddContactFromCSV,
  multipleQueryEngine: multipleQueryEngine,
	extrapolationEngine: extrapolationEngine
};