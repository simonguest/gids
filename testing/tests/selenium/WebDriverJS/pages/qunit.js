module.exports = function () {

    var ptor;

    this.load = function () {
        ptor = protractor.getInstance();
        ptor.driver.get('http://localhost:8088/tests/qunit');
    };

    this.getFailingTests = function () {
        return ptor.driver.findElements(protractor.By.xpath("//li[@class='fail']"));
    };
}