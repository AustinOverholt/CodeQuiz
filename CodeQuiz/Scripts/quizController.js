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
        vm.newButton = _newButton;
        vm.editButton = _editButton;
        vm.deleteButton = _deleteButton;

        function _init() {
            console.log("quiz controller initialized");
            toastr.success("toastr works!");
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
            // modal form for new quiz question
        }

        function _editButton() {
            console.log("edit button clicked");
            // modal to edit current quiz question
        }

        function _deleteButton(Id, Index) {
            // delete and splice current quiz question
            mainService.delete("/api/quiz/", Id) 
                .then(_deleteSuccess)
                .catch(_deleteFailed)

            function _deleteSuccess(res) {
                // if successful splice
                console.log(res);
                vm.quizList.splice(Index, 1);
            }

            function _deleteFailed(err) {
                console.log(err);
            }
        }
    }
})();