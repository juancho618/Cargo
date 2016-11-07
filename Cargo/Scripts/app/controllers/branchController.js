angular.module('cargoApp').controller('branchController', function ($scope, $http, $translate) {
    $scope.translate = function (lan) {
        $translate.use(lan);
    }

    $scope.branchObj = {};
    $scope.branch = {};
    //Get all unit types
    $http({
        method: 'get',
        url: '/Branch/GetAllBranches',
    }).success(function (data) {
        $scope.branch = data.data;
    }).error(function (e) {
        console.log(e);
    });

    $scope.openModalAddBranch = function () {
        $('#addBranch').appendTo('body').modal('show');
    }

    $scope.addBranch = function () {
        $http({
            method: 'post',
            url: '/Branch/Create/',
            data: JSON.stringify({
                branch: $scope.branchObj
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'RequestVerificationToken': $scope.token
            }
        }).success(function (e) {
            $scope.branchObj = {};
            $scope.branch.push(e.data);
            $('#addBranch').modal('hide');
            swal("Branch created", "The Branch is saved!", "success");
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {

            //console.log(XMLHttpRequest);
            //var error = errorHandling(textStatus);
            //showMessage('Error ' + textStatus, 'Hubo un error al traer la informacion. \n' + error, 'error');
        });
    }
});
