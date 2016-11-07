angular.module('cargoApp').controller('courierController', function ($scope, $http, $translate) {
    $scope.translate = function (lan) {
        $translate.use(lan);
    }
    $scope.loaded = true;
    $scope.editBtnModal = false;
    $scope.addBtnModal = true;
    $scope.deliveryCompanies = {};
    $scope.unitType = {};
    $scope.courierList = [];
    $scope.companyList = {};
    $scope.courier = {};
    $scope.account = {};
    $scope.warehouseTypes = {};
    $scope.keyword = "";
    $scope.searchInput=""
    $scope.warehouse = {};
    $scope.origin = {};
    $scope.destination = {};
    $scope.condition = {};
    $scope.branch = {};
    $scope.classificationList = {};
    $scope.classificationAccount = {};
    $scope.notificationAccount = {};
    $scope.class = [];
    $scope.types = [];
    $scope.notification = [];
    $scope.countriesList = {};
    $scope.notificationList = {};
    $scope.indexEdit = -1;

    $http({
        method: 'get',
        url: '/DeliveryCompany/GetAllDeliveryCompany',
    }).success(function (data) {
        console.log(data.data);
        $scope.deliveryCompanies = data.data;
    }).error(function (e) {
        console.log(e);
    });

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

    //Get all origin
    $http({
        method: 'get',
        url: '/Origin/GetAllOrigins',
    }).success(function (data) {
        $scope.origin = data.data;
    }).error(function (e) {
        console.log(e);
    });

    //Get all destination
    $http({
        method: 'get',
        url: '/Destination/GetAllDestinations',
    }).success(function (data) {
        console.log(data.data);
        $scope.destination = data.data;
    }).error(function (e) {
        console.log(e);
    });

    //Get all WharehouseTypes
    $http({
        method: 'get',
        url: '/WarehouseType/GetAllWarehouseType',
    }).success(function (data) {
        $scope.warehouseTypes = data.data;
    }).error(function (e) {
        console.log(e);
    });


    //Get all conditions
    $http({
        method: 'get',
        url: '/Condition/GetAllConditions',
    }).success(function (data) {
        console.log(data.data);
        $scope.condition = data.data;
    }).error(function (e) {
        console.log(e);
    });

    //Get all branches
    $http({
        method: 'get',
        url: '/Branch/GetAllBranches',
    }).success(function (data) {
        console.log(data.data);
        $scope.branch = data.data;
    }).error(function (e) {
        console.log(e);
    });

    //Add type
    $scope.toggleType = function (name) {
        var idx = $scope.types.indexOf(name);

        // is currently selected
        if (idx > -1) {
            $scope.types.splice(idx, 1);
        }

            // is newly selected
        else {
            $scope.types.push(name);
        }
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
    
    //Search list of companies by keyword
    $scope.searchKeyword = function search() {
        //Add later how to divide the search of the accounts depending on the classification
        $http({
            method: 'post',
            url: '/CompanyAccount/GetAllAccounts',
            data: JSON.stringify({
                searchString: $scope.keyword
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        }).success(function (data) {
            $scope.companyList = data.data;
            $scope.keyword = "";
            $('#searchModal').modal('hide');
            $('#searcResultModal').appendTo('body').modal('show');
        }).error(function (e) {
            console.log(e);
        });
    }

    //SetShipperCompany
    $scope.selectCompany = function (index) {
        switch ($scope.searchInput) {
            case 'Shipper':
                $scope.warehouse.Fk_ShipperID = $scope.companyList[index].CompanyName;
                $scope.warehouse.ShipperId = $scope.companyList[index].CompanyAccountID;
                break;
            case 'Consignee':
                $scope.warehouse.Fk_Consignee = $scope.companyList[index].CompanyName;
                $scope.warehouse.ConsigneeId = $scope.companyList[index].CompanyAccountID;
                break;
            case 'Agent':
                $scope.warehouse.Fk_Agent = $scope.companyList[index].CompanyName;
                $scope.warehouse.AgentId = $scope.companyList[index].CompanyAccountID;
                break;
        }
        
        $scope.companyList = {};
        $('#searcResultModal').modal('hide');
    }
    
    function openCourierModalSimple() {
        $scope.warehouse.CreationDate = new Date();
        $('#ModalCourierSimple').appendTo('body').modal('show');
    }
    function openCourierModal() {
        $scope.warehouse.CreationDate = new Date();
        $('#ModalCourier').appendTo('body').modal('show');
    }
    $scope.init = function (codeNumber) {
        $scope.warehouse.NumberCode = codeNumber;
        console.log(codeNumber);
    }

    angular.element(document).ready(openCourierModalSimple());
    $scope.openModalCourier = function () {
        $scope.addBtnModal = true;
        $scope.editBtnModal = false;
        $scope.courier = {};
        $('#ModalCourier').appendTo('body').modal('show');
    }
    $scope.openModalCourierSimple = function () {
        $scope.addBtnModal = true;
        $scope.editBtnModal = false;
        $scope.courier = {};
        $('#ModalCourierSimple').appendTo('body').modal('show');
    }
    //Add Courier
    $scope.addCourier = function () {
        if (!isValid($scope.courier.length) && !isValid($scope.courier.width) && !isValid($scope.courier.height) && !isValid($scope.courier.weight)) {
            //Validate tracking number
            $http({
                method: 'post',
                url: '/Courier/checkTrackingNumber',
                data: JSON.stringify({
                    number: $scope.courier.trackingNumber
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
            }).success(function (data) {
                if (data.result == false) {
                    if ($scope.courier.pieces != null && $scope.courier.pieces > 0) {
                        for (var i = 0; i < $scope.courier.pieces; i++) {
                            $scope.newcourier = { Fk_UnitType: $scope.courier.Fk_UnitType, length: $scope.courier.length, width: $scope.courier.width, height: $scope.courier.height, weight: $scope.courier.weight, Units: $scope.courier.Units, trackingNumber: $scope.courier.trackingNumber, Fk_DeliveryCompany: $scope.courier.Fk_DeliveryCompany };
                            console.log($scope.newcourier);
                            $scope.courierList.push($scope.newcourier);
                        }
                    }
                    else {
                        $scope.courierList.push($scope.courier);
                    }
                    $scope.courier = {};
                }
                else {
                    swal("Tracking number alredy exist", "Check your tracking number and try again", "error");
                }
            }).error(function (e) {
                
            });            
        }
    }

    //Delete a courier
    $scope.removeItem = function (index) {
        $scope.courierList.splice(index, 1);
    }

    //Edit Courier
    $scope.editCourier = function (index) {
        $('#ModalCourier').appendTo('body').modal('show');
        $scope.editBtnModal = true;
        $scope.addBtnModal = false;
        $scope.courier = $scope.courierList[index];
        $scope.indexEdit = index;
    }

    $scope.edit = function () {
        $scope.courierList[$scope.indexEdit] = $scope.courier;
    }
    $scope.clearBtn = function () {
        $scope.courier = {};
        $scope.editBtnModal = false;
        $scope.addBtnModal = true;
    }
    
    //calendar
    this.isOpen = false;

    $scope.openCalendar = function (e) {
        e.preventDefault();
        e.stopPropagation();
        this.isOpen = true;
    };
    //Create a warehouse
    $scope.addWarehouse = function () {
        $scope.token = $('[name="__RequestVerificationToken"]').val();
        $scope.warehouse.Fk_ShipperID = $scope.warehouse.ShipperId;
        $scope.warehouse.Fk_Consignee = $scope.warehouse.ConsigneeId;
        $scope.warehouse.Fk_Agent = $scope.warehouse.AgentId;
        $scope.warehouse.Fk_BranchID = $scope.warehouse.Fk_BranchID.BranchID;
        $scope.warehouse.Fk_Origin = $scope.warehouse.Fk_Origin.OriginId;
        $scope.warehouse.Fk_Destination = $scope.warehouse.Fk_Destination.DestinationId;
        $scope.warehouse.Fk_Condition = $scope.warehouse.Fk_Condition.ConditionID;
        for (var i = 0; i < $scope.courierList.length; i++) {
            if ($scope.courierList[i].Fk_UnitType!=null && $scope.courierList[i].Fk_UnitType!=undefined){
                $scope.courierList[i].Fk_UnitType = $scope.courierList[i].Fk_UnitType.Id;
            }
            $scope.courierList[i].Fk_DeliveryCompany = $scope.courierList[i].Fk_DeliveryCompany.Id;
        }
        $http({
            method: 'post',
            url: '/WareHouse/Create/',
            data: JSON.stringify({
                wareHouse: $scope.warehouse,
                courier: $scope.courierList,
                types: $scope.types
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'RequestVerificationToken': $scope.token
            }
        }).success(function (e) {
            $scope.warehouse = {};
            $scope.courier = {};
            $scope.courierList = {};
            swal("Warehouse created", "The warehouse and the related information is saved!", "success");
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {
            
            //console.log(XMLHttpRequest);
            //var error = errorHandling(textStatus);
            //showMessage('Error ' + textStatus, 'Hubo un error al traer la informacion. \n' + error, 'error');
        });
    }
    //Create an account
    $scope.addAccount = function () {
        $scope.token = $('[name="__RequestVerificationToken"]').val();
        $scope.account.fk_CountryID = $scope.account.fk_CountryID.CountryID; //Intenta de nuevo con esa
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
            $('#CreateAccountModal').modal('hide');
            swal("Account created", "Now you can select the account from the list!", "success");
            //for (var i = 0; i < $scope.classificationAccount.length; i++) {
            //    console.log('hi');
            //    var nameClassification = $scope.classificationList[i];
            //    classificationAccount
            //    console.log(nameClassification.Classification);
            //    $scope.account[nameClassification.Classification].Selected = false;
            //}
            //$scope.productList.push(e.data);
            //$scope.product = {};
            //showMessage('Data saved', e.message, 'success');
            //$('#createProductModal').modal('hide');
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {
            //console.log(XMLHttpRequest);
            //var error = errorHandling(textStatus);
            //showMessage('Error ' + textStatus, 'Hubo un error al traer la informacion. \n' + error, 'error');
        });
    }
    
    

    //Open Modals
    $scope.openModal = function (modal) {
        var modal_name = '';
        switch (modal) {
            case 'Shipper':
                $scope.searchInput = "Shipper";
                modal_name = 'searchModal';
                break;
            case 'Consignee':
                $scope.searchInput = "Consignee";
                modal_name = 'searchModal';
                break;
            case 'Agent':
                $scope.searchInput = "Agent";
                modal_name = 'searchModal';
                break;
            case 'createAccount':
                modal_name = 'CreateAccountModal';
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
                break;
        }
        dal
        $('#' + modal_name).modal('show');
        $('#' + modal_name).on('shown.bs.modal', function () {
            $(this).css("z-index", parseInt($('.modal-backdrop').css('z-index')) + 1);
        });
    }

    function isValid(value) {
        return (value == "" || value == null);
    }
});
