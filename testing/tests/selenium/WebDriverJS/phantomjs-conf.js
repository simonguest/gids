exports.config = {
    // The address of a running selenium server.
    seleniumAddress: 'http://localhost:4444/wd/hub',

    // PhantomJS capabilities
    capabilities: {
        'browserName': 'phantomjs',
        'phantomjs.binary.path' : '/Users/simon/Dev/engineering-excellence/1-web-testing-with-javascript/node_modules/phantomjs/bin/phantomjs'
    },

    // Spec patterns are relative to the location of the spec file. They may
    // include glob patterns.
    specs: ['specs/*.js'],

    // Options to be passed to Jasmine-node.
    jasmineNodeOpts: {
        isVerbose:true,
        showColors: true,
        defaultTimeoutInterval: 60000
    }
};