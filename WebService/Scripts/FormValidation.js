$(document).ready(function() {
    $(function () {
        // Initialize form validation on the registration form.
        // It has the name attribute "registration"
        $("form[name='registrationform']").validate({
            rules: {
                ServiceName: {required : true, minlength : 3, maxlength : 20},
                PersonName: { required: true, minlength: 3, maxlength: 20 }
            },
            messages: {
                ServiceName: {
                    required:"Service is required",
                    minlength: "The length must at least 3 symbols",
                    maxlength: "The length must less than 30 symbols"
                },
                PersonName: {
                    required: "Person is required",
                    minlength: "The length must at least 3 symbols",
                    maxlength: "The length must less than 30 symbols"
                }
            },
            // Make sure the form is submitted to the destination defined
            // in the "action" attribute of the form when valid
            submitHandler: function (form) {
                form.submit();
            }
        });
    });
});