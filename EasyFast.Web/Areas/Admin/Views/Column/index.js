
(function ($) {
    $(function () {
        PagedList(1);
    })
})(jQuery);

var _columnnService = abp.services.app.column;

function PagedList(pageNum) {
    $("#pageBar").empty();
    $("#treeBody").empty();
    var skipCount = ((pageNum - 1) * 10) + 1;
    var input = { SkipCount : skipCount, Filter: $("#searchName").val() };
    _columnnService.getColumnGridAsync(input).done(function (data) {
        var html = setTreeBody(data.items, "", 1);
        var pagehtml = setPage(data.totalCount, 10);
        $("pageBar").html(pagehtml);
        $("#treeBody").append(html);
        $('.tree').treegrid({
            initialState: "initialState"
        });
    });
}

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

function setPage(totalCount, pageNum, pageSize) {

    var totalPage = Math.ceil(totalCount / pageSize);  //10
    var firstPageNum = Math.max(pageNum - 5, 1);
    var lastPageNum = Math.min(pageNum + 5, totalPage);
    var str = "<div class='dataTables_paginate paging_bootstrap_number' id='sample_2_paginate'><ul class='pagination' style='visibility: visible;'>";
    //首页
    str += "<li><a onclick='PagedList(1)'><font><font>首页</font></font></a></li>";
    for (var i = firstPageNum; i < lastPageNum; i++) {
        if (i == pageNum) {
            str += "<li class='active'><a href='#'><font><font>" + pageNum + "</font></font></a></li>"
        } else {
            str += "<li><a onclick='PagedList(" + i + ")'><font><font>" + i + "</font></font></a></li>"
        }

    }
    str += "<li><a onclick='PagedList(" + totalPage + ")'><font><font>尾页</font></font></a></li>"
    str += "</ul></div>";
    return str;
}
