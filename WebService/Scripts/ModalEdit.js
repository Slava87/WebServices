$(document).ready(function () {
    $('a[data-edit]').click(function () {

        var url = "/Service/EditService"; // the url to the controller
        var id = $(this).attr('data-id'); // the id that's given to each button in the list

        $.get(url + '/' + id, function (data) {
            if (id > 0) {
                $('#id-modal-title').text('Edit Service');
                $('#id-dataSave').text('Save');
            } else {
                $('#id-modal-title').text('Create Service');
                ('#id-dataSave').text('Create');
            }
            $('#edit-service-container').html(data);
        });

        $('#id-dataSave').click(function () {
            $.post("/Service/Save", $("#testform").serialize(), function (data, textStatus) {

                var parsedJson = $.parseJSON(data);
                $('#service-name-' + parsedJson.Id).empty().text(parsedJson.ServiceName);
                $("#edit-service .close").click();

                //$('#edit-service').modal({ hide: true });
                //alert("Data Loaded: " + parsedJson.ServiceName); 
            });


            //$.ajax({
            //    type: "POST",
            //    dataType: "json",
            //    contentType: "application/json; charset=utf-8",
            //    url: "/Service/Save",
            //    data: JSON.stringify({ 
            //        Id: "1", 
            //        ServiceName: "blablacar111"
            //    }),

            //    success: function () {
            //        alert('Success message.');
            //    },
            //    error: function() {
            //        alert('Error message');
            //    }
            //});
        });

        $('#edit-service').modal({ show: true });
    });
});