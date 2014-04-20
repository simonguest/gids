var HomePage = new require('./../pages/home.js');

describe('Test math functions', function () {
    var homePage = new HomePage();

    beforeEach(function () {
        homePage.load();
    });

    it('should add two numbers correctly', function () {
        expect(homePage.performAddition(10,20)).toEqual('30');
    });
});