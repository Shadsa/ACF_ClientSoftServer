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
var MongoClient = require('mongodb').MongoClient;
var assert = require('assert');
var ObjectId = require('mongodb').ObjectID;
var MONGODBURL = 'mongodb://localhost:27017/ACF_Test';
var express = require('express');
var db;



module.exports = {
  findEntreprise: function(db,query,callback) {
		var cursor =db.collection('test').find({"Entreprise":""+query});
	    cursor.each(function(err, doc) {
		  assert.equal(err, null);
		  if (doc != null) {
			 console.dir(doc);
		  } else {
			 callback();
		  }
	   });
	}
};