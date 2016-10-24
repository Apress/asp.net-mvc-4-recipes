/// <reference path="../jquery-1.8.2.intellisense.js" />
/// <reference path="../moment.js" />
/// <reference path="../knockout-2.2.0.js" />

function Person(FirstName, LastName, AppointmentDate) {
    var self = this;
    self.FirstName = ko.observable(FirstName);
    self.LastName = ko.observable(LastName);
    self.PersonId = 0;
    self.AppointmentDate = ko.observable(AppointmentDate);
}

function PeopleModel(People)
{
    var self = this;
    self.People = ko.observableArray([new Person("", "", "")]);
    self.NewPerson = ko.observable(self.People()[0]);
    self.Message = ko.observable("");
    self.addPerson = function () {
        if ($("#NewPersonForm").valid()) {
            self.People.unshift(
                new Person("", "", "")
            );
            self.NewPerson(self.People()[0]);
        }
    };

    self.SetPeopleFromJSON = function (jsData) {
        self.People = ko.mapping.fromJS(jsData);
        self.People.unshift(
                new Person("", "", "")
            );
        self.NewPerson(self.People()[0]);
    }

    self.selectItem = function () {
        self.NewPerson(this);
    }

    self.saveAll = function () {
        if (self.People && self.People().length > 0) {
            var filtered = ko.utils.arrayFilter(self.People(),
               function (person)
               {
                   return ((!isEmpty(person.LastName())) &&
                       (!isEmpty(person.FirstName())) &&
                       (!isEmpty(person.AppointmentDate()))
                       );
               }
                   );
            var jsonData = ko.toJSON(filtered);
            $.ajax({
                url: "/api/Appointments",
                type: "POST",
                data: jsonData,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    self.SetPeopleFromJSON(data);
                    self.Message("Updated Successfully");
                },
                error: function (data) {
                    console.log(data);
                    self.Message("Updated Failed");
                }
            });
        }
    };


}

$(function () {
    $("#AppointmentDate").datepicker();
    var viewModel =  new PeopleModel();
    $.getJSON("/api/Appointments",
        function (data) {
            if (data && data.length > 0) {
                viewModel.SetPeopleFromJSON(data);
            }
            ko.applyBindings(viewModel);
            
            $("#LoadingDiv").hide();
            $("#ContainerDiv").show();
        });
});

ko.bindingHandlers.dateString = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        if (element.tagName == "INPUT") {
            //register event to update the observable when value changes
            ko.utils.registerEventHandler(element, "change", function () {
                var observable = valueAccessor();
                observable($(element).val());
            });
        }

    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var value = valueAccessor(),
            allBindings = allBindingsAccessor();
        var valueUnwrapped = ko.utils.unwrapObservable(value);
        var pattern = allBindings.datePattern || 'mmmm d, yyyy';
        if (isEmpty(valueUnwrapped)) {
            if (element.tagName == "INPUT") {
                $(element).val("");
            }
            else {
                $(element).text("");
            }
            
        }
        else {
            var date = moment(valueUnwrapped);
            if (element.tagName == "INPUT") {
                $(element).val(moment(date).format(pattern));
                
            }
            else {
                $(element).text(moment(date).format(pattern));
            }
            
        }
    }
}

ko.bindingHandlers.message = {
    update: function (element, valueAccessor) {
        $(element).hide();
        ko.bindingHandlers.text.update(element, valueAccessor);
        $(element).fadeIn();
        $(element).fadeOut(4000);
    }
};

function isEmpty(obj) {
    if (typeof obj == 'undefined' || obj === null || obj === '') return true;
    if (typeof obj == 'number' && isNaN(obj)) return true;
    if (obj instanceof Date && isNaN(Number(obj))) return true;
    return false;
}