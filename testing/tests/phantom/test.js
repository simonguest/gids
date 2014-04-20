var page = require('webpage').create(),
    system = require('system');

page.open('http://localhost:8088', function (status) {
    page.includeJs("http://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js", function () {
        console.log(status);
        if (status === 'success') {
            var elementOffset = page.evaluate(function () {
                $('#primary').val('20');
                $('#secondary').val('60');
                var element = document.querySelector('#addButton');
                var event = document.createEvent('MouseEvents');
                event.initMouseEvent('click', true, true, window, 1, 0, 0);
                element.dispatchEvent(event);
            });
            page.render('../tests/phantom/screenshot.png');
            phantom.exit();
        }
    });
});

