function preview(files) {
    $("#previewImg").html("");

    if (files) {
        $("#previewImg").append("<label class='control-label col-md-2' for='Images'>Sélectionner l'image principale:</label><br><br>");
        

        for (var i = 0, l = files.length; i < l; i++) {
            var reader = new FileReader();
            
            reader.onload = function (i, e) {
                var checked = "";

                if (i === 0) {
                    checked = "checked='checked'";
                }

                $("#previewImg").append("<label><input type='radio' name='imgDefault' value='" + i + "' " + checked + "> <img src='" + e.target.result + "' class='imgMiniature' /> </label>");

            }.bind(reader, i);

            reader.readAsDataURL(files[i]);
        }
    }
}