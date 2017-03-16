(function () {
    $(function () {

        $("#easyui-datagrid").datagrid({
            url: "/api/services/app/model/GetModels",
            loadFilter: function (data) {
                return data.result;
            }
        });
    });
})();


