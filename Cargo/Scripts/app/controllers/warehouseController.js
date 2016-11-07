angular.module("cargoApp").controller('warehouseController', [function ($scope, $http, $translate) {

    $scope.translate = function (lan) {
        $translate.use(lan);
    }
    function changeFormatDates(date) {
        var converted_date = new Date(parseInt(date.substr(6)));
        return converted_date.toLocaleDateString() + ' ' + converted_date.toLocaleTimeString();
    }

    $scope.OpenPdf = function () {
        
            var doc = new jsPDF();
            var source = $('#contenido').html();
            var specialElementHandlers = {
                '#editor': function (element, renderer) {
                    return true;
                }
            };
            doc.fromHTML(source, 0.5, 0.5, {
                'width': 75,
                'elementHandlers': specialElementHandlers
            });
            doc.output("dataurlnewwindow");        
    }

    $scope.warehouseObj = {};
    $scope.warehouse = {};
    //Get all unit types
    $http({
        method: 'get',
        url: '/WareHouse/GetAllWarehouses',
    }).success(function (data) {
        function changeFormatDates(date) {
            var converted_date = new Date(parseInt(date.substr(6)));
            return converted_date.toLocaleDateString() + ' ' + converted_date.toLocaleTimeString();
        }
        $scope.warehouse = data.data;
        for (var i = 0; i < $scope.warehouse.length; i++) {
            $scope.warehouse[i].CreationDate = changeFormatDates($scope.warehouse[i].CreationDate);
        }
    }).error(function (e) {
        console.log(e);
    });

    $scope.openModalAddWarehouse = function () {
        $('#addOrigin').appendTo('body').modal('show');
    }

    $scope.addWarehouse = function () {
        $http({
            method: 'post',
            url: '/WareHouse/Create/',
            data: JSON.stringify({
                origin: $scope.originObj
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'RequestVerificationToken': $scope.token
            }
        }).success(function (e) {
            $scope.warehouseObj = {};
            $scope.warehouse.push(e.data);
            $('#addWarehouse').modal('hide');
            swal("Origin created", "The Origin is saved!", "success");
        }).error(function (XMLHttpRequest, textStatus, errorThrown) {

            //console.log(XMLHttpRequest);
            //var error = errorHandling(textStatus);
            //showMessage('Error ' + textStatus, 'Hubo un error al traer la informacion. \n' + error, 'error');
        });
    }
}]);