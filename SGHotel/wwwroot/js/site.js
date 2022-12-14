$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

$(document).ready(function () {
    getDatatable('#Tabela-Contatos');
    getDatatable('#Tabela-Usuarios');
    getDatatable('#Tabela-Clientes');

    $('.botao-modal').click(function () {
        $('#modal-reserva').modal();
    });

    //$('#btn-checkin').click(function () {
    //    $('.modal fade').modal();
    //});

});

//$(document).ready(function () {
//    $('#Tabela-Contatos').DataTable();
//});

function getDatatable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}



$("#btnSalvarEdicao").on("click", "[type='checkbox']", function (e) {
    if (this.checked) {
        $(e).attr("value", "true");
    } else {
        $(e).attr("value", "false");
    }
});


$('#exampleModal').on('shown.bs.modal', function () {
    $('#meuInput').trigger('focus')
})

$('#modal-reservas-lista').on('shown.bs.modal', function () {
    $('#meuInput').trigger('focus')
})

