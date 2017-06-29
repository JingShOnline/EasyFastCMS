var _contentService;
$(function () {
    _contentService = abp.services.app.content;
    initTreeData();
});


var nodetemp;

function initTreeData() {
    $("#tree").tree({
        url: "/api/services/app/column/GetColumnEasyTree",
        method: "get",
        onBeforeLoad: function (node, param) {
            param.isIndexHtml = false;
            param.isModel = true;
            param.isListHtml = false;
            param.isContenthtml = false;
        },
        checkbox: false,
        animate: true,
        lines: true,
        loadFilter: function (data) {
            return data.result;
        },
        onClick: function (node) {  //点击事件
            doSearch(node.id);
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
    return "<a onclick='editContent(&quot;" + row.id + "&quot;,&quot;" + row.modelRecordManagerControlerPath + "&quot;,&quot;" + row.columnName + "&quot;)' href='#' class='btn green opt'><i class='fa fa-plus-square'></i>修改</a>" +
        "&nbsp;" +
        "<button class='btn red opt' onclick='deleteContent(&quot;" + row.id + "&quot;)'><i class='fa fa-plus-square'></i>删除</button>";
}

function editContent(id, ctrl, columnName) {
    var url = "/Admin/Content/UpdateContent?id=" + id + "&ctrl=" + ctrl + "&columnName=" + columnName + "";
    url = encodeURI(url);
    window.location.href = url;
}


var cId;
//搜索
function doSearch(columnId) {
    cId = columnId;
    $('#easyui-datagrid').datagrid('load', {
        columnId: columnId,
        filter: $('#filter').val()
    });
}

function bulkDelete() {
    var ids = GetDataGridChecked();

    if (ids.length <= 0) {
        abp.message.error("请勾选要删除的内容");
        return;
    }
    abp.message.confirm(
        '这将会删除此内容',
        '确定吗',
        function (isConfirmed) {
            if (isConfirmed) {
                _contentService.deleteContent(ids).done(function () {
                    abp.notify.success("已经删除该内容", "操作成功");
                    doSearch(cId);
                });
            }
        }
    );
}


function addContent() {
    var url = "/Admin/Content/AddContent?modelId=" + nodetemp.attributes.modelId + "&ctrl=" + nodetemp.attributes.controller + "&columnId=" + nodetemp.id + "&columnName=" + nodetemp.text + "";
    url = encodeURI(url);
    window.location.href = url;
}