$(document).ready(function () {
    GetAll();
    EstadoGetAll()
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5125/api/Empleado/GetAll',
        success: function (result) {
            $('#tblEmpleado tbody').empty();
            $.each(result.objects, function (i, empleado) {
                var filas =
                    '<tr>'

                    + '<td class="text-center"> '
                    + '<a class="btn btn-warning glyphicon glyphicon-edit" href="#" onclick="GetById(' + empleado.idEmpleado + ')">'
                    + '</a> '
                    + '</td>'
                    + "<td class='text-center'>" + empleado.idEmpleado + "</td>"
                    + "<td class='text-center'>" + empleado.numeroNomina + "</td>"
                    + "<td class='text-center'>" + empleado.nombre + "</td>"
                    + "<td class='text-center'>" + empleado.apellidoPaterno + "</ td>"
                    + "<td class='text-center'>" + empleado.apellidoMaterno + "</ td>"
                    + "<td class='text-center'>" + empleado.estado.idEstado + "</td>"
                    + "<td class='text-center'>" + empleado.estado.nombre + "</td>"
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.idEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'
                    + "</tr>";

                $("#tblEmpleado tbody").append(filas);
            });
        },

        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function EstadoGetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5125/api/Empleado/EstadoGetAll',
        success: function (result) {
            $("#ddlEstados").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.objects, function (i, estado) {
                $("#ddlEstados").append('<option value="'
                    + estado.idEstado + '">'
                    + estado.nombre + '</option>');
            });
        }
    });
}

function ShowModal() {

    $('#ModalUpdate').modal('show');
    EstadoGetAll();

    InitializeControls();
    $('#lblTitulo').modal('Agregar Empleado');

}

function Add(empleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5125/api/Empleado/Add',
        dataType: 'json',
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');

            GetAll();

        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}

function InitializeControls() {

    $('#txtIdEmpleado').val('');
    $('#txtNumeroNomina').val('');
    $('#txtNombre').val('');
    $('#txtApellidoPaterno').val('');
    $('#txtApellidoMaterno').val('');
    $('#ddlEstados').val(0);
    $('#ModalForm').modal('show');

}

function Guardar() {

    var empleado = {
        idEmpleado: $('#txtIdEmpleado').val(), ,
        numeroNomina: '',
        nombre: $('#txtNombre').val(),
        apellidoPaterno: $('#txtApellidoPaterno').val(),
        apellidoMaterno: $('#txtApellidoMaterno').val(),
        estado: {
            idEstado: $('#ddlEstados').val(),
            nombre: '',
            estados: []
        },
        empleados: []
    }
    if ($('#txtApellidoPaterno').val() == "") {
        empleado.idEmpleado = 0,
        Add(empleado);
    }
    else {
        Update(empleado);
    }

}
function Eliminar(idEmpleado) {

    if (confirm("¿Estas seguro de eliminar el empleado seleccionado?")) {
        $.ajax({
            type: 'DELETE',
            url: 'http://localhost:5125/api/Empleado/Delete' + idEmpleado,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};

function GetById(idEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5125/api/Empleado/GetById' + idEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.object.idEmpleado);
            $('#txtNumeroNomina').val(result.object.numeroNomina);
            $('#txtNombre').val(result.object.nombre);
            $('#txtApellidoPaterno').val(result.object.apellidoPaterno);
            $('#txtApellidoMaterno').val(result.object.apellidoMaterno);
            $('#ddlEstados').val(result.object.estado.idEstado);

            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }


    });

}

function Update(empleado) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:5125/api/Empleado/Update',
        datatype: 'json',
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};