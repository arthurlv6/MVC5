indexModule.factory('instructorRepository', function ($resource) {
    return {
        get: function() {
            return $resource('/api/Instructors').query();
        }
    };
});