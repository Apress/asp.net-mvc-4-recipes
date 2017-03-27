var CurrentSort = "CreateDate";
var CurrentPage = 1;


function getData() {
    $.getJSON("/api/CollaborationSpaces/Page/" + CurrentPage + "/" + CurrentSort,
        function (data) {
            togglePageButtons(data);
            var viewModel = ko.mapping.fromJS(data);
            ko.applyBindings(viewModel);
            stripe();
            $("#LoadingDiv").hide();
        }
        );
}

$(function () {
    getData();
});
function Move(pages) {
    CurrentPage = CurrentPage + pages;
    $("#LoadingDiv").show();
    getData();
}

function Sort(column) {
    $("#LoadingDiv").show();
    CurrentSort = column;
    CurrentPage = 1;
    getData();
}

function togglePageButtons(data) {
    if (data) {
        if (data.CurrentPage == 1) {
            $("#back").hide();
        }
        else {
            $("#back").show();
        }

        if (data.CurrentPage == (data.NumberOfResults / data.ItemsPerPage)) {
            $("#next").hide();
        }
        else {
            $("#next").show();
        }
    }
}

function stripe() {
    $("tr:even").addClass("even");
    $("tr:odd").addClass("odd");
}
