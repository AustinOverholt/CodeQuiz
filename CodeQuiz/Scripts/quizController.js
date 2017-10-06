(function () {
    'use strict';
    angular
        .module("mainApp")
        .controller("quizController", quizController);

    quizController.$inject = ["$scope"]; // put service here when created

    function quizController($scope) {

        var vm = this;
        vm.$scope = $scope;
        vm.$onInit = _init;

        function _init() {
            console.log("quiz controller initialized");
        }
    }







})();