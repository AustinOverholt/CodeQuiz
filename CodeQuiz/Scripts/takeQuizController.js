(function () {
    "use strict";
    angular 
        .module("mainApp")
        .controller("takeQuizController", takeQuizController)

    takeQuizController.$inject = ["$scope", "mainService", "toastr"];

    function takeQuizController($scope, mainService, toastr) {
        var vm = this;
        vm.$scope = $scope;
        vm.$onInit = _init;
        vm.quizType;
        vm.quizChoose = _quizChoose;

        function _init() {
            // initialization here
        }

        // Get for category type
        function _quizChoose() {
            toastr.success(vm.quizType);
            // Filter based on chosen category
        }
    }


})();