angular.module("cargoApp").controller('originController', function ($scope, $http, $translate) {

    $scope.translate = function (lan) {
        $translate.use(lan);
    }

    $scope.originObj = {};
    $scope.origin = {};
    //Get all unit types
    $http({
        method: 'get',
        url: '/Origin/GetAllOrigins',
    }).success(function (data) {
        $scope.origin = data.data;
    }).error(function (e) {
        console.log(e);
    });

    $scope.openModalAddOrigin = function () {
        $('#addOrigin').appendTo('body').modal('show');
    }

    $scope.addOrigin = function () {
        $http({
            method: 'post',
            url: '/Origin/Create/',
            data: JSON.stringify({
                origin: $scope.originObj
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'RequestVerificationToken': $scope.token
            }
        }).success(function (e) {
            $scope.originObj = {};
            $scope.origin.push(e.data);
            $('#addOrigin').modal('hide');
            swal("Origin created", "The Origin is saved!", "success");
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {

            //console.log(XMLHttpRequest);
            //var error = errorHandling(textStatus);
            //showMessage('Error ' + textStatus, 'Hubo un error al traer la informacion. \n' + error, 'error');
        });
    }
});