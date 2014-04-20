var express = require('express')
    , http = require('http')
    , path = require('path');

var app = express();

app.configure(function () {
    app.set('port', process.env.PORT || 8088);
    app.use(express.favicon());
    app.use(express.logger('dev'));
    app.use(express.bodyParser());
});

app.configure('development', function () {
    app.use(express.errorHandler());
    app.use('/bower_components', express.static(path.join(__dirname, '/bower_components')));
    app.use('/', express.static(path.join(__dirname, '/client')));
    app.use('/tests', express.static(path.join(__dirname, '/tests')));

});

app.get('/', function (req, res) {
    res.sendfile('/index.html');
});

http.createServer(app).listen(app.get('port'), function () {
    console.log("Express server listening on port " + app.get('port'));
});
