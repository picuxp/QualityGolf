// Write your JavaScript code.

$('#modalEditar').on('shown.bs.modal', function () {
    $('#myInput').focus()
})

function getUsuario(id,action){
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function(response) {
            mostrarUsuario(response);

        }
    });

}

var items;
var j = 0;

var id;
var userName;
var email;

var role;
var selectRole;


var nombre;
var apellido;
var dni;
var accessFailedCount;
var concurrentStamp;
var lockoutEnabled;
var lockoutEnd;
var normalizedUserName;
var normalizedEmail;
var passwordHash;
var phoneNumberConfirmed;
var securityStamp;
var twoFactorEneable;
var phoneNumber;
var emailConfirmed;




function mostrarUsuario(response) {
    items = response;
    j = 0;
    for (var i = 0; i < 3; i++) {
        var x = document.getElementById('Select');
        x.remove(i);
    }

    $.each(items,function(index, val) {
        $('input[name=Id]').val(val.id);
        $('input[name=UserName]').val(val.userName);
        $('input[name=Email]').val(val.email);
        document.getElementById('Select').options[0] = new Option(val.role, val.roleId);

        //mostrar detalles de usuario

        $("#dEmail").text(val.email);
        $("#dUserName").text(val.userName);
        $("#dRole").text(val.role);

        //mostrar usuario que voy a eliminar

        $("#eUsuario").text(val.email);
        $('input[name= EIdUsuario]').val(val.id);

    });
}



function getRoles(action) {
    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function(response) {
            if (j === 0) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('Select').options[i] = new Option(response[i].text, response[i].value);
                    document.getElementById('SelectNuevo').options[i] = new Option(response[i].text, response[i].value);
                }
                j = 1;
            }
        }
    });
} 


function editarUsuario(action) {
    //obtengo los datos del input del formulario
    id = $('input[name=Id]')[0].value;
    email = $('input[name = Email]')[0].value;
    role = document.getElementById('Select');
    selectRole = role.options[role.selectedIndex].text;

    

    $.each(items, function (index, val) {

        accessFailedCount= val.accessFailedCount;
        concurrentStamp= val.concurrentStamp;
        lockoutEnabled= val.lockoutEnabled;
        lockoutEnd= val.lockoutEnd;
        normalizedUserName= val.normalizedUserName ;
        normalizedEmail =  val.normalizedEmail;
        passwordHash = val.passwordHash;
        phoneNumberConfirmed = val.phoneNumberConfirmed;
        securityStamp = val.securityStamp;
        twoFactorEneable = val.twoFactorEneable;
        phoneNumber = val.phoneNumber;
        userName = val.userName;
        emailConfirmed = val.emailConfirmed;
    });

    
    $.ajax({
        type: "POST",
        url: action,
        data: {
            id, userName, email, phoneNumber, accessFailedCount, concurrentStamp, emailConfirmed, lockoutEnabled,
            lockoutEnd, normalizedEmail, normalizedUserName, passwordHash, phoneNumberConfirmed, securityStamp,
            twoFactorEneable, selectRole
        },
        success: function (response) { 

            


            if (response == "Save") {
                
                window.location.href = "Usuarios";
            } else {
                alert("no se puede editar los datos del usuario");
            }

        }
     });


}

function ocultarDetalleUsuario() {
    $("#modalDetalle").modal("hide");
}


function eliminarUsuario(action) {
    var id = $('input[name=EIdUsuario]')[0].value;

    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function(response) {

            if (response === "Delete") {

                window.location.href = "Usuarios";
            } else {
                alert("no se puede eliminar el usuario");
            }
        }
    });
}


function crearUsuario(action) {

    //obtengo los datos de los inputs

    email = $('input[name=EmailNuevo]')[0].value;
    passwordHash = $('input[name=PasswordHashNuevo]')[0].value;
    role = document.getElementById('SelectNuevo');
    selectRole = role.options[role.selectedIndex].text;

    if (email == "") {
        $('#EmailNuevo').focus();
        alert("Ingrese un email");
    }
    else
    {
        if (passwordHash == "") {
            $('#PasswordHashNuevo').focus();
            alert("ingrese un password");
        } else {


            $.ajax({
                type: "POST",
                url: action,
                data: {email,passwordHash,selectRole},
                success: function (response) {
                    if (response === "Save") {

                        window.location.href = "Home";
                    } else {
                        $('#mensajeNuevo')
                            .html(
                                "No se puede guardar el usuario. <br/>Selecciones un rol. <br/>Ingrese un email correcto.<br/>El password debe tener más de 6 caracteres, un número, una mayúscula y un caracter especial.");
                    }

                }


            });

        }
    }




}

