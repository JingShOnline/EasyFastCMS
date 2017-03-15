
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
                });
            }
        }
    );
}

function formatOper(val, row, index) {

    return "<a href='/Admin/Column/UpdateColumn?id=" +
        row.Id +
        "' class='btn green opt'><i class='fa fa-plus-square'></i>修改</a>&nbsp;" +
        "<button class='btn red opt' onclick='deleteColumn(" +
        row.Id +
        ")'><i class='fa fa-plus-square'></i>删除</button>";
}


