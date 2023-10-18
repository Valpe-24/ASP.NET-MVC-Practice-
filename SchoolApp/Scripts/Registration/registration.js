
function Fullname_keyup(element, message) {
    validateFullname($(element).val(), element, message);
}

function Pass_keyup() {
    validatePassword();
    ConfirmPass_keyup();
    toggleConfirmPassword();
   
}

function Email_keyup(element) {
    validateEmail($(element).val());
}

function User_keyup(element) {
    validateUsername($(element).val());
}


function BlockNumbers(e) {
    if (e.which >= 48 && e.which <= 57) {
        e.preventDefault();
    } 
}

function validateEmail(value) {
    let emailRegex = /^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$/; 
    if (!emailRegex.test(value)) {
        $("#email-validation-error").text("Not a valid Email");
        $("#email-validation-error").addClass('error-text');
    } else {
        $("#email-validation-error").text('');
        $("#email-validation-error").removeClass('error-text');
    }


}
    
function validateFullname(value, element, message) {
    let fullnameRegex = /^[A-Za-z]{3,}$/;
    if (!fullnameRegex.test(value)) {
        $(element).next(".validation-error").text(message);
        $(element).next(".validation-error").addClass('error-text');
    } else {
        $(element).next(".validation-error").text("");
        $(element).next(".validation-error").removeClass('error-text');
    }

}
function validatePassword() {
    let passwordRegex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$/;

    if (!passwordRegex.test($("#Password").val())){
        $("#password-validation-error").text("Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit");
        $("#password-validation-error").addClass('error-text');
    } else {
        $("#password-validation-error").text('');
        $("#password-validation-error").removeClass('error-text');
    }
}

function validateUsername(value) {
    let usernameRegex = /^[a-zA-Z0-9]{5,8}$/;
    if (!usernameRegex.test(value)) {
        $("#username-validation-error").text("Username should be 5-8 characters long and include numbers");
        $("#username-validation-error").addClass('error-text');
    } else {
        $("#username-validation-error").text('');
        $("#username-validation-error").removeClass('error-text');
    }
}
function ConfirmPass_keyup() {
  
        let password = $("#Password").val();
        let confirmPass = $("#ConfirmPassword").val();

        if (password !== confirmPass) {
            $("#ConfirmPassword-validation-error").text("Password doesn't match");
            $("#ConfirmPassword-validation-error").addClass('error-text-red');
        } else {
            $("#ConfirmPassword-validation-error").text('');
            $("#ConfirmPassword-validation-error").removeClass('error-text-red');
        }
   
}

function RoleValidation() {
    let role = $("#role").val();
    if (role === "") {
        $("#role-validation-error").text("Please select a valid role");
        $("#role-validation-error").addClass('error-text');
    } else {
        $("#role-validation-error").text("");
        $("#role-validation-error").removeClass('error-text');
    }
}

//function ShowPassword() {

//    let passwordField = $("#Password")[0];
//    let checkbox = $("#ShowPassword")[0];

//    if (passwordField.type === "password") {
//        passwordField.type = "text";
//    } else {
//        passwordField.type = "password";
//    }

//    checkbox.checked = (passwordField.type === "text");
//}

function toggleConfirmPassword() {
    let passwordField = $("#Password");
    let confirmPassField = $("#ConfirmPassword");

    if (passwordField.val() !== "") {
        confirmPassField.show();
    } else {
        confirmPassField.hide();
    }
}

function showPass(element) {
    $(element).attr("type","text")

}

function hidePass(element) {
    $(element).attr("type", "password")

}

function hideErrorMsg() {
    $("#nameErrorMsg").hide();
    $("#lastNameErrorMsg").hide();
    $("#userErrorMsg").hide();
    $("#passwordErrorMsg").hide();
    $("#emailErrorMsg").hide();
    $("#roleErrorMsg").hide();
}

function submit() {

    hideErrorMsg();

    console.log("Function called")

    var inputData = $('#registrationForm').serialize();
    $.ajax({
        type: 'POST',
        url: '/Auth/Register',
        data: inputData,
        success: function(response) {

            console.log(response);

            switch (String(response)) {
                case "name":
                    $("#nameErrorMsg").show();
                    break;
                case "lastName":
                    $("#lastNameErrorMsg").show();
                    break;
                case "userName":
                    $("#userErrorMsg").show();
                    break;
                case "password":
                    $("#passwordErrorMsg").show();
                    break;
                case "email":
                    $("#emailErrorMsg").show();
                    break;
                case "role":
                    $("#roleErrorMsg").show();
                    break; 
                case "0":
                    success();
                    break;
            }
        },
        error: function (error) {
            console.error("Error: ", error)
        }
    })
}

function success() {
    console.log("Registration completed");

}

