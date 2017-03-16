﻿(function () {
    $(function () {
        $("#easyui-datagrid").datagrid({
            url: "/api/services/app/content/GetGridContents",
            loadFilter: function (data) {
                return data.result;
            }
        })
        initTreeData();
    });

})();

var nodetemp;

function initTreeData() {
    $("#tree").tree({
        url: "/api/services/app/column/GetColumnEasyTree",
        method: "post",
        onBeforeLoad: function (node, param) {
            if (!param.id) {
                param.id = null;
            }
        },
        checkbox: false,
        animate: true,
        lines: true,
        loadFilter: function (data) {
            return data.result;
        },
        onClick: function (node) {  //点击事件
            doSearch(node.id)
        },
        onContextMenu: function (e, node) { //右击事件
            e.preventDefault();
            nodetemp = node;
            $('#tree').tree('select', node.target);
            $('#menuBlur').menu('show', {
                left: e.pageX,
                top: e.pageY
            });
        }
    });
}


function formatOper(val, row, index) {

    return "<a href='/Admin/Content/UpdateContent?id=" +
        row.id +
        "' class='btn green opt'><i class='fa fa-plus-square'></i>修改</a>&nbsp;" +
        "<button class='btn red opt' onclick='deleteContent(&quot;" +
        row.id +
        "&quot;,&quot;" + row.modelRecordManagerControlerPath + "&quot;)'><i class='fa fa-plus-square'></i>删除</button>";
}




//搜索
function doSearch(columnId) {
    $('#easyui-datagrid').datagrid('load', {
        columnId: columnId,
        filter: $('#filter').val()
    });
}

function deleteContent(id, controller) {
    abp.message.confirm(
        '这将会删除此内容',
        '确定吗',
        function (isConfirmed) {
            if (isConfirmed) {
                abp.ajax({
                    url: "/Admin/" + controller + "/DeleteAsync",
                    data: JSON.stringify({ id: id })
                }).done(function () {
                    app.notify.success("已经删除该内容", "操作成功");
                    doSearch();
                })
            }
        }
    );
}


function addContent() {
    //后期换成易于SEO路由
    var url = "/Admin/Content/AddContent?modelId=" + nodetemp.attributes.modelId + "&ctrl=" + nodetemp.attributes.controller + "&columnId=" + nodetemp.id + "&modelName=" + nodetemp.attributes.modelName + "";
    var url = encodeURI(url);
    window.location.href = url;
}