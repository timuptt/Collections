$(document).ready(function() {
    $('.tags-select').select2({
        placeholder: "Select tags",
        allowClear: true,
        tags: true,
        multiple: "multiple",
        ajax: {
            delay: 200,
            url: document.location.origin + "/api/Tag",
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
    }).on("select2:select", function (e) {
        if (e.params.data.newTag === true){
            console.log("selected new " + e.params.data.id + " " + e.params.data.text);
            $("#selectedTags").insertAdjacentHTML("beforeend", '<option value="' + 0 + '" text="' + e.params.data.text +'"/>')
        }
        else{
            console.log("selected " + e.params.data.id + " " + e.params.data.text);
            $("#selectedTags").insertAdjacentHTML("beforeend", '<option value="' + e.params.data.id + '" text="' + e.params.data.text +'"/>')
        }
    })
});