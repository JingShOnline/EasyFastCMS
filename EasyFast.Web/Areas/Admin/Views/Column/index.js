
(function ($) {
    $(function () {
        abp.ajax({
            url: "/Admin/Column/GetColumnList"
        }).done(function (data) {
            var html = setTreeBody(data, "", 1);
            $("#treeBody").append(html);
            $('.tree').treegrid({
                initialState: "initialState"
            });
        });


    })
})(jQuery);

//设置树形表格
function setTreeBody(list, str, flag) {

    for (var i = 0; i < list.length; i++) {
        var temp;
        if (!flag) {
            temp = "treegrid-parent-" + list[i].parentId + "";
        }
        str += "<tr id=" + list[i].id + " class='treegrid-" + list[i].id + " " + temp + "'>" +
                       "<td>" + list[i].name + "</td>" +
                       "<td>" + list[i].columnType + "</td>" +
                       "<td>" + list[i].contentCount + "</td>" +
                       "<td>" + list[i].orderId + "</td>" +
                       "<td><a href='/Admin/Column/UpdateColumn?id=" + list[i].id + "' class='btn green opt'><i class='fa fa-plus-square'></i>修改</a>&nbsp;" +
                           "<button class='btn red opt' onclick='deleteColumn(" + list[i].id + ")'><i class='fa fa-plus-square'></i>删除</button></td></tr>"
        str = setTreeBody(list[i].children, str);
    }

    return str;
}
var _columnnService = abp.services.app.column;
function deleteColumn(id) {

    abp.message.confirm(
     '这将会删除此栏目',
     '确定吗',
     function (isConfirmed) {
         if (isConfirmed) {
             _columnnService.deleteAsync(id).done(function () {
                 abp.notify.success('已删除该栏目', '操作成功');
         
                 $("#" + id).remove();
             })
         }
     }
 );
}

