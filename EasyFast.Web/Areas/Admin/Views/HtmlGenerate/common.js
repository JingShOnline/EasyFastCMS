var generateService;
$(function() {
    generateService = abp.services.app.htmlGenerate;
});
function initTreeData(isindexHtml, isModel, isListHtml, isContenthtml) {
    $("#tree").tree({
        url: "/api/services/app/column/GetColumnEasyTree",
        method: "get",
        onBeforeLoad: function (node, param) {
            param.isIndexHtml = isindexHtml;
            param.isModel = isModel;
            param.isListHtml = isListHtml;
            param.isContenthtml = isContenthtml;
        },
        checkbox: true,
        animate: true,
        lines: true,
        loadFilter: function (data) {
            return data.result;
        },
        cascadeCheck: false
    });
}