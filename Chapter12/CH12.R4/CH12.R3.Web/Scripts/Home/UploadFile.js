$(
function () {
    if (window.File && window.FileList && window.FileReader) {
        Init();
    }
}
);
function Output(msg) {
    var m = $("#messages");
    m.innerHTML = msg + m.innerHTML;
}
function Init() {
    // file select
    $("#File01").on("change", FileSelectHandler);
    // is XHR2 available?
    var xhr = new XMLHttpRequest();
    if (xhr.upload) {
        // file drop
        $("#FileDrop").on("dragover", FileDragHover);
        $("#FileDrop").on("dragleave", FileDragHover);
        $("#FileDrop").on("dragleave", FileDragHover);
        $("#FileDrop").on("drop", FileSelectHandler);
        $("#FileDrop").css("display", "block");
        // remove submit button
        $("#Submit").css("display", "none");
    }
}

function FileDragHover(e) {
    e.stopPropagation();
    e.preventDefault();
    e.target.className = (e.type == "dragover" ? "hover" : "");
}

function FileSelectHandler(e) {
    // cancel event and hover styling
    FileDragHover(e);
    // fetch FileList object
    var files
    if(typeof e.target!= 'undefined')
    {
        files = e.target.files
    }
    else if (typeof e.dataTransfer != 'undefined')
    {
        files = e.dataTransfer.files;
    }
    // process all File objects
    for (var i = 0, f; f = files[i]; i++) {
        ParseFile(f);
    }
}


function ParseFile(file) {
    Output(
		"<p>File information: <strong>" + file.name +
		"</strong> type: <strong>" + file.type +
		"</strong> size: <strong>" + file.size +
		"</strong> bytes</p>"
	);
}