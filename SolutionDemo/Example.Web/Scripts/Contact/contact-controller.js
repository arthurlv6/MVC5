'use strict';

indexModule.controller("ContactController", function ($scope, contactRepository, $location) {
    $scope.save = function (student) {
        $scope.errors = [];
        contactRepository.save(student).$promise.then(
            function() { $location.url('Index/Home'); },
            function(response) { $scope.errors = response.data; });
    };
});