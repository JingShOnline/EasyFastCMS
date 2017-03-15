(function () {

    $(function () {

        var columnSerivce = abp.services.app.column;
        var contentService = abp.services.app.content;

        var $contentTable = $("#contentTable");

        $contentTable.jtable({
            title: "内容信息管理",
            paging: true,//分布
            sorting: true,//排序
            multiSorting: true,//多级排序
            actions: {
                listAction: {
                    method: contentService.getGridContents
                }
            },
            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    title: "操作",
                    width: "15%",
                    sorting: false,
                    display: function (data) {
                        //var $span = $('<span></span>');
                        //$('<button class="btn btn-default btn-xs" title="修改"><i class="fa fa-edit"></i></button>').appendTo($span).click(function () {
                        //    editModal.open({ id: data.record.id });
                        //});
                        //$('<button class="btn btn-default btn-xs title="删除""><i class="fa fa-trash-o"></i></button>').appendTo($span).click(function () {

                        //    deleteModel(data.record);
                        //});

                        //return $span;
                    }
                },
                title: {
                    title: "标题名称",
                    width: "18%"
                },
                columnName: {
                    title: "所属栏目",
                    width: "18%"
                },
                modelModelName: {
                    title: "所属模型",
                    width: "18%"
                },
                hits: {
                    title: "点击量",
                    width: "8%"
                }
            }

        });

        function initTreeData() {
            $("#tree").tree({
                url: "/api/services/app/column/GetColumnEasyTree",
                method: "post",
                checkbox: true,
                lines: true,
                loadFilter: function (data) {
                    return data.result.expand();
                },
                onClick: function (node) {  //点击事件
                    GetContent(true, node.id)
                },
                onContextMenu: function (e, node) { //右击事件
                    e.preventDefault();
                    $('#tree').tree('select', node.target);
                    $('#mm').menu('show', {
                        left: e.pageX,
                        top: e.pageY
                    });
                }
            });
        }

        function GetContent(reload, id) {
            if (reload) {
                $contentTable.jtable("reload",
                    {
                        id: id,
                        filter: $("#contentFilter").val()
                    });
            } else {
                $contentTable.jtable("load",
                    {
                        id: id,
                        filter: $("#contentFilter").val()
                    });
            }
        }


        initTreeData();
    });

})();