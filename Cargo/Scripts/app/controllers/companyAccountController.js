angular.module('cargoApp').controller('companyAccountController', function ($scope, $http, $translate) {
    $scope.translate = function (lan) {
        $translate.use(lan);
    }

    $scope.companyAccountObj = {};
    $scope.companyAccount = {};
    $scope.notification = [];
    $scope.class = [];
    $scope.notificationList = {};
    $scope.classificationList = {};
    $scope.countriesList = {};

    //Get all Companies
    $http({
        method: 'get',
        url: '/CompanyAccount/GetAllCompanyAccounts',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    }).success(function (data) {
        $scope.companyAccount = data.data;
    }).error(function (e) {
        console.log(e);
    });

    $scope.openModalAddCompanyAccount = function () {
        //Get all countries
        $http({
            method: 'get',
            url: '/Country/GetAllCountries',
        }).success(function (data) {
            console.log(data.data);
            $scope.countriesList = data.data;
        }).error(function (e) {
            console.log(e);
        });

        //Get Classification check list
        $http({
            method: 'get',
            url: '/ClassificationAccount/GetAllClassification',
        }).success(function (data) {
            console.log(data.data);
            $scope.classificationList = data.data;
        }).error(function (e) {
            console.log(e);
        });

        //Get all notification
        $http({
            method: 'get',
            url: '/Notification/GetAllNotifications',
        }).success(function (data) {
            console.log(data.data);
            $scope.notificationList = data.data;
        }).error(function (e) {
            console.log(e);
        });
        $('#CreateAccountModal').appendTo("body").modal('show');
    }

    

    //Add classification
    $scope.toggleSelection = function (name) {

        var idx = $scope.class.indexOf(name);

        // is currently selected
        if (idx > -1) {
            $scope.class.splice(idx, 1);
        }

            // is newly selected
        else {
            $scope.class.push(name);
        }
    }

    //Add Notification
    $scope.toggleNotification = function (name) {

        var idx = $scope.notification.indexOf(name);

        // is currently selected
        if (idx > -1) {
            $scope.notification.splice(idx, 1);
        }

            // is newly selected
        else {
            $scope.notification.push(name);
        }
    }
        
    //Create an account
    $scope.addAccount = function () {
        $scope.token = $('[name="__RequestVerificationToken"]').val();
        $scope.account.fk_CountryID = $scope.account.fk_CountryID.CountryID; 
        $http({
            method: 'post',
            url: '/CompanyAccount/Create/',
            data: JSON.stringify({
                CompanyAccount: $scope.account,
                Classification: $scope.class,
                Notification: $scope.notification
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'RequestVerificationToken': $scope.token
            }
        }).success(function (e) {
            console.log($scope.account);
            $scope.classificationAccount = {};
            $scope.notificationAccount = {};
            $scope.account = {};
            $scope.companyAccount.push(e.data);
            $('#CreateAccountModal').modal('hide');
            swal("Account created", "Now you can select the account from the list!", "success");
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {
            //console.log(XMLHttpRequest);
            //var error = errorHandling(textStatus);
            //showMessage('Error ' + textStatus, 'Hubo un error al traer la informacion. \n' + error, 'error');
        });
    }
});
