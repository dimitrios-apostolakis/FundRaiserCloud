﻿var dataTable;
$(document).ready(function () {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/project",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "title", "width": "20%" },
            { "data": "projectGoal", "width": "15%" },
            /*{ "data": "projectCreator", "width": "15%" },*/
            { "data": "days", "width": "10%" },
            { "data": "category.name", "width": "10%" },
            
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-25 btn-group" >
                            <a href="/Admin/Projects/upsert?id=${data}"  class="btn btn-success text-white mx-2">
                            <i class="bi bi-pencil-square"></i>  </a>
                            <a onClick=Delete('/api/project/'+${data})  class="btn btn-danger text-white mx-2">
                             <i class="bi bi-trash-fill"></i>  </a>
                            </div>`
                },
                "width": "10%"
            }
        ],
        "width": "100%"
    });
});

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        //success notification
                        toastr.success(data.message);
                    }
                    else {
                        //failsure notification
                        toastr.error(data.message);
                    }
                }
            })
        }
    })

}