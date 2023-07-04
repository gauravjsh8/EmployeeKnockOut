 

function EmployeeController(prop) {
    var self = this;

    const baseUrl = "/api/EmployeeModels";
    self.mode = ko.observable(mode.create);
    self.selectedEmployee = ko.observable(new EmployeeModel());
    self.newEmployee = ko.observable(new EmployeeModel());
    self.employees = ko.observableArray([]);







    ajax.get(baseUrl).then(function (result) {
        var datas = ko.utils.arrayMap(result, function (item) {
            return new EmployeeModel(item);
        });
        self.employees(datas);
    });



    self.addEmployee = function () {
        switch (self.mode()) {
            case 1:

                ajax.post(baseUrl, ko.toJSON(self.newEmployee()))
                    .done(
                        (rs) => {
                            self.employees.push(new EmployeeModel(rs));
                            self.resetForm();
                        }).fail((err) => {
                            console.log(err);
                        });
                break;
            default:
                ajax.put(baseUrl + "/" + self.newEmployee().id(), ko.toJSON(self.newEmployee()))
                    .done(
                        (rs) => {

                            self.employees.replace(self.selectedEmployee(), self.newEmployee());
                            self.resetForm();
                        });


                break;
        }


    };
    self.resetForm = function () {
        self.newEmployee(new EmployeeModel());
        self.selectedEmployee(new EmployeeModel());
        self.mode(mode.create);
    }
    self.selectEmployee = (model) => {
        self.selectedEmployee(model);
        self.newEmployee(new EmployeeModel(ko.toJS(model)));
        self.mode(mode.update);
    };

    self.deleteEmployee = (model) => {
        ajax.delete(baseUrl + "/" + ko.toJS(model).id).done((result) => {
            self.employees.remove(model);
            self.mode(mode.create);
        })
       
    };
}

var ajax = {
    get: function (url, data) {
        return $.ajax({
            method: "GET",
            url: url,

        });
    }
    ,
    post: function (url, data) {

        return $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "POST",
            url: url,
            data: (data)
        });
    },
    put: function (url, data) {
        return $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "PUT",
            url: url,
            data: data
        });
    },
    delete: function (url) {
        //api/apiController/id
        return $.ajax({
            method: "DELETE",
            url: url
           
        });

    }
}

const mode = {
    create: 1,
    update: 2
};

























