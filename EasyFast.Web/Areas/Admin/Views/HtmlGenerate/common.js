(function () {
    $(function () {
        function initTreeData() {
            $("#tree").tree({
                url: "/api/services/app/column/GetColumnEasyTree",
                method: "get",
                onBeforeLoad: function (node, param) {
                    param.isIndexHtml = true;
                    param.isSingleColumn = true;
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


        initTreeData();
    });



})();
var generateService = abp.services.app.htmlGenerate;