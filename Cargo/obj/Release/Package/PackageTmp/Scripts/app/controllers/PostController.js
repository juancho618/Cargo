angular.module("cargoApp").controller('postController', function ($scope, $http, $translate, Upload, $timeout) {
    
    var connectionHubProxy = $.connection.postHub;
    
   

    $scope.translate = function (lan) {
        $translate.use(lan);
    }
    //obtener parametro 
    var url = window.location.pathname;
    var id = url.substring(url.lastIndexOf('/') + 1);

    $scope.id = id;
    $scope.post = {};
    $scope.message = {};
    $scope.postList = {};
    $scope.file;

    function changeFormatDates(date) {
        var converted_date = new Date(parseInt(date.substr(6)));
        return converted_date.toLocaleDateString() + ' ' + converted_date.toLocaleTimeString();
    }

    function htmlEncode(value) {
        console.log(value);
        var encodedValue = $('#message').text(value).html();
        return encodedValue;
    }

    $scope.addMessage = function () {
        var obj = {};
        var file = $scope.file;

        if (file != null) {
            var url = file.$ngfName;
        }

        $http({
            method: 'post',
            url: '/EventBlog/PostMessage',
            data: JSON.stringify({
                comment: $scope.message,
                url: url,
                id: id
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        }).success(function (e) {
            obj = e.data;

            console.log(file);

            if (file != null || file != undefined ) {
                Upload.upload({
                    url: '/EventBlog/PostFile',
                    data: { file: file, id: id, idComment: e.postId }
                }).then(function (resp) {
                    //$scope.postList.push(resp.data.data);
                    obj = resp.data.data;
                    console.log(obj);
                    $scope.message = {};
                }, function (resp) {
                    console.log('Error status: ' + resp.status);
                }, function (evt) {
                    var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                    console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
                });
            }

            /*Signal R */            
            connectionHubProxy.client.postMessage = function (message) {
                console.log(message.message);
                console.log(message);
                if (message.message != null && message.message != undefined) {
                    $scope.postList.push(message);
                    $('#notificationsSound').html('<audio src="/Content/Sounds/notification.mp3" autoplay="autoplay"></audio>');

                    //$timeout(function () {
                    //    $('#deleteMe').remove();
                    //}, 1000);

                    $scope.message = {};
                    $scope.$apply();
                }
            };
            $.connection.hub.start().done(function () {
                    connectionHubProxy.server.addMessage(obj);
            });
            
        }).error(function (e) {
            console.log(e);
        });     

    }
    $scope.addMessage();
    $http({
        method: 'post',
        url: '/EventBlog/GetPost',
        data: JSON.stringify({
            id: id
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    }).success(function (e) {
        $scope.post = e.data;
        $scope.postList = e.list;
        for (var i = 0; i < $scope.postList.length; i++) {
            $scope.postList[i].date = changeFormatDates($scope.postList[i].date);
        }
    }).error(function (e) {
        console.log(e);
    });

    

    $("[data-toggle=tooltip]").tooltip();
});