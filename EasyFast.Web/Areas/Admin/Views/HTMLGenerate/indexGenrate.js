
function generateColumnIndex() {
    var nodes = $('#tree').tree('getChecked');
    if (nodes.length <= 0) {
        abp.message.error("请勾选要生成的栏目,或者点击全部生成所有的首页", "操作失败");
        return;
    }
    var arrary = [];
    for (var i = 0; i < nodes.length; i++) {
        arrary.push(nodes[i].id);

    };
    generateService.generateColumnIndex(arrary, false).done(function () {
        abp.message.success("栏目生成成功!", "操作成功");
    });

}

function generateIndex() {
    generateService.generateIndex().done(function () {
        abp.message.success("网站首页生成成功!", "操作成功");
    });
}

function generateAllIndex() {
    generateService.generateAllIndex().done(function () {
        abp.message.success("全部生成成功!", "操作成功");
    });
} 