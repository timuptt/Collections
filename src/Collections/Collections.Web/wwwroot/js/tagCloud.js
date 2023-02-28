$(document).ready(function () {
    var baseUrl = document.location.origin;
    var tags =[];
    $.ajax({
        url: baseUrl + "/api/Tag/GetTopTags",
        success: function (result) {
            console.log(result);
            tags = result
            var tagsWithLinks = [];
            tags.forEach(async (tag) =>{
                tagsWithLinks.push({text: tag.text, weight: tag.weight, link: baseUrl + "/Tag/Index/" + tag.id})
            });
            $("#tagCloud").jQCloud(tagsWithLinks, {
                autoResize: true,
                delay: 50
            });
        }
    });
});