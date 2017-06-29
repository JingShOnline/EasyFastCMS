
/**
 * 
 * @param {any} val
 * @param {any} row
 */
function FormatColumnName(val, row) {
    if (row.ColumnTypeEnum === 1) {
        return '<a href="/Admin/Column/Update/' + row.Id + '">' + val + '</a>';
    }
    if (row.ColumnTypeEnum === 2) {
        return '<a href="/Admin/Column/SingleUpdate/' + row.Id + '">' + val + '</a>';
    }
};

//创建UpLoad
function createUpload(pick, formData, listId, imgUrlId) {
    var upLoad = WebUploader.create({
        auto: true,
        swf: "/Content/Uploader.swf",
        server: "/Admin/Content/UploadFile",
        pick: "#" + pick,
        accept: {
            title: "Images",
            extensions: 'gif,jpg,jpeg,bmp,png',
            mimeTypes: 'image/*'
        },
        formData: formData
    });


    upLoad.on('fileQueued', function (file) {
        $("#" + listId).empty();
        var $li = $(
                '<div id="' + file.id + '" class="file-item thumbnail">' +
                '<img>' +
                '<div class="info">' + file.name + '</div>' +
                '</div>'
            ),
            $img = $li.find('img');


        // $list为容器jQuery实例
        $("#" + listId).append($li);
        upLoad.makeThumb(file, function (error, src) {
            if (error) {
                $img.replaceWith('<span>不能预览</span>');
                return;
            }

            $img.attr('src', src);
        }, 100, 100);
    });

    //上传成功
    upLoad.on('uploadSuccess', function (file, response) {
        $('#' + file.id).addClass('upload-state-done');
        abp.notify.success("上传图片成功!");
        $("#" + imgUrlId).val(response);
    });

    upLoad.on('uploadError',
        function (file, response) {
            console.log(response);
            abp.message.error("图片上传失败,请检查宽高格式是否正确", "失败");
        });

}

//获取複選框选中
function GetDataGridChecked(domId) {
    if (domId == null || domId == undefined) {
        domId = "easyui-datagrid";
    }
    var ss = [];
    var rows = $('#' + domId).datagrid('getSelections');
    for (var i = 0; i < rows.length; i++) {
        var row = rows[i];
        ss.push(row.id);
    }
    return ss;
}

//创建富文本编辑器
function createEditor(id, uploadImgUrl, uploadParams) {
    var editor = new wangEditor(id);
    editor.config.uploadImgUrl = uploadImgUrl;
    // 配置自定义参数
    editor.config.uploadParams = uploadParams;
    editor.create();
}



