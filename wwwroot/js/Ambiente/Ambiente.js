//#region variavels e objetos globais
var idParam;
var jsonListaPadrao;
var urlEnvio = "Inserir";//por padrão a variavel chama a action inserir
var objAjax = new Object();
var objArgFormula = new Object();
var uc;
var pav;

//#endregion


populaListagem();//carrega a lista com os eventos

//#region função para popular a listagem dos itens  
function populaListagem() {

    var parametrosListarprincipal = {};
    parametrosListarprincipal.pdata = { dataForm: "" }; // mandar o limite de regidstros que vai trazer e o ofsset

    ajaxSubmitRetornoPost("Listar", parametrosListarprincipal, function (returnValue) {

        try {

            jsonListaPadrao = $.parseJSON(returnValue);

            //#region monta a lista na tabela

            jQuery('#listagemItem tbody td').remove(); //remove do htm pra inserir de novo logo abaixo

            for (var a = 0; a < jsonListaPadrao.ambientes.length; a++) {

                jQuery("#listagemItem tbody").append("\
                    <tr>\
                        <td><font>" + jsonListaPadrao.ambientes[a]['CodAmbiente'] + "</font></td>\
                        <td><font>" + jsonListaPadrao.ambientes[a]['NomeambienteBcQuant'] + "</font></td>\
                        <td class='center'>\
                            <input type='hidden' class='cod_item' value='" + JSON.stringify(jsonListaPadrao.ambientes[a]) + "'>\
                            <a href='javascript:void(0)' class='item'><i class='fa fa-pencil'></i><a/>\
                        </td>\
                        <td class='center'>\
                            <input type='hidden' class='jsonParaDeletar' value='" + JSON.stringify(jsonListaPadrao.ambientes[a]) + "'>\
                            <a href='javascript:void(0)' class='valores_deletar'><i class='fa fa-close c_red'></i><a/>\
                        </td>\
                    </tr>\
        ");
            }
            //#endregion

            //#region monta o select de materia prima

            var options2 = $("#ambiente\\.TbAmbienteBasicoCodAmbienteBasico");//essas \\ é para não da problema porque o id tem . no nome


            for (var it = 0; it < jsonListaPadrao.ambienteBasicos.length; it++) {

                options2.append($("<option />").val(jsonListaPadrao.ambienteBasicos[it].CodAmbienteBasico).text(jsonListaPadrao.ambienteBasicos[it].NomeAmbienteBasico));

            }

            //#endregion

            //#region monta o select de uc

            var options3 = $("#ambiente\\.TbUcObraCodUcObra");//essas \\ é para não da problema porque o id tem . no nome

            for (var it = 0; it < jsonListaPadrao.unidadeConstrutivas.length; it++) {

                options3.append($("<option data-ucu=" + jsonListaPadrao.unidadeConstrutivas[it].TbUcObra[0].NumeroRepeticoesUc + " />").val(jsonListaPadrao.unidadeConstrutivas[it].TbUcObra[0].CodUcObra).text(jsonListaPadrao.unidadeConstrutivas[it].NomeUnidadeConstrutiva));

            }

            //#endregion

            //#region monta o select de pavimento

            var options4 = $("#ambiente\\.TbPavimentoUcCodPavimentoUc");//essas \\ é para não da problema porque o id tem . no nome

            for (var it = 0; it < jsonListaPadrao.pavimentos.length; it++) {

                options4.append($("<option data-pav=" + jsonListaPadrao.pavimentos[it].TbPavimentoUc[0].NumeroRepeticoesPavimento + " />").val(jsonListaPadrao.pavimentos[it].TbPavimentoUc[0].CodPavimentoUc).text(jsonListaPadrao.pavimentos[it].NomePavimentos));

            }

            //#endregion



        } catch (e) {
            jQuery('#listagemItem tbody td').remove(); //remove do htm pra inserir_imagem de novo logo abaixo

        }

    });

}
//#endregion

//#region  escolhe se é peiso,teto ou parede esconde os campos 

$("#Piso").change(function () {
    if ($("#Piso").is(":checked") == true) {
        $("#div_piso").show();

    } else {
        $("#div_piso").hide();

    }

});

$("#Teto").change(function () {
    if ($("#Teto").is(":checked") == true) {
        $("#div_teto").show();

    } else {
        $("#div_teto").hide();

    }

});

$("#Parede").change(function () {
    if ($("#Parede").is(":checked") == true) {
        $("#div_parede").show();

    } else {
        $("#div_parede").hide();

    }

});
//#endregion

//#region editar
jQuery("body").on("click", ".item", function () {

    jQuery("#editarItem").show(); //mostra o botão de editar
    jQuery("#salvarItem").hide(); //esconde o botão de salvar
    jQuery("#cancelaEditar").show(); //mostra o botão de cancelar editar

    var itemFiltrado = jQuery.parseJSON(jQuery(this).parent().find('.cod_item').val());//da o parse para transformar em vetor

    $('#ambiente\\.TbItensLevantamentoCodItensLevantamento').val(itemFiltrado.TbItensLevantamentoCodItensLevantamento).change();
    $('#ambiente\\.TbAmbienteBasicoCodAmbienteBasico').val(itemFiltrado.TbAmbienteBasicoCodAmbienteBasico).change();
    $('#ambiente\\.TbUcObraCodUcObra').val(itemFiltrado.TbUcObraCodUcObra).change();
    $('#ambiente\\.TbPavimentoUcCodPavimentoUc').val(itemFiltrado.TbPavimentoUcCodPavimentoUc).change();
    $('#ambiente\\.TbItensLevantamentoCodItensLevantamento').val(itemFiltrado.TbItensLevantamentoCodItensLevantamento).change();
    $('#ambiente\\.TbUnidadeMedidaCodUnidadeMedida').val(itemFiltrado.TbUnidadeMedidaCodUnidadeMedida).change();
    $('#ambiente\\.TbPosicaoCodPosicao').val(itemFiltrado.TbPosicaoCodPosicao).change();

    montaCamposEditar(itemFiltrado, "#dadosItem .group-item");//esta função está em /view/util/funcoes.js, e serve para preencher automaticamente os campos do formulario com os valores que estão no json

    jQuery("#ambiente_CodAmbiente").val(itemFiltrado.CodAmbiente);//coloca no hidden o codigo a ser editado

    urlEnvio = "Editar";//essa variavel ta no começo do código em variaveis globais
});
//#endregion

//#region cancelar o editar
jQuery("#cancelaEditar").on("click", function () {
    location.reload();
});
//#endregion

//#region deletar

jQuery("body").on("click", ".valores_deletar", function () {

    var itemFiltradoParaDelete = jQuery.parseJSON(jQuery(this).parent().find('.jsonParaDeletar').val());//da o parse para transformar em vetor

    swal({
        title: "Deletar Status",
        text: "Tem certeza que você deseja deletar este item? Esta ação não poderá ser desfeita!",
        type: "info",
        showCancelButton: true,
        closeOnConfirm: false,
        showLoaderOnConfirm: true,
    },
        function () {

            urlEnvio = "Deletar";//essa variavel ta no começo do código em variaveis globais

            jQuery("#ambiente_CodAmbiente").val(itemFiltradoParaDelete.CodAmbiente);//coloca no hidden o codigo a ser editado

            $('#formBasico').submit();

            return false;
        });
});

//#endregion

//#region pega numero de repeticoes de pavimento pra calcular

$('#ambiente\\.TbUcObraCodUcObra').change(function () {

    objArgFormula.QtUCEmpreend = $('#ambiente_NumeroRepeticaoPavimento').val();
    objArgFormula.QtAmbPav = pav;
    objArgFormula.QtPavUC = $(this).find(':selected').data('ucu');

    uc = objArgFormula.QtPavUC;//coloca o valor de repetições da unidade cons na veriavel global para usar no pavimento para calcular

    var resultado = objFormula.repeticoesAmbiente(objArgFormula);

    $('#ambiente_NumeroRepeticaoObra').val(isNaN(resultado) ? "" : resultado);

})

//#endregion

//#region pega numero de repeticoes de pavimento pra calcular

$('#ambiente\\.TbPavimentoUcCodPavimentoUc').change(function () {

    objArgFormula.QtUCEmpreend = $('#ambiente_NumeroRepeticaoPavimento').val();
    objArgFormula.QtPavUC = uc;
    objArgFormula.QtAmbPav = $(this).find(':selected').data('pav');

    pav = objArgFormula.QtPavUC;

    var resultado = objFormula.repeticoesAmbiente(objArgFormula);

    $('#ambiente_NumeroRepeticaoObra').val(isNaN(resultado) ? "" : resultado);
})

//#endregion

//#region pega numero de repeticoes de pavimento pra calcular

$("#ambiente_NumeroRepeticaoPavimento").focusout(function () {

    objArgFormula.QtUCEmpreend = $('#ambiente_NumeroRepeticaoPavimento').val();
    objArgFormula.QtPavUC = uc;
    objArgFormula.QtAmbPav = pav;

    var resultado = objFormula.repeticoesAmbiente(objArgFormula);

    $('#ambiente_NumeroRepeticaoObra').val(isNaN(resultado) ? "" : resultado);


});


//#endregion

////#region calcula os valores de piso

//$(".piso_calculo").focusout(function () {

//    /*PerPisoAmb = ( larg + L ) x 2 - LDescPiso*/

//    objArgFormula.larg = $('#posicaoAmbiente_Largura').val();
//    objArgFormula.L = $('#posicaoAmbiente_Comprimento').val();
//    objArgFormula.LDescPiso = $('#posicaoAmbiente_ComprimentoADescontar').val();
//    objArgFormula.PerPisoAmb = $('#posicaoAmbiente_PerimetroDoAmbiente').val();
//    objArgFormula.QtAmbGeral = $('#ambiente_NumeroRepeticaoObra').val();
//    objArgFormula.ArDescPiso = $('#posicaoAmbiente_AreaADescontar').val();
//    objArgFormula.ArPisoAmb = $('#posicaoAmbiente_AreaDoAmbiente').val();

//    var resultado = objFormula.perimetroAmbiente(objArgFormula);
//    var resultadoObra = objFormula.perimetroObra(objArgFormula);

//    var resultAreaAmbiente = objFormula.areaAmbiente(objArgFormula);
//    var resultAreaObra = objFormula.areaObra(objArgFormula);

    
//    $('#posicaoAmbiente_PerimetroDoAmbiente').val(isNaN(resultado) ? "" : resultado);
//    $('#posicaoAmbiente_PerimetroDaObra').val(isNaN(resultadoObra) ? "" : resultadoObra);
//    $('#posicaoAmbiente_AreaDoAmbiente').val(isNaN(resultAreaAmbiente) ? "" : resultAreaAmbiente);
//    $('#posicaoAmbiente_AreaDaObra').val(isNaN(resultAreaObra) ? "" : resultAreaObra);
//});

////#endregion

////#region calcula os valores de teto

//$(".teto_calculo").focusout(function () {

//    /*PerPisoAmb = ( larg + L ) x 2 - LDescPiso*/

//    objArgFormula.larg = $('#posicaoAmbiente_Largura').val();
//    objArgFormula.L = $('#posicaoAmbiente_Comprimento').val();
//    objArgFormula.LDescPiso = $('#posicaoAmbiente_ComprimentoADescontar').val();
//    objArgFormula.PerPisoAmb = $('#posicaoAmbiente_PerimetroDoAmbiente').val();
//    objArgFormula.QtAmbGeral = $('#ambiente_NumeroRepeticaoObra').val();
//    objArgFormula.ArDescPiso = $('#posicaoAmbiente_AreaADescontar').val();
//    objArgFormula.ArPisoAmb = $('#posicaoAmbiente_AreaDoAmbiente').val();

//    var resultado = objFormula.perimetroAmbiente(objArgFormula);
//    var resultadoObra = objFormula.perimetroObra(objArgFormula);

//    var resultAreaAmbiente = objFormula.areaAmbiente(objArgFormula);
//    var resultAreaObra = objFormula.areaObra(objArgFormula);

//    $('#posicaoAmbiente_PerimetroDoAmbiente').val(isNaN(resultado) ? "" : resultado);
//    $('#posicaoAmbiente_PerimetroDaObra').val(isNaN(resultadoObra) ? "" : resultadoObra);
//    $('#posicaoAmbiente_AreaDoAmbiente').val(isNaN(resultAreaAmbiente) ? "" : resultAreaAmbiente);
//    $('#posicaoAmbiente_AreaDaObra').val(isNaN(resultAreaObra) ? "" : resultAreaObra);
//});

////#endregion


//#region envia via ajax a requisição

$("#formBasico").on('submit', (function (e) {

    try {

        e.preventDefault();

        objAjax.urlx = urlEnvio;
        objAjax.data = $('#formBasico').serialize();
        objAjax.async = true;
      

        var inputs = $("#div_piso :input");
        var posicaoAmbientes = $.map(inputs, function (n, i) {
            var temp = {};
            var o = {};
            o[n.name.substring(n.name.indexOf(".") + 1)] = $(n).val();
            temp.push(o);
            //o["TbAmbienteCodAmbiente"] = retornoAlertBase['retorno'];
            return o;
        });

        console.log(JSON.stringify(posicaoAmbientes));

        //ajaxBase(objAjax, function (retornoAlertBase) {//chama a função base pra enviar ajax e jogar o alert na tela

        //    urlEnvio = "Inserir";//coloca o valor inserir na variavel pra deixar com o valor default e mandar pra action de inserir

        //    if (retornoAlertBase) {

        //        var objAjax2 = new Object();

               

        //        //var posicaoAmbientes = JSON.parse($('#div_piso :input').serializeArray());
                 
                
        //        //var posicaoAmbientes = [
        //        //         { TbAmbienteCodAmbiente: retornoAlertBase['retorno'],Largura: 1, Comprimento: 3 },
        //        //         { TbAmbienteCodAmbiente: retornoAlertBase['retorno'],Largura: 1, Comprimento: 5 },
        //        //         { TbAmbienteCodAmbiente: retornoAlertBase['retorno'],Largura: 1, Comprimento: 2 },
        //        //];

        //        objAjax2.urlx = "InserirPosicoesAmbiente";
        //        objAjax2.data = JSON.stringify(posicaoAmbientes);
        //        objAjax2.contentType = "application/json; charset=utf-8";
        //        objAjax2.datype = "json";
        //        objAjax2.async = true;
        //        objAjax2.mensagem = true;

        //        ajaxBase(objAjax2, function (retornoAlertBase) {//chama a função base pra enviar ajax e jogar o alert na tela

        //            if (retornoAlertBase) {

        //                populaListagem();

        //            }

        //        }); //esta função ajaxBase está na pasta view/util/funcoes



        //    }

        //}); //esta função ajaxBase está na pasta view/util/funcoes

        urlEnvio = "Inserir";//coloca o valor inserir na variavel pra deixar ocm o valor default 


    } catch (e) {

        urlEnvio = "Inserir";//coloca o valor inserir na variavel pra deixar ocm o valor default 

    }

}));
//#endregion
