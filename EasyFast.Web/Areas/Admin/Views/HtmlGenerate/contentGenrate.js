
function generateContent() {
    var nodes = $('#tree').tree('getChecked');
    if (nodes.length <= 0) {
        abp.message.error("请勾选要生成内容的栏目", "操作失败");
        return;
    }
    var arrary = [];
    for (var i = 0; i < nodes.length; i++) {
        arrary.push(nodes[i].id);

    };
    generateService.GenerateContent(arrary).done(function () {

        abp.message.success("生成内容页成功!", "操作成功");
    });

}