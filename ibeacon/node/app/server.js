'use strict';

var express = require('express'),
    http = require('http'),
    mongoose = require('mongoose'),
    path = require('path'),
    _ = require('underscore');

var app = express();
var server = http.createServer(app);
var io = require('socket.io').listen(server, {log: false});

var clientSocket = null;

var db = mongoose.createConnection('localhost', 'ibeacon-trilat');

var eventSchema = mongoose.Schema({dateTime: 'Date', deviceId: 'String', beaconsInSight: [
    {_id: false, id: 'String', range: 'Number'}
]});
var eventModel = db.model('Event', eventSchema);

app.configure(function () {
    app.set('port', process.env.PORT || 9000);
    app.use(express.logger('dev'));
    app.use(express.bodyParser());
    app.use('/', express.static(path.join(__dirname, '/client')));
});

app.configure('development', function () {
    app.use(express.errorHandler());
});

/* list events */
app.get('/api/events', function (req, res) {
    return eventModel.find({}, function (err, events) {
        if (!err) {
            res.send(events);
        }
        else {
            res.send({error: err});
        }
    })
});

function getTrilateration(beaconsInSight) {
    var b4 = _.where(beaconsInSight, {id: "Beacon 1.4"})[0];
    var b5 = _.where(beaconsInSight, {id: "Beacon 1.5"})[0];
    var b2 = _.where(beaconsInSight, {id: "Beacon 1.2"})[0];

    b5.x = 0.02;
    b5.y = 6.02;
    b4.x = 2.02;
    b4.y = 0.02;
    b2.x = 0.75;
    b2.y = 8.02;

    var xa = b4.x;
    var ya = b4.y;
    var xb = b5.x;
    var yb = b5.y;
    var xc = b2.x;
    var yc = b2.y;
    var ra = b4.range;
    var rb = b5.range;
    var rc = b2.range;

    var S = (Math.pow(xc, 2.) - Math.pow(xb, 2.) + Math.pow(yc, 2.) - Math.pow(yb, 2.) + Math.pow(rb, 2.) - Math.pow(rc, 2.)) / 2.0;
    var T = (Math.pow(xa, 2.) - Math.pow(xb, 2.) + Math.pow(ya, 2.) - Math.pow(yb, 2.) + Math.pow(rb, 2.) - Math.pow(ra, 2.)) / 2.0;
    var y = ((T * (xb - xc)) - (S * (xb - xa))) / (((ya - yb) * (xb - xc)) - ((yc - yb) * (xb - xa)));
    var x = ((y * (ya - yb)) - T) / (xb - xa);

    return {
        x: x,
        y: y
    };
}

/* register new event */
app.post('/api/events', function (req, res) {
    res.send({result: 'accepted'});

    var event = new eventModel();
    for (var field in eventSchema.paths) {
        if (eventSchema.paths.hasOwnProperty(field)) {
            if ((field !== '_id') && (field !== '__v')) {
                if (req.body[field] !== undefined) {
                    event[field] = req.body[field];
                }
            }
        }
    }

    event.dateTime = new Date();
    console.log(event);

    // fake beacons
    var coords = getTrilateration(event.beaconsInSight);

    console.log("You should be at " + coords.x + ',' + coords.y);
    clientSocket.emit('updated', {data: coords});


//
//    event.save(function (err) {
//        if (!err) {
//            console.log('Event saved');
//        }
//        else {
//            console.log(err);
//        }
//    });
});

app.get('/', function (req, res) {
    res.sendfile('index.html');
});

server.listen(app.get('port'), function () {
    console.log('Express server listening on port ' + app.get('port'));
});

io.set('transports', ['xhr-polling']);
io.sockets.on('connection', function (socket) {
    clientSocket = socket;
});