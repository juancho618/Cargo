angular.module('cargoApp').controller('classificationController', function ($scope, $http, $translate) {
    $scope.translate = function (lan) {
        $translate.use(lan);
    }

    $scope.classificationObj = {};
    $scope.classification = {};
    //Get all unit types
    $http({
        method: 'get',
        url: '/ClassificationAccount/GetAllClassification',
    }).success(function (data) {
        $scope.classification = data.data;
    }).error(function (e) {
        console.log(e);
    });

    $scope.openModalAddClassification = function () {
        $('#addClassification').appendTo('body').modal('show');
    }

    $scope.addClassification = function () {
        $http({
            method: 'post',
            url: '/ClassificationAccount/Create/',
            data: JSON.stringify({
                classification: $scope.classificationObj
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'RequestVerificationToken': $scope.token
            }
        }).success(function (e) {
            $scope.classificationObj = {};
            $scope.classification.push(e.data);
            $('#addClassification').modal('hide');
            swal("Classification created", "The Classification is saved!", "success");
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {

            //console.log(XMLHttpRequest);
            //var error = errorHandling(textStatus);
            //showMessage('Error ' + textStatus, 'Hubo un error al traer la informacion. \n' + error, 'error');
        });
    }
});
