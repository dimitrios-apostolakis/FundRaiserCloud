$(document).ready(function () {
    $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/project",
            "type": "GET",
            "datatype":"json"
        },
        "columns": [
            { "data": "title", "width": "25%" },
            { "data": "projectGoal", "width": "15%" },
            { "data": "days", "width": "15%" },
            { "data": "category.name", "width": "15%" }
        ],
        "width":"100%"
    });
});