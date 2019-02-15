$(document).ready(function () {
    $('#select_cidade').on('change', function () {
        limpar_select("#select_bairro");
        limpar_select("#select_rua");
        
        let url = "/bairro/get?partitionkey=" + this.value;
        //console.log(url);

        $.get(url, function (data) {
            data.forEach(function (element, index, array) {
                
                //$("#select_bairro").append(new Option(element.Nome, element.RowKey));
                console.log(JSON.stringify(element));
                $("#select_bairro").append(`<option value ="${element.RowKey}" json="${ JSON.stringify(element)}"> ${ element.Nome }</option>`);
            });
        });
        let divResultado = $("#resultado_pesquisa");
        divResultado.find(".cidade").html("Nome da cidade, quantidade de habitantes <br>Descricao <br>uma cidade legal");
        //
    });

    $('#select_bairro').on('change', function () {
        limpar_select("#select_rua");

        let url = "/rua/get?partitionkey=" + this.value;
        //console.log(url);
        console.log(JSON.parse(this.json));

        $.get(url, function (data) {
            //console.log(data)
            data.forEach(function (element, index, array) {
                $("#select_rua").append(new Option(element.Nome, element.RowKey));
            });
        });

    });

});

function limpar_select(id) {
    $(id).children('option:not(:first)').remove();
}
