(function () {
    $(function () {
        function initTreeData() {
            $("#tree").tree({
                url: "/api/services/app/column/GetColumnEasyTree",
                method: "get",
                onBeforeLoad: function (node, param) {
                    param.isIndexHtml = true;
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
function genterateColumnIndex() {
    var nodes = $('#tree').tree('getChecked');
    if (nodes.length <= 0) {
        abp.message.error("请勾选要生成的栏目,或者点击全部生成所有的首页", "操作失败");
        return;
    }
    var arrary = [];
    for (var i = 0; i < nodes.length; i++) {
        arrary.push(nodes[i].id);
        
    };
    

}