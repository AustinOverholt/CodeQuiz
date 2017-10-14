(function () {
    'use strict';
    angular
        .module("mainApp")
        .controller("quizController", quizController);

    quizController.$inject = ["$scope", "mainService", "toastr"]; 

    function quizController($scope, mainService, toastr) {

        var vm = this;
        vm.$scope = $scope;
        vm.$onInit = _init;
        vm.mainService = mainService;
        vm.quizList = {};
        vm.newQuiz = {};
        vm.editId;
        vm.newButton = _newButton;
        vm.editButton = _editButton;
        vm.editSubmit = _editSubmit;
        vm.deleteButton = _deleteButton;

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

        function _newButton() {
            console.log("new button clicked");
            // adds new question to db
            console.log(vm.newQuiz);
            mainService.post("/api/quiz/", vm.newQuiz)
                .then(_postSuccess)
                .catch(_postFailed);

            function _postSuccess(res) {
                toastr.success("Question added successfully", res);
                // close modal
                $("#newQuestion").modal('hide');
                // refresh list 
                _getQuizzes();
            }

            function _postFailed(err) {
                toastr.error("Question failed to post", err);
            }

        }

        function _editButton(Id) {
            vm.editId = Id;
            // run get by id 
            mainService.getById("/api/quiz/", Id)
                .then(_getSuccess)
                .catch(_getFailed);

            function _getSuccess(res) {
                // populate form with data
                vm.newQuiz = res.data.item;
            }

            function _getFailed(err) {
                console.log(err);
            }
        }

        function _editSubmit() {
            console.log("edit submit pressed");
            mainService.put("/api/quiz/", vm.newQuiz)
                .then(_putSuccess)
                .catch(_putFailed);

            function _putSuccess(res) {
                toastr.success("Edit Successful");
                $("#editQuestion").modal('hide');
                _getQuizzes();
            }

            function _putFailed(err) {
                toastr.error("Edit Failed");
            }
        }

        function _deleteButton(Id, Index) {
            // delete and splice current quiz question
            mainService.delete("/api/quiz/", Id) 
                .then(_deleteSuccess)
                .catch(_deleteFailed)

            function _deleteSuccess(res) {
                // if successful splice
                toastr.success(res);
                vm.quizList.splice(Index, 1);
            }

            function _deleteFailed(err) {
                toastr.error(err);
            }
        }
    }
})();