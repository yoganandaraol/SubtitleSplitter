var appModule = angular.module("subtitleModule", []);

appModule.controller("subtitleController", ["$scope", "$http","$timeout", "$interval", function ($scope, $http, $timeout, $interval) {
    $scope.NotifyMessage = "Subtitle Controller testing";
    var intervalPromise;

    $scope.getSubtitlesCallback = function () {
        var inputTitles = $("#txtSubtitleFullText").val();
        var serviceInput = { "SubtitleText": inputTitles };
        debugger;
        $http({
            method: "POST",
            type: "application/json",
            url: "../api/SubtitleSplitter/GetParsedMessage",
            data: serviceInput
        }).then(
        function (response) {
            $scope.SplittedSubtitles = response.data;
            $timeout(callAtTimeOut, 500);
        },
        function (response) {
            $scope.NotifyMessage = response.data;
        });
    };

    function callAtTimeOut() {
        //alert("Timeout");
        var index = 0;
        intervalPromise = $interval(function () {
            $scope.currentTitle = $scope.SplittedSubtitles[index];
            for (var i = 0; i < $scope.SplittedSubtitles.length; i++) {
                if (i == index) {
                    $("#span-" + i).addClass("highlight");
                    $("#span-" + i).focus();
                }
                else
                    $("#span-" + i).removeClass("highlight");
            }
            index++;
            if (index == $scope.SplittedSubtitles.length) {
                $interval.cancel(intervalPromise);
            }
        }, 2000);
    }
}]);