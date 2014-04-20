var QUnitPage = new require('./../pages/qunit.js');

describe('Run QUnit tests', function () {
    var qunitPage = new QUnitPage();

    beforeEach(function () {
        qunitPage.load();
    });

    it('should not fail any tests', function () {
        qunitPage.getFailingTests().then(function(failedTests){
            expect(failedTests.length).toEqual(0);
        });
    });
});