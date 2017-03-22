
function generateList() {
    var nodes = $('#tree').tree('getChecked');
    if (nodes.length <= 0) {
        abp.message.error("请勾选要生成的栏目,或者点击全部生成所有的列表页", "操作失败");
        return;
    }
    var arrary = [];
    for (var i = 0; i < nodes.length; i++) {
        arrary.push(nodes[i].id);

    };
    generateService.generateColumnList(arrary, false).done(function () {
        abp.message.success("栏目列表生成成功!", "操作成功");
    });
}

function generateAllList() {
    generateService.generateColumnList(new [], true).done(function () {
        abp.message.success("栏目列表生成成功!", "操作成功");
    });
}