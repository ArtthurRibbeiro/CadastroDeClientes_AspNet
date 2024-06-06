// Write your JavaScript code.

$(document).ready(function () {

    // Função para fechar o alerta
    $('.close-alert').click(function () {
        $('.alert').hide('hide');
    });

    // Função para buscar o CEP
    function buscaCep(cep) {
        if (cep.length === 8) {
            fetch(`https://viacep.com.br/ws/${cep}/json/`)
                .then(response => response.json())
                .then(data => {
                    if (!data.erro) {
                        console.log(data.cep);

                        $('#rua').val(data.logradouro);
                        $('#bairro').val(data.bairro);
                        $('#cidade').val(data.localidade);
                        $('#uf').val(data.uf);
                    } else {
                        alert('CEP não encontrado.');
                    }
                })
                .catch(error => console.error('Erro ao buscar CEP:', error));
        }
    }

    // Evento para buscar CEP quando o campo perde o foco
    $('#cep').on('blur', function () {
        buscaCep($(this).val().replace(/\D/g, ''));
    });

    // Evento para buscar dados do CNPJ quando o campo perde o foco
    $('#documento').on('blur', function () {
        var documento = $(this).val().replace(/\D/g, '');

        if ($('#tipo').val() === "PJ" && documento.length === 14) {
            fetch(`https://localhost:44391/api/proxy/cnpj/${documento}`)
                .then(response => response.json())
                .then(data => {
                    if (!data.erro) {
                        console.log(data.fantasia);

                        $('#nomeRazaoSocial').val(data.nome);
                        $('#nomeFantasia').val(data.fantasia);
                        $('#email').val(data.email);
                        $('#telefone').val(data.telefone);
                        $('#cep').val(data.cep);
                        buscaCep(data.cep.replace(/\D/g, ''));
                        $('#numero').val(data.numero);
                        $('#complemento').val(data.complemento);
                    } else {
                        alert('CNPJ não encontrado.');
                    }
                })
                .catch(error => console.error('Erro ao buscar CNPJ:', error));
        }
    });

    // Evento para focar no campo 'documento' quando o tipo muda
    $('#tipo').on('change', function () {
        $('#documento').focus();
    });

});
