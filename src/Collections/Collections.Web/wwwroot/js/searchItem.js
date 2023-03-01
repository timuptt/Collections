$(document).ready(function(){
    $('.item-search').select2({
        placeholder: "Search...",
        multiple: "multiple",
        ajax: {
            delay: 200,
            url: document.location.origin + "/api/Item",
            contentType: "application/json",
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            id: item.id,
                            text: item.title,
                            author: item.authorName,
                            collection: item.collectionTitle
                        }
                    })
                }
            }
        },
    })
});

$('.item-search').on('select2:select', function (e) {
    var data = e.params.data.id;
    window.location.href = '/Item/Details/' + data
});

function formatState (state) {
    if (!state.id) {
        return state.text;
    }
    var baseUrl = "/Item/";
    var $state = $(
        '<a class="text-decoration-none" href="/Item/Details/' + state.id + '">' + state.text + ' <span class="text-muted micro">' + state.collection +' by '+ state.author + '</span></a>'
    );
    return $state;
};