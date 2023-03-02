$(document).ready(function() {
    $('.tags-select').select2({
        placeholder: "Select tags",
        allowClear: true,
        tags: true,
        multiple: "multiple",
        ajax: {
            delay: 200,
            url: document.location.origin + "/api/Tag/Search",
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
                            text: item.text
                        }
                    })
                }
            }
        },
        createTag: function (params) {
            var term = $.trim(params.term);

            if (term === '') {
                return null;
            }

            return {
                id: term,
                text: term,
                newTag: true 
            }
        }
    })
});