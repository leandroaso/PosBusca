$(document).ready(function () {
    $('#select_cidade').on('change', function () {
        let divResultado = $("#resultado_pesquisa");

        limpar_select("#select_bairro");
        limpar_select("#select_rua");

        divResultado.find(".cidade").html("");
        divResultado.find(".bairro").html("");
        divResultado.find(".rua").html("");

        if (!this.value)
            return;

        let url = "/bairro/get?partitionkey=" + this.value;

        $.get(url, function (data) {
            data.forEach(function (element, index, array) {
                $("#select_bairro").append(`<option value ="${element.RowKey}" Nome="${element.Nome}" Regional="${element.Regional}" IDH2000="${element.IDH2000}" Populacao2010="${element.Populacao2010}" > ${element.Nome}</option>`);
            });
        });

        let nome = $(this).children("option:selected").attr("Nome");
        let populacao = $(this).children("option:selected").attr("Populacao");
        let descricao = $(this).children("option:selected").attr("Descricao");

        divResultado.find(".cidade").html(`Nome: ${nome} <br>População: ${populacao} <br>Descrição: ${descricao}`);
    });

    $('#select_bairro').on('change', function () {
        let divResultado = $("#resultado_pesquisa");

        limpar_select("#select_rua");
        divResultado.find(".bairro").html("");
        divResultado.find(".rua").html("");

        if (!this.value)
            return;

        let url = "/rua/get?partitionkey=" + this.value;
        $.get(url, function (data) {
            //console.log(data)
            data.forEach(function (element, index, array) {
                $("#select_rua").append(`<option value ="${element.RowKey}" Nome="${element.Nome}" CEP="${element.CEP}">${element.Nome}</option>`);
            });
        });

        let nome = $(this).children("option:selected").attr("Nome");
        let regional = $(this).children("option:selected").attr("Regional");
        let IDH2000 = $(this).children("option:selected").attr("IDH2000");
        let populacao2010 = $(this).children("option:selected").attr("Populacao2010");

        divResultado.find(".bairro").html(`Nome: ${nome} <br>Regional: ${regional} <br>IDH no ano 2000: ${IDH2000} <br>População em 2010: ${populacao2010}`);
    });

    $('#select_rua').on('change', function () {

        let divResultado = $("#resultado_pesquisa");
        divResultado.find(".rua").html("");
        if (!this.value)
            return;

        let nome = $(this).children("option:selected").attr("Nome");
        let CEP = $(this).children("option:selected").attr("CEP");

        divResultado.find(".rua").html(`Nome: ${nome} <br>CEP: ${CEP}`);
    });
});

function limpar_select(id) {
    $(id).children('option:not(:first)').remove();
}
