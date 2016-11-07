angular.module('cargoApp').controller('deliveryController', function ($scope, $http, $translate) {
    $scope.translate = function (lan) {
        $translate.use(lan);
    }

    $scope.deliveryObj = {};
    $scope.delivery = {};
    //Get all unit types
    $http({
        method: 'get',
        url: '/DeliveryCompany/GetAllDeliveryCompany',
    }).success(function (data) {
        $scope.delivery = data.data;
    }).error(function (e) {
        console.log(e);
    });

    $scope.openModalAddDelivery = function () {
        $('#addDeliveryCompany').appendTo('body').modal('show');
    }

    $scope.addDeliveryCompany = function () {
        $http({
            method: 'post',
            url: '/DeliveryCompany/Create/',
            data: JSON.stringify({
                deliveryCompany: $scope.deliveryObj
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'RequestVerificationToken': $scope.token
            }
        }).success(function (e) {
            $scope.deliveryObj = {};
            $scope.delivery.push(e.data);
            $('#addDeliveryCompany').modal('hide');
            swal("Delivery created", "The Delivery Company is saved!", "success");
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {

            //console.log(XMLHttpRequest);
            //var error = errorHandling(textStatus);
            //showMessage('Error ' + textStatus, 'Hubo un error al traer la informacion. \n' + error, 'error');
        });
    }
});
