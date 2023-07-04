/// <reference path="../knockoutjs3.5.1.js" />
 

 
function EmployeeModel(item) {
    let self = this;
    item = item || {};
    self.id = ko.observable(item.id || 0);
    self.name = ko.observable(item.name || '');
    self.gender = ko.observable(item.gender || 'Male')
    self.address = ko.observable(item.address || '');
    self.department = ko.observable(item.department || '');
    self.salary = ko.observable(item.salary || '');


}