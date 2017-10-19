(function () {
    'use strict';
    angular
        .module('mainApp')
        .directive('quizCardDirective', quizCardDirective);

    function quizCardDirective() {
        return {
            template: "<h1>Hello World</h1>"
        }
    }


})();