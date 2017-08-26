const _ = require('lodash');
const express = require('express');
const bodyParser = require('body-parser');
const compression = require('compression');
const app = express();

app.set('port', (process.env.PORT || 8081));
app.use(compression());
app.use(bodyParser.json()); // for parsing application/json
app.use(express.static(__dirname + '/public'));

// Add headers
app.use(function (req, res, next) {

    // Website you wish to allow to connect
    res.setHeader('Access-Control-Allow-Origin', 'http://localhost:8080');

    // Request methods you wish to allow
    res.setHeader('Access-Control-Allow-Methods', 'GET, POST, OPTIONS, PUT, PATCH, DELETE');

    // Request headers you wish to allow
    res.setHeader('Access-Control-Allow-Headers', 'X-Requested-With,content-type');

    // Set to true if you need the website to include cookies in the requests sent
    // to the API (e.g. in case you use sessions)
    res.setHeader('Access-Control-Allow-Credentials', true);

    // Pass to next layer of middleware
    next();
});

var heroes = [
  {id: 11, name: 'Mr. Nice'},
  {id: 12, name: 'Narco'},
  {id: 13, name: 'Bombasto'},
  {id: 14, name: 'Celeritas'},
  {id: 15, name: 'Magneta'},
  {id: 16, name: 'RubberMan'},
  {id: 17, name: 'Dynama'},
  {id: 18, name: 'Dr IQ'},
  {id: 19, name: 'Magma'},
  {id: 20, name: 'Tornado'},
];

app.get('/v1/heroes', function(req, res) {
  console.log('Coming');
  var name = req.query.name;
  if (name) {
    name = name.toLowerCase();
    var results = _.filter(heroes, function(hero) {
      return _.includes(hero.name.toLowerCase(), name);
    });
    res.json(results);
  } else {
    res.json(heroes);
  }
});

app.post('/v1/heroes', function(req, res) {
  var hero = req.body;
  if (typeof hero.name === "string") {
    var newId = 1;
    _.forEach(heroes, function(result) {
      newId = Math.max(newId, result.id);
    });
    res.json({ id: newId, name: hero.name });
  } else {
    res.sendStatus(400);
  }
});

app.put('/v1/heroes/:id', function(req, res) {
  const heroId = +req.params.id;
  var hero = _.find(heroes, function(hero) { return hero.id === heroId; });
  if (hero) {
    hero.name = req.body.name;
    res.json(heroes);
  } else {
    res.sendStatus(404);
  }
});

app.delete('/v1/heroes/:id', function(req, res) {
  const heroId = +req.params.id;
  var hero = _.find(heroes, function(hero) { return hero.id === heroId; });
  if (hero) {
    for(var i = 0; i < heroes.length; i++) {
      var hero = heroes[i];
      if (hero.id === heroId) {
        heroes.splice(i, 1);
        break;
      }
    }
    res.json(heroes);
  } else {
    res.sendStatus(404);
  }
});

app.get('*', function(req, res) {
  res.sendFile(__dirname + '/src/views/index.html');
});

app.listen(app.get('port'), function() {
  console.log('Node app is running on port', app.get('port'));
});