angular.module('cargoApp').controller('conditionController', function ($scope, $http, $translate) {
    $scope.translate = function (lan) {
        $translate.use(lan);
    }

    $scope.conditionObj = {};
    $scope.condition = {};
    //Get all unit types
    $http({
        method: 'get',
        url: '/Condition/GetAllConditions',
    }).success(function (data) {
        $scope.condition = data.data;
    }).error(function (e) {
        console.log(e);
    });

    $scope.openModalAddCondition = function () {
        $('#addCondition').appendTo('body').modal('show');
    }

    $scope.addCondition = function () {
        $http({
            method: 'post',
            url: '/Condition/Create/',
            data: JSON.stringify({
                condition: $scope.conditionObj
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'RequestVerificationToken': $scope.token
            }
        }).success(function (e) {
            $scope.conditionObj = {};
            $scope.condition.push(e.data);
            $('#addCondition').modal('hide');
            swal("Condition created", "The Condition is saved!", "success");
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {

            //console.log(XMLHttpRequest);
            //var error = errorHandling(textStatus);
            //showMessage('Error ' + textStatus, 'Hubo un error al traer la informacion. \n' + error, 'error');
        });
    }
});
