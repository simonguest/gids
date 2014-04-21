'use strict';

var express = require('express'),
    path = require('path');
var app = express();

app.use('/', express.static(path.join(__dirname, '/client')));
app.use('/bower_components', express.static(path.join(__dirname, '../bower_components')));

app.get('/', function (req, res) {
    res.sendfile('index.html');
});

var server = app.listen(9000, function() {
    console.log('Listening on port %d', server.address().port);
});