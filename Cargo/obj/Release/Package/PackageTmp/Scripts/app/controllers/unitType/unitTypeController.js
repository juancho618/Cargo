angular.module('cargoApp').controller('unitTypeController', function ($scope, $http, $translate) {
    $scope.translate = function (lan) {
        $translate.use(lan);
    }

    $scope.unitTypeObj = {};
    $scope.unitType = {};
    //Get all unit types
    $http({
        method: 'get',
        url: '/UnitType/GetAllUnitType',
    }).success(function (data) {
        console.log(data.data);
        $scope.unitType = data.data;
    }).error(function (e) {
        console.log(e);
    });

    $scope.openModalAddUnit = function () {
        $('#addUnitTypeModal').modal('show');
    }

    $scope.addUnitType = function () {
        $http({
            method: 'post',
            url: '/UnitType/Create/',
            data: JSON.stringify({
                unitType: $scope.unitTypeObj
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'RequestVerificationToken': $scope.token
            }
        }).success(function (e) {
            $scope.unitTypeObj = {};
            $scope.unitType.push(e.data);
            $('#addUnitTypeModal').modal('hide');
            swal("Unit type created", "The Unit type is saved!", "success");
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {

            //console.log(XMLHttpRequest);
            //var error = errorHandling(textStatus);
            //showMessage('Error ' + textStatus, 'Hubo un error al traer la informacion. \n' + error, 'error');
        });
    }
});
