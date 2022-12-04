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
            { "data": "category.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group" >
                            <a href="/Admin/Projects/upsert?id=${data}"  class="btn btn-success text-white mx-2">
                            <i class="bi bi-pencil-square"></i>  </a>
                            <a href="/Admin/Projects/upsert?id=${data}"  class="btn btn-danger text-white mx-2">
                             <i class="bi bi-trash-fill"></i>  </a>
                            </div>`
                },
                "width": "15%"
            }
        ],
        "width":"100%"
    });
});