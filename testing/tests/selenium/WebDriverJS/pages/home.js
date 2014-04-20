module.exports = function () {

    var ptor;

    this.load = function () {
        ptor = protractor.getInstance();
        ptor.get('http://localhost:8088/');
    };

    this.performAddition = function (x, y) {
        ptor.findElement(protractor.By.id('primary')).sendKeys(x);
        ptor.findElement(protractor.By.id('secondary')).sendKeys(y);
        ptor.findElement(protractor.By.id('addButton')).click();
        return ptor.findElement(protractor.By.id('resultTextBox')).getAttribute('value');
    };
}