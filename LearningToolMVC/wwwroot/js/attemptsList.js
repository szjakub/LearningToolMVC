var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/Attempts/GetAll",
            "type": "GET",
            "datatype": "json",
        },
        "order": [[0, 'desc']],
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "sentence", "width": "10%" },
            { "data": "attempt", "width": "10%" },
            { "data": "meaning", "width": "10%" },
            { "data": "isCorrect", "width": "10%" },
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

