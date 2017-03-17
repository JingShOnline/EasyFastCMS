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
        columnName: $("#columnName").text(),
        dir: "defaultPic"
    }
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
    $("#DefaultPicUrl").val(response);
    console.log($("#DefaultPicUrl").val());
});