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
var jp = 0;
var jsus = 0; 

var id;
var userName;
var email;

var role;
var selectRole;

var nacionalidad;

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
var sexo;
var direccion;
var localidad;
var codigoPostal;
var tipoPlan;
var tipoSuscripcion;
var cantidadClasesMes;
var clasesPendiente;




function mostrarUsuario(response) {
    items = response;
    j = 0;
    jp = 0;
    jsus = 0;
    for (var i = 0; i < 3; i++) {
        var x = document.getElementById('Select');
        x.remove(i);
    }

    $.each(items,function(index, val) {
        $('input[name=Id]').val(val.id);
        $('input[name=UserName]').val(val.userName);
        $('input[name=Email]').val(val.email);
        $('input[name=Nombre]').val(val.nombre);
        $('input[name=Apellido]').val(val.apellido);
        $('input[name=Nacionalidad]').val(val.nacionalidad);
        $('input[name=Dni]').val(val.dni);
        $('input[name=Sexo]').val(val.sexo);
        $('input[name=PhoneNumber]').val(val.phoneNumber);
        $('input[name=Direccion]').val(val.direccion);
        $('input[name=Localidad]').val(val.localidad);
        $('input[name=CodigoPostal]').val(val.codigoPostal);
        $('input[name=TipoPlan]').val(val.tipoPlan);
        $('input[name=TipoSuscripcion]').val(val.tipoSuscripcion);
        $('input[name=CantidadClasesMes]').val(val.cantidadClasesMes);
        $('input[name=ClasesPendiente]').val(val.clasesPendiente);
        document.getElementById('Select').options[0] = new Option(val.role, val.roleId);

        //mostrar detalles de usuario

        $("#dEmail").text(val.email);
        $("#dUserName").text(val.userName);
        $("#dRole").text(val.role);
        $("#dNombre").text(val.nombre);
        $("#dApellido").text(val.apellido);
        $("#dNacionalidad").text(val.nacionalidad);
        $("#dDni").text(val.dni);
        $("#dSexo").text(val.sexo);
        $("#dPhoneNumber").text(val.phoneNumber);
        $("#dDireccion").text(val.direccion);
        $("#dLocalidad").text(val.localidad);
        $("#dCodigoPostal").text(val.codigoPostal);
        $("#dTipoPlan").text(val.tipoPlan);
        $("#dTipoSuscripcion").text(val.tipoSuscripcion);
        $("#dCantidadClasesMes").text(val.cantidadClasesMes);
        $("#dClasesPendiente").text(val.clasesPendiente);
        
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
        success: function (response) {
            console.log(response);
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

function getPlanes(action)
{
    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            console.log(response);
            if (jp === 0) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('TipoPlanNuevo').options[i] = new Option(response[i].text, response[i].value);
                }
                jp = 1;
            }


        }

    });
}

function getSuscripcion(action) {

    tipoPlan2 = document.getElementById('TipoPlanNuevo').options[document.getElementById('TipoPlanNuevo').selectedIndex].text;

    console.log(tipoPlan2);

    $.ajax({
        type: "POST",
        url: action,
        data: {tipoPlan2},
        success: function (response) {
            console.log(response);
            if (jsus === 0) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('TipoSuscripcionNuevo').options[i] = new Option(response[i].text, response[i].value);
                }
                jsus = 1;
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

    nombre = $('input[name=Nombre]')[0].value;
    apellido = $('input[name=Apellido]')[0].value;
    nacionalidad = $('input[name=Nacionalidad]')[0].value;
    dni = $('input[name=Dni]')[0].value;
    sexo = document.getElementById('Sexo').options[document.getElementById('Sexo').selectedIndex].text;
    phoneNumber = $('input[name=PhoneNumber]')[0].value;
    direccion = $('input[name=Direccion]')[0].value;
    localidad = $('input[name=Localidad]')[0].value;
    codigoPostal = $('input[name=CodigoPostal]')[0].value;
    //tipoPlan = document.getElementById('TipoPLanNuevo');
    tipoPlan = document.getElementById('TipoPlan').options[document.getElementById('TipoPlan').selectedIndex].text;
    //tipoSuscripcion = document.getElementById('TipoSuscripcionNuevo');
    tipoSuscripcion = document.getElementById('TipoSuscripcion').options[document.getElementById('TipoSuscripcion').selectedIndex].text;

    

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
            twoFactorEneable, selectRole, tipoSuscripcion, tipoPlan, codigoPostal, localidad, direccion, sexo, dni,
            nacionalidad, apellido, nombre
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
    
    
    nombre = $('input[name=NombreNuevo]')[0].value;
    apellido = $('input[name=ApellidoNuevo]')[0].value;
    nacionalidad = $('input[name=NacionalidadNuevo]')[0].value;
    dni = $('input[name=DniNuevo]')[0].value;
    sexo = document.getElementById('SexoNuevo').options[document.getElementById('SexoNuevo').selectedIndex].text;
    phoneNumber = $('input[name=PhoneNumberNuevo]')[0].value;
    direccion = $('input[name=DireccionNuevo]')[0].value;
    localidad = $('input[name=LocalidadNuevo]')[0].value;
    codigoPostal = $('input[name=CodigoPostalNuevo]')[0].value;
    //tipoPlan = document.getElementById('TipoPLanNuevo');
    tipoPlan = document.getElementById('TipoPlanNuevo').options[document.getElementById('TipoPlanNuevo').selectedIndex].text;
    //tipoSuscripcion = document.getElementById('TipoSuscripcionNuevo');
    tipoSuscripcion = document.getElementById('TipoSuscripcionNuevo').options[document.getElementById('TipoSuscripcionNuevo').selectedIndex].text;
    cantidadClasesMes = 8;
    clasesPendiente = 7;

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

            console.log(email, passwordHash, selectRole, nombre, apellido, nacionalidad, dni, sexo, phoneNumber,
                direccion, localidad, codigoPostal, tipoPlan, tipoSuscripcion, cantidadClasesMes, clasesPendiente);

            $.ajax({
                type: "POST",
                url: action,
                data: {email,passwordHash,selectRole,nombre,apellido,nacionalidad, dni,sexo,phoneNumber,direccion,localidad,codigoPostal,tipoPlan,tipoSuscripcion,cantidadClasesMes,clasesPendiente },
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

