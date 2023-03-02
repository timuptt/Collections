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
            { data: "id", autoWidth: true,
                render : function(data, type) {
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
            { data: "description", name: "Description", autoWidth: true },
            { data: "userCollectionTheme", name: "Theme", autoWidth: true },
            { data: "profileFullName", name: "Author", autoWidth: true },
            { data: "itemsCount", name: "Items count", autoWidth: true },
        ]
    });
});