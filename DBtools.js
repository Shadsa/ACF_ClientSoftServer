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
   
	}
  var InsertReminder = function(db,query,callback) {
		
		callback();
	}
  var InsertData= function(db,query) {
			db.collection('Data').insert(query,function(err,res){
			if (err) throw err;
      else console.log("Table Data uptaded with a new entry");
		})
		callback();
	}
	var InsertMail= function(db,query,callback) {
		db.collection('Mail').insert(query,function(err,res){
			if (err) throw err;
      else console.log("Table Mail uptaded with a new entry");
		})
		callback();
	}
  var InsertContact= function(db,query) {
		db.collection('Contact').insert(query,function(err,res){
			if (err) throw err;
      else console.log("Table Contact uptaded with a new entry");
		})
		callback();
	}
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
	var findContactPerEntreprise= function(db,query,callback) {
		var val = query;
		//permet d'obtenir des matchs incomplet (regexp) et des matchs complet
		var cursor =db.collection('Contact').find({Entreprise: new RegExp(val)});
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
			findContactPerMail(db,query,function(doc1){
				metadoc["ContactPerMail"] = doc1;
					findContactPerEntreprise(db,query,function(doc2){
						metadoc["ContactPerEntreprise"] = doc2;
							findContactPerName(db,query,function(doc3){
								metadoc["ContactPerName"] = doc3;								
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
	LoadContact:LoadContact,
	findContactPerClientAttribute:findContactPerClientAttribute,
	findContactPerEntreprise:findContactPerEntreprise,
	findContactPerMail:findContactPerMail,
	findContactPerName:findContactPerName,
	AddContactFromCSV:AddContactFromCSV,
  multipleQueryEngine: multipleQueryEngine,
	extrapolationEngine: extrapolationEngine
};