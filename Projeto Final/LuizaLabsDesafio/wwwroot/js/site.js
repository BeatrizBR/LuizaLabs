
    function clickme(){
        console.log("funcionando...")
            var username = document.getElementById("username").value;
    var password = document.getElementById("_password").value;
    var incorrect = document.getElementById("incorrect-user");
    var rememberMe = document.querySelector("#rememberMeRadio");

    var user = new Object();
    user.username = username;
    user._password = password

    var stringifiedUser = JSON.stringify(user);
    var request = $.ajax({
        headers: {
        'Content-Type': 'application/json'
                                    },
        url: "/api/user/login",
        type: "POST",
        data: stringifiedUser,

        success: function (response) {
            if (rememberMe.checked) {
                window.sessionStorage.setItem("password", password);
            }
            window.location.href = "login/login";
            },
        error: function errorMessage (request, status, error) {
              incorrect.removeAttribute("hidden");
            } 
         });       
    }
