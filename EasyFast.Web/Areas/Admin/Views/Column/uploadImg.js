var upload = WebUploader.create({
    auto: true,
    swf: "/Content/Uploader.swf",
    server: "/Admin/Content/UploadFile",
    pick: "#filePicker",
    accept: {
        title: "Images",
        extensions: 'gif,jpg,jpeg,bmp,png',
        mimeTypes: 'image/*'
    },
    formData: {
        columnName: $("#Name").val(),
        dir: "columnPic"
    }
});

//当文件被加入队列之前触发
upload.on('beforeFileQueued', function (file) {
    upload.options.formData = { "columnName": $("#Name").val(), "dir": "columnPic" }

});


upload.on('fileQueued', function (file) {
    $("#fileList").empty();
    var $li = $(
        '<div id="' + file.id + '" class="file-item thumbnail">' +
        '<img>' +
        '<div class="info">' + file.name + '</div>' +
        '</div>'
    ),
        $img = $li.find('img');


    // $list为容器jQuery实例
    $("#fileList").append($li);
    upload.makeThumb(file, function (error, src) {
        if (error) {
            $img.replaceWith('<span>不能预览</span>');
            return;
        }

        $img.attr('src', src);
    }, 100, 100);
});

//上传成功
upload.on('uploadSuccess', function (file, response) {

    $('#' + file.id).addClass('upload-state-done');
    abp.notify.success("上传默认图片成功!");
    $("#ImageUrl").val(response);
});