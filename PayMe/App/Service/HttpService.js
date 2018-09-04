PayMe.service("httpService", function ($http) {

    this.getData = function (getModel,scope) {

        $http({
            url: getModel.url,
            method: 'get',            
        }).then(function (data) {
            getModel.getFunction(data);
        })
    }

    this.postData = function (getModel, scope) {

        $http({
            url: getModel.url,
            method: 'post',
            data: getModel.data,
        }).then(function (data) {
            getModel.getFunction(data);
        })
    }
});