cargoApp.factory('responseHandlerService', ['$q', '$log', 'trafficCop', function ($q, $log, trafficCop) {
    return ({
        handleSuccess: success,
        handleError: error
    });

    function success(response) {
        if (!response.config.skip_track) {
            trafficCop.pop();
        }

        return response.data;
    }

    function error(response) {
        $log.debug(response);

        if (!response.config.skip_track) {
            trafficCop.pop();
        }

        if (
            !angular.isObject(response.data) ||
            !response.data.message
            ) {
            return ($q.reject("An unknown error occurred."));
        }

        return ($q.reject(response.data.message));
    }
}
]);

cargoApp.factory('server', ['$http', 'responseHandlerService', 'trafficCop', function ($http, responseHandlerService, trafficCop) {
    return {
        post: function (url, args, skipTracking) {

            var config = getConfig();

            if (skipTracking) {
                config.skip_track = true;
            } else {
                trafficCop.push();
            }

            return $http.post(url, args, config).then(responseHandlerService.handleSuccess, responseHandlerService.handleError);
        },
        get: function (url, args, skipTracking) {

            var config = getConfig();

            if (skipTracking) {
                config.skip_track = true;
            } else {
                trafficCop.push();
            }

            config.params = args;

            return $http.get(url, config).then(responseHandlerService.handleSuccess, responseHandlerService.handleError);
        }
    };

    function getConfig() {
        return {
            headers: {
                '__RequestVerificationToken': angular.element("input[name='__RequestVerificationToken']").val()
            },
            skip_track: false
        };
    };

}]);

cargoApp.service('trafficCop', function () {
    var pending = 0;

    return {
        pending: function () { return pending; },
        push: push,
        pop: pop
    }

    function push() {
        pending++;
    }

    function pop() {
        pending--;
    }

});