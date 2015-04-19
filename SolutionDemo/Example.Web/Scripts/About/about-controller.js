'use strict';

indexModule.controller("AboutController", function ($scope, aboutRepository) {
    $scope.instructors = aboutRepository.get();
});
