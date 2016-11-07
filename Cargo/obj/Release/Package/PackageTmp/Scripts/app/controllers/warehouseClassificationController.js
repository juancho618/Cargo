angular.module("cargoApp").controller('warehouseClassificationController', function ($scope, $http, $translate) {

    $scope.translate = function (lan) {
        $translate.use(lan);
    }

    $scope.warehouseClassificationObj = {};
    $scope.warehouseClassification = {};
    //Get all unit types
    $http({
        method: 'get',
        url: '/WarehouseType/GetAllWarehouseType',
    }).success(function (data) {
        $scope.warehouseClassification = data.data;
    }).error(function (e) {
        console.log(e);
    });

    $scope.openModalAddWarehouseClassification = function () {
        $('#addWarehouseClassification').modal('show');
    }

    $scope.addWarehouseClassification = function () {
        $http({
            method: 'post',
            url: '/WarehouseType/Create/',
            data: JSON.stringify({
                warehouseClassification: $scope.warehouseClassificationObj
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'RequestVerificationToken': $scope.token
            }
        }).success(function (e) {
            $scope.warehouseClassificationObj = {};
            $scope.warehouseClassification.push(e.data);
            $('#addWarehouseClassification').modal('hide');
            swal("Warehouse classification created", "The Warehouse classification is saved!", "success");
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {

            //console.log(XMLHttpRequest);
            //var error = errorHandling(textStatus);
            //showMessage('Error ' + textStatus, 'Hubo un error al traer la informacion. \n' + error, 'error');
        });
    }
});