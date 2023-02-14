$(document).ready(function() {
    $('.tags-select').select2({
        placeholder: "Select tags",
        allowClear: true,
        tags: true,
        multiple: "multiple",
        ajax: {
            url: document.location.origin +"/api/Tag",
            contentType: "application/json",
            data: function(params) {
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
                            text: item.title
                        }
                    })
                }
            }
        }
    });
});