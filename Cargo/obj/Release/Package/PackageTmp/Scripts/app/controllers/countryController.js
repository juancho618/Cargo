angular.module('cargoApp').controller('countryController', function ($scope, $http, $translate) {
    $scope.translate = function (lan) {
        $translate.use(lan);
    }

    $scope.countryObj = {};
    $scope.country = {};
    //Get all unit types
    $http({
        method: 'get',
        url: '/Country/GetAllCountries',
    }).success(function (data) {
        $scope.country = data.data;
    }).error(function (e) {
        console.log(e);
    });

    $scope.openModalAddCountry = function () {
        $('#addCountry').modal('show');
    }

    $scope.addCountry = function () {
        $http({
            method: 'post',
            url: '/Country/Create/',
            data: JSON.stringify({
                country: $scope.countryObj
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'RequestVerificationToken': $scope.token
            }
        }).success(function (e) {
            $scope.countryObj = {};
            $scope.country.push(e.data);
            $('#addCountry').modal('hide');
            swal("Country created", "The Country is saved!", "success");
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {

            //console.log(XMLHttpRequest);
            //var error = errorHandling(textStatus);
            //showMessage('Error ' + textStatus, 'Hubo un error al traer la informacion. \n' + error, 'error');
        });
    }
});
