var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/attempts/getall/",
            "type": "GET",
            "datatype": "json",
        },
        "order": [[0, 'desc']],
        "columns": [
            { "data": "id", "width": "20%" },
            { "data": "attempt", "width": "20%" },
            { "data": "isCorrect", "width": "20%" },
            { "data": "definition", "width": "20%" },
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}