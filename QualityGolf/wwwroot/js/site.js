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
var concurrencyStamp;
var lockoutEnabled;
var lockoutEnd;
var normalizedUserName;
var normalizedEmail;
var passwordHash;
var PhoneNumberConfirmed;
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
        concurrencyStamp= val.concurrencyStampc;
        lockoutEnabled= val.lockoutEnabled;
        lockoutEnd= val.lockoutEnd;
        normalizedUserName= val.normalizedUserName ;
        normalizedEmail =  val.normalizedEmail;
        passwordHash = val.passwordHash;
        PhoneNumberConfirmed = val.PhoneNumberConfirmed;
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
            id, userName, email, phoneNumber, accessFailedCount, concurrentStamp, emailConfirmed, lockoutEneable,
            lockoutEnd, NormalizedEmail, NormalizedUserName, passwordHash, phoneNumberConfirmed, securityStamp,
            twoFactorEneable, selectRole
        },
        success: function (response) { 

            alert("hola");


            if (response === "Save") {
                
                window.location.href = "Usuarios";
            } else {
                alert("no se puede editar los datos del usuario");
            }

        }
     });


}