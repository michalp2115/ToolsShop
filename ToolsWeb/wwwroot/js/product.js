var dataTable

$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "catalogNumber", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "companyName", "width": "15%" },
            { "data": "category.name", "width": "15%" },
        ]
    });
}