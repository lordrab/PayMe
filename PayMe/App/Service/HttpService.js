PayMe.service("httpService", function ($http) {

    this.getData = function (getModel) {

        $http({
            url: getModel.url,
            method: 'get',            
        }).then(function (data) {
            getModel.getFunction(data);
        })
    }
});