// do an ajax call to get some numbers
$(document).ready(function () {
    var source = "/List/Display";
    console.log(source);
    // get data in JSON format from our controller
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayData
    });
});

function displayData(data) {
    var i = 0;
    while (i < data.name.length) {
        console.log(i);
        var trow = $("<tr>");
        var tdat = null;
        tdat = $("<td>").text(data.name[i]);
        tdat.appendTo(trow);
        tdat = $("<td>").text(data.total[i]);
        tdat.appendTo(trow);
        trow.appendTo($("#Table"));
        i++;
    }
}
