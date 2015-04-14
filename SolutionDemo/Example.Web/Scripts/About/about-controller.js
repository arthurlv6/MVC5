'use strict';

indexModule.controller("InstructorsController", function ($scope, instructorRepository) {
    $scope.instructors = instructorRepository.get();
});
