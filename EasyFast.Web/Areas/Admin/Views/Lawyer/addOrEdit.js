(function () {
    $(function () {
        var editor = new wangEditor("content");
        editor.config.uploadImgUrl = "/Admin/Content/EditorUploadFile";
        // 配置自定义参数
        editor.config.uploadParams = {
            columnName: $("#columnName").text(),
            dir: 'ContentPic'
        };
        editor.create();
    })

})();

function submitConent() {
    var $form = $("#addContent");
    if (!$form.valid()) {
        abp.notify.error("您有未填写的必填项,请向上翻动页面查看");
        return;
    }
    var $div = $form.parent();
    abp.ui.setBusy($div);
    abp.ajax({
        url: '/api/services/app/lawyer/addOrUpdateAsync',
        data: $form.serializeFormToJson()
    }).done(function () {
        abp.notify.success("添加律师成功", "操作成功");
        window.location.href = "Index";

    }).always(function () {
        abp.ui.clearBusy($div);
    });
}


