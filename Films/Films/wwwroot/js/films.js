var dataTable;

$(document).ready(function () {
    loadDataTable()
});

function loadDataTable() {
    dataTable = $("#tblData").DataTable({
        "ajax": {
            "url": "/film/GetFilmList"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "name", "width": "15%" },
            {
                "data": "categoryIdList",
                "width": "15%",
                "render": function (data, type, row) {
                    if (data && data.length > 0) {
                        return data.map(function (category) {
                            return category.name;
                        }).join(", ");
                    } else {
                        return "?";
                    }
                }
            },
            { "data": "director", "width": "15%" },
            { "data": "release", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Film/Details/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                <i class="fa-solid fa-info"></i>
                            </a>
                        </div>
                    `;
                },
                "width": "5%"
            }
        ]
    });
}