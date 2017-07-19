$(document).ready(function () {

    //$('#testform').validate({

    //    rules: {
    //        ServiceName: {
    //            required: true
    //        },
    //        inputtext : {
    //            required:true
    //        }

    //    },
    //    messages: {
    //        ServiceName: {
    //            requires: "Field1 is required"
    //        },
    //        inputtext: {
    //            required: "Field is empty"
    //        }
    //    }
    //});


    $('a[data-edit]').click(function () {

        var url = "/Service/EditService"; // the url to the controller
        var id = $(this).attr('data-id'); // the id that's given to each button in the list

        $.get(url + '/' + id, function (data) {
            if (id > 0) {
                $('#id-modal-title').text('Edit Service');
                $('#id-dataSave').text('Save');
            } else {
                $('#id-modal-title').text('Create Service');
                $('#id-dataSave').text('Create');
            }
            $('#edit-service-container').html(data);
        });

        $('#edit-service').modal({ show: true });
    });

    $('#id-dataSave').click(function () {

        if ($('#testform').valid()) {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '/Service/Save',
                data: $('#testform').serialize(),

                success: function (data) {
                    $('#service-name-' + data.Id).empty().text(data.ServiceName);
                    $('#service-type-' + data.Id).empty().text(data.ServiceType);
                    $("#edit-service .close").click();
                },
                error: function (message) {
                    alert(message);
                }
            });
        };
    });

});