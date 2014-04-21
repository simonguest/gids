var app = angular.module('app', ['ui.bootstrap'])
        .run(function ($log, $filter) {
          $log.getInstance = function (context) {
            return {
              log: extendedLogging($log.log, context)
            };
          };

          function extendedLogging(f, context) {
            return function () {
                var modifiedArguments = [].slice.call(arguments);
                modifiedArguments[0] = [$filter('date')(new Date(), 'MMM d, y h:mm:ss.sss') + '::[' + context + ']> '] + modifiedArguments[0];
                f.apply(null, modifiedArguments);
            };
          }
        });