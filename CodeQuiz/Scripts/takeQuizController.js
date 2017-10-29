(function () {
    "use strict";
    angular
        .module("mainApp")
        .controller("takeQuizController", takeQuizController);

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
        };
        vm.quizChoose = _quizChoose;
        vm.submitAnswer = _submitAnswer;
        vm.previousQuestion = _previousQuestion;
        vm.nextQuestion = _nextQuestion;
        vm.getQuestion = _getQuestion;

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
                .catch(_getQuizFailed);

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
                // add +1 to correct
                vm.answerScore.Correct++;
            } else {
                toastr.error("Wrong!");
                // add +1 to incorrect
                vm.answerScore.Incorrect++;
            }
            // waits then runs _next question 
            setTimeout(_nextQuestion, 1000);
        }

        // goes to next question 
        function _nextQuestion() {
            // kind of hacky, maybe go back and fix this?
            // add if statement, if there is a 
            var nextQuestion = vm.questionSelected.Id;
            nextQuestion++;
            console.log(nextQuestion);
            // run function to get question 
            _getQuestion(nextQuestion);
        }

        // goes to previous question
        function _previousQuestion() {
            var previousQuestion = vm.questionSelected.Id;
            previousQuestion--;
            console.log(previousQuestion);
            // run function to get question 
            _getQuestion(previousQuestion);
        }

        // get by id for previous or next question
        function _getQuestion(Id) {
            console.log(Id);
            mainService.getById("/api/quiz/", Id)
                .then(_getSuccess)
                .catch(_getFailed);

            function _getSuccess(res) {
                console.log(res);
                vm.questionSelected = res.data.item;
            }

            function _getFailed(err) {
                console.log(err);
            }
        }
    }


})();