angular.module('cargoApp').controller('blogController', function ($scope, $http, $translate) {
    $scope.translate = function (lan) {
        $translate.use(lan);
    }
    
    $scope.post = {};
    $scope.postList = {};

    function changeFormatDates(date) {
        var converted_date = new Date(parseInt(date.substr(6)));
        return converted_date.toLocaleDateString() + ' ' + converted_date.toLocaleTimeString();
    }

    $http({
        method: 'get',
        url: '/EventBlog/GetAllPost',
    }).success(function (data) {        
        $scope.postList = data.data;
        for (var i = 0; i < $scope.postList.length; i++) {
            $scope.postList[i].date = changeFormatDates($scope.postList[i].date);
        }
    }).error(function (e) {
        console.log(e);
    });
    $scope.viewPost = function (id) {
        window.location.pathname = 'EventBlog/Post/' + id;
    }

    $scope.addPost = function () {
        $http({
            method: 'post',
            url: '/EventBlog/CreatePost',
            data: JSON.stringify({
                postEntry: $scope.post
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        }).success(function (e) {
            $scope.postList.push(e.data);
            for (var i = 0; i < $scope.postList.length; i++) {
                $scope.postList[i].date = changeFormatDates($scope.postList[i].date);
            }
        }).error(function (e) {
            console.log(e);
        });

    }

    $scope.createBlog= function(){
        $('#createBlogModal').appendTo('body').modal('show');
    }
});
