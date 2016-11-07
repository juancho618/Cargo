angular.module('cargoApp').controller('notificationController', function ($scope, $http, $translate) {
    $scope.translate = function (lan) {
        $translate.use(lan);
    }

    $scope.notificationObj = {};
    $scope.notification = {};
    //Get all unit types
    $http({
        method: 'get',
        url: '/Notification/GetAllNotifications',
    }).success(function (data) {
        $scope.notification = data.data;
    }).error(function (e) {
        console.log(e);
    });

    $scope.openModalAddNotification = function () {
        $('#addNotification').appendTo('body').modal('show');
    }

    $scope.addNotification = function () {
        $http({
            method: 'post',
            url: '/Notification/Create/',
            data: JSON.stringify({
                notification: $scope.notificationObj
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'RequestVerificationToken': $scope.token
            }
        }).success(function (e) {
            $scope.notificationhObj = {};
            $scope.notification.push(e.data);
            $('#addNotification').modal('hide');
            swal("Notification created", "The Notification is saved!", "success");
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {

            //console.log(XMLHttpRequest);
            //var error = errorHandling(textStatus);
            //showMessage('Error ' + textStatus, 'Hubo un error al traer la informacion. \n' + error, 'error');
        });
    }
});
