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





module.exports = {
	findEntreprise: function(db,query,callback) {
		var cursor =db.collection('test').find({"Entreprise":""+query});
		var doc = [];
		var i=0;
		cursor.each(function(err,item) {
			assert.equal(err, null);
		  if (item != null) {
				doc[i] = item;
				console.dir(doc[i]);
			}else{
				callback(doc);
			}
		});
	}
};