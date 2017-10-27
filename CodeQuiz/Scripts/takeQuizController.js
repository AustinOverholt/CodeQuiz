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
        vm.answerSelected; // stores answer that user selected
        vm.questionSelected; // stores question that user wants  
        vm.quizList = {};
        vm.answerScore = {
            Correct: "",
            Incorrect: ""
        }
        vm.quizChoose = _quizChoose;
        vm.submitAnswer = _submitAnswer;

        function _init() {
            // initialization here
            _quizChoose(); // get rid of this when basing quiz on category
            console.log(vm.answerScore);
        }

        // Get for category type
        function _quizChoose() {
            // Filter based on chosen category
            mainService.getById("/api/quiz/", vm.quizType) // Get quiz based on category for now just getting all quizzes
                .then(_getQuizSuccess)
                .catch(_getQuizFailed)

            function _getQuizSuccess(res) {
                vm.quizList = res.data.Items;
                vm.questionSelected = vm.quizList[0];
                console.log(vm.quizList);
            }

            function _getQuizFailed(err) {
                toastr.error("Get Failed");
            }
        }

        // submit button clicked on answer
        function _submitAnswer() {
            // checks if answer is correct
            if (vm.answerSelected == vm.questionSelected.Correct) {
                toastr.success("Correct!");
            } else {
                toastr.error("Wrong!");
            }
            // waits then runs _next question 
            setTimeout(_nextQuestion, 1000);
        }

        // goes to next question 
        function _nextQuestion() {
            toastr.success("next question!");
        }
    }


})();