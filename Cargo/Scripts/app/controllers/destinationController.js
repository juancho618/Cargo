angular.module('cargoApp').controller('destinationController', function ($scope, $http, $translate) {
    $scope.translate = function (lan) {
        $translate.use(lan);
    }

    $scope.destinationObj = {};
    $scope.destination = {};
    //Get all unit types
    $http({
        method: 'get',
        url: '/Destination/GetAllDestinations',
    }).success(function (data) {
        $scope.destination = data.data;
    }).error(function (e) {
        console.log(e);
    });

    $scope.openModalAddDestination = function () {
        $('#addDestination').appendTo('body').modal('show');
    }

    $scope.addDestination = function () {
        $http({
            method: 'post',
            url: '/Destination/Create/',
            data: JSON.stringify({
                destination: $scope.destinationObj
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'RequestVerificationToken': $scope.token
            }
        }).success(function (e) {
            $scope.destinationObj = {};
            $scope.destination.push(e.data);
            $('#addDestination').modal('hide');
            swal("Destination created", "The Destination is saved!", "success");
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {

            //console.log(XMLHttpRequest);
            //var error = errorHandling(textStatus);
            //showMessage('Error ' + textStatus, 'Hubo un error al traer la informacion. \n' + error, 'error');
        });
    }
});
