console.log("Custom script is loaded");

const hamBurger = document.querySelector(".toggle-btn");

hamBurger.addEventListener("click", function () {
document.querySelector("#sidebar").classList.toggle("expand");
});

getDatatable('#table-usuarios');

function getDatatable(id){
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

$('.close-alert').click(function(){
    $('.alert').hide('hide');
});


$(document).ready(function () {
    $('#deleteConfirmationModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Botão que acionou o modal
        var userId = button.data('id'); // Recupera o ID do usuário
        var deleteUrl = button.data('url') + '/' + userId; // Construa a URL completa
        $('#confirmDeleteButton').data('url', deleteUrl); // Armazena a URL no botão de confirmação
    });

    $('#confirmDeleteButton').on('click', function () {
        var deleteUrl = $(this).data('url'); // Recupera a URL do botão de confirmação

        // Envia a solicitação POST usando AJAX
        $.post(deleteUrl, function (response) {
            if (response.success) {
                location.reload(); // Recarrega a página após a exclusão
            } else {
                alert('Erro ao tentar apagar o registro: ' + response.error);
            }
        }).fail(function () {
            alert('Erro ao tentar apagar o registro.');
        });
    });
});
