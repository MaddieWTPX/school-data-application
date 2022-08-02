function SortTable(action, sortColumn, sortDirection, currentPage) {
    $.ajax({
        async: false,
        url: action,
        data: { sortColumn: sortColumn, sortDirection: sortDirection, CurrentPage: currentPage },

        type: 'GET',
        success: function (data) {
            $("#userResults").html(data);
        }
    });
}