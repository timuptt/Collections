$(function() {
    $('#table-collections').dataTable({
        serverSide: true,
        processing: true,
        filter: true,
        searchDelay: 500,
        ajax: {
            url: 'api/Collection/GetCollections',
            type: 'POST',
            datatype: 'application/json'
        },
        columns: [
            { data: "id", autoWidth: true, name: "Id",
                mRender : function(data, type, row) {
                    if(type === 'display') {
                        return $('<a>')
                            .attr('href', document.location.origin + "/Collections/Details/" + data)
                            .text(data)
                            .wrap('<div></div>')
                            .parent()
                            .html();
                    }
                    return data
                }},
            { data: "title", name: "Title", autoWidth: true },
            { data: "description", name: "Description", autoWidth: true,
                mRender: function (data, type, row){
                    if (data.length > 50){
                        return $('<span>')
                            .attr("data-bs-toggle", "tooltip")
                            .attr("data-bs-placement", "top")
                            .attr("data-bs-title", data)
                            .text(data.substring(0, 50) + "...")
                            .wrap('<div></div>')
                            .parent()
                            .html();
                    }
                    return data;
                    }
            },
            { data: "userCollectionTheme", name: "Theme", autoWidth: true },
            { data: "profileFullName", name: "Author", autoWidth: true },
            { data: "itemsCount", name: "Items count", autoWidth: true },
        ]
    });
});