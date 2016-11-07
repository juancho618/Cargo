angular.module('cargoApp').controller('layoutController', function ($scope, $http, $translate) {
    $scope.translate = function (lan) {
        $translate.use(lan);
    }
});
