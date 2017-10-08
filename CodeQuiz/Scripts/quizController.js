(function () {
    'use strict';
    angular
        .module("mainApp")
        .controller("quizController", quizController);

    quizController.$inject = ["$scope", "mainService"]; 

    function quizController($scope, mainService) {

        var vm = this;
        vm.$scope = $scope;
        vm.$onInit = _init;

        function _init() {
            console.log("quiz controller initialized");
        }
    }
})();