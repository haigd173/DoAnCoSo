function ShowImagePreview(imageUpload, previewImage) {
    if (imageUpload.files && imageUpload.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage) Attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUpload.files[0]);
    }
}