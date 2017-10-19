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
        vm.quizList = {};
        vm.quizChoose = _quizChoose;

        function _init() {
            // initialization here
            _quizChoose(); // get rid of this when basing quiz on category
        }

        // Get for category type
        function _quizChoose() {
            toastr.success(vm.quizType);
            // Filter based on chosen category
            mainService.get("/api/quiz/") // Get quiz based on category for now just getting all quizzes
                .then(_getQuizSuccess)
                .catch(_getQuizFailed)

            function _getQuizSuccess(res) {
                vm.quizList = res.data.Items;
                console.log(vm.quizList);
            }

            function _getQuizFailed(err) {
                toastr.error("Get Failed");
            }
        }
    }


})();