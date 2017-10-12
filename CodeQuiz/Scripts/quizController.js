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
        vm.mainService = mainService;
        vm.quizList = {};

        function _init() {
            console.log("quiz controller initialized");
            _getQuizzes();
        }

        function _getQuizzes() {
            mainService.get("/api/quiz")
                .then(_getSuccess)
                .catch(_getFailed);

            function _getSuccess(res) {
                console.log("Get Success", res);
                vm.quizList = res.data.Items;
                console.log(vm.quizList);
            }

            function _getFailed(err) {
                console.log("Get Failed", err);
            }
        }
    }
})();