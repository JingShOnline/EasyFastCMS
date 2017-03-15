(function () {
    $(function () {
        var $modelTable = $("#ContentModelTable");

        var modelService = abp.services.app.model;

        var createModel = new app.ModalManager({
            viewUrl: abp.appPath + "Admin/Model/CreateModel",
            scriptUrl: abp.appPath + "Areas/Admin/Views/Model/_CreateOrUpdateModel.js",
            modalClass: "CreateModel"
        });


        var editModel = new app.ModalManager({
            viewUrl: abp.appPath + "Admin/Model/EditModel",
            scriptUrl: abp.appPath + "Areas/Admin/Views/Model/_CreateOrUpdateModel.js",
            modalClass: "EditModel"
        });
        $modelTable.jtable({
            title: "内容模型管理",
            paging: true,//分布
            sorting: true,//排序
            multiSorting: true,//多级排序
            actions: {
                listAction: {
                    method: modelService.getModels
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
                        var $span = $('<span></span>');

                        $('<button class="btn btn-default btn-xs" title="修改"><i class="fa fa-edit"></i></button>').appendTo($span).click(function () {
                            editModal.open({ id: data.record.id });
                        });


                        $('<button class="btn btn-default btn-xs title="删除""><i class="fa fa-trash-o"></i></button>').appendTo($span).click(function () {

                            deleteModel(data.record);
                        });


                        return $span;
                    }
                },
                modelName: {
                    title: "模型名称",
                    width: "18%"
                },
                Description: {
                    title: "描述",
                    width: "25%"
                },
                unit: {
                    title: "单位",
                    width: "8%"
                },
                isCountHits: {
                    title: "是否参与统计",
                    width: "8%"
                },
                tableName: {
                    title: "表名",
                    width: "15%"
                }
            }

        });


        function getModels(reload) {
            if (reload) {
                $modelTable.jtable("reload");
            } else {
                $modelTable.jtable("load",
                    {
                        filter: $("ModelTableFilter").val()
                    });
            }
        }


        function deleteModel(model) {
            abp.message.confirm("你真的要删除吗",
                "删除",
                function (isConfirmed) {
                    if (isConfirmed) {
                        modelService.deleteModel({ id: model.id }).done(function () {
                            getModels();
                            abp.notify.success("删除成功!");
                        });
                    }

                });
        }

        getModels();


        $("#CreateNewModelButton").click(function () {
            createModel.open();
        });

        $("#GetModelButton").click(function (e) {
            e.preventDefault();
            getModels();
        });


        abp.event.on("abp.createModelSaved",
            function () {
                getModels(true);
            });
        abp.event.on("app.editModelSaved",
            function () {
                getModels(true);
            });
    });
})();


