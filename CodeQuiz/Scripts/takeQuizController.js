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
        vm.answerSelected;
        vm.quizList = {};
        vm.quizChoose = _quizChoose;
        vm.submitAnswer = _submitAnswer;

        function _init() {
            // initialization here
            _quizChoose(); // get rid of this when basing quiz on category
        }

        // Get for category type
        function _quizChoose() {
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

        // submit button clicked on answer
        function _submitAnswer() {
            console.log("button clicked");
            console.log(vm.answerSelected);
        }
    }


})();