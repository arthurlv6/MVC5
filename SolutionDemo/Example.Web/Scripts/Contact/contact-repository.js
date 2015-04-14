'use strict';

indexModule.factory('accountRepository', function ($resource) {
    return {
        save: function (student) {
            return $resource('/api/Account').save(student);
        }
    };
});