exports.config = {
    // The address of a running selenium server.
    seleniumAddress: 'http://localhost:4444/wd/hub',

    // Chrome capabilities
    capabilities: {
        'browserName':'chrome'
    },

    // Spec patterns are relative to the location of the spec file. They may
    // include glob patterns.
    specs: ['specs/addnumbers.js'],

    // Options to be passed to Jasmine-node.
    jasmineNodeOpts: {
        isVerbose:true,
        showColors: true,
        defaultTimeoutInterval: 60000
    }
};