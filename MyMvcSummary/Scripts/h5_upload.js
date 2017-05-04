var demo_h5_upload_ops = {
    init: function (obj) {

        this.eventBind(obj);
    },
    eventBind: function (obj) {
        var that = this;
        $(obj).change(function () {
            var reader = new FileReader();
            reader.onload = function (e) {
                that.compress(this.result);
            };
            reader.readAsDataURL(this.files[0]);
        });
    },
    compress: function (res) {
        var that = this;
        var img = new Image(),
            maxH = 300;

        img.onload = function () {
            var cvs = document.createElement('canvas'),
                ctx = cvs.getContext('2d');

            if (img.height > maxH) {
                img.width *= maxH / img.height;
                img.height = maxH;
            }
            cvs.width = img.width;
            cvs.height = img.height;

            ctx.clearRect(0, 0, cvs.width, cvs.height);
            ctx.drawImage(img, 0, 0, img.width, img.height);
            var dataUrl = cvs.toDataURL('image/png',1);
            $("#img_wrap").attr("src", dataUrl);
            // 上传略
            that.upload(dataUrl);
        };

        img.src = res;
    },
    upload: function (image_data) {
        image_data = image_data.replace(/^data:image\/(png|jpg);base64,/, "")
        $.ajax({
            url: '/H5/Teacher/Upload',
            type: 'POST',
            data: { image_data: image_data },
            dataType: 'json',
            success: function (res) {
                if (res.Error == 0) {
                    $('.am-share-sns .share_btn').click();
                } else {
                    toastShow(res.Message);
                }
            }
        });
    }
};

function upfile(obj) {
    $(obj).click();
}
//$(document).ready(function () {
//    demo_h5_upload_ops.init($("#opCamera"));
//    demo_h5_upload_ops.init($("#opFile"));
//});