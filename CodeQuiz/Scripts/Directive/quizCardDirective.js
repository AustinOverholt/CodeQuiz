(function () {
    'use strict';
    angular
        .module('mainApp')
        .directive('quizCardDirective', quizCardDirective);

    function quizCardDirective() {
        return {
            templateUrl: "/Scripts/Directive/quizCard.html"
        }
    }

})();