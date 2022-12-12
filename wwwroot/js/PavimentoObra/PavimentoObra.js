var idParam;
var jsonListaPadrao;
var urlEnvio = "Inserir";//por padrão a variavel chama a action inserir

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

            for (var a = 0; a < jsonListaPadrao.pavimentoUcs.length; a++) {

                jQuery("#listagemItem tbody").append("\
                    <tr>\
                        <td><font>" + jsonListaPadrao.pavimentoUcs[a]['CodPavimentoUc'] + "</font></td>\
                        <td><font>" + jsonListaPadrao.pavimentoUcs[a]['NumeroRepeticoesPavimento'] + "</font></td>\
                        <td class='center'>\
                            <input type='hidden' class='cod_item' value='" + JSON.stringify(jsonListaPadrao.pavimentoUcs[a]) + "'>\
                            <a href='javascript:void(0)' class='item'><i class='fa fa-pencil'></i><a/>\
                        </td>\
                        <td class='center'>\
                            <input type='hidden' class='jsonParaDeletar' value='" + JSON.stringify(jsonListaPadrao.pavimentoUcs[a]) + "'>\
                            <a href='javascript:void(0)' class='valores_deletar'><i class='fa fa-close c_red'></i><a/>\
                        </td>\
                    </tr>\
        ");
            }
            //#endregion


            //#region monta o select de pavimento

            var options2 = $("#pavimentoUc\\.TbPavimentosCodPavimentos");//essas \\ é para não da problema porque o id tem . no nome


            for (var it = 0; it < jsonListaPadrao.pavimentos.length; it++) {

                options2.append($("<option />").val(jsonListaPadrao.pavimentos[it].CodPavimentos).text(jsonListaPadrao.pavimentos[it].NomePavimentos));

            }

            //#endregion


        } catch (e) {
            jQuery('#listagemItem tbody td').remove(); //remove do htm pra inserir_imagem de novo logo abaixo

        }

    });

    //jQuery("#detalhesPedido").show(); //mostra a lista

}
//#endregion

//#region editar
jQuery("body").on("click", ".item", function () {

    jQuery("#editarItem").show(); //mostra o botão de editar
    jQuery("#salvarItem").hide(); //esconde o botão de salvar
    jQuery("#cancelaEditar").show(); //mostra o botão de cancelar editar

    var itemFiltrado = jQuery.parseJSON(jQuery(this).parent().find('.cod_item').val());//da o parse para transformar em vetor

    $('#pavimentoUc\\.TbPavimentosCodPavimentos').val(itemFiltrado.TbPavimentosCodPavimentos).change();
   
    montaCamposEditar(itemFiltrado, "#dadosItem .group-item");//esta função está em /view/util/funcoes.js, e serve para preencher automaticamente os campos do formulario com os valores que estão no json

    jQuery("#pavimentoUc_CodPavimentoUc").val(itemFiltrado.CodPavimentoUc);//coloca no hidden o codigo a ser editado

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

            jQuery("#pavimentoUc_CodPavimentoUc").val(itemFiltradoParaDelete.CodPavimentoUc);//coloca no hidden o codigo a ser editado

            $('#formBasico').submit();

            return false;
        });
});

//#endregion

//#region envia via ajax a requisição

$("#formBasico").on('submit', (function (e) {

    try {

        e.preventDefault();

        jQuery("#pavimentoUc_TbUcObraCodUcObra").val(getUrlVars()["cod_uc"]);//coloca no hidden o codigo da unidade construtiva que vem da tela de unidade construtiva obra

        var objAjax = new Object();

        objAjax.urlx = urlEnvio;
        objAjax.data = $('#formBasico').serialize();
        objAjax.async = true;

        ajaxBase(objAjax, function (retornoAlertBase) {//chama a função base pra enviar ajax e jogar o alert na tela

            urlEnvio = "Inserir";//coloca o valor inserir na variavel pra deixar com o valor default e mandar pra action de inserir

            if (retornoAlertBase) {
                populaListagem();
            }

        }); //esta função ajaxBase está na pasta view/util/funcoes

        urlEnvio = "Inserir";//coloca o valor inserir na variavel pra deixar ocm o valor default 


    } catch (e) {

        urlEnvio = "Inserir";//coloca o valor inserir na variavel pra deixar ocm o valor default 

    }

}));
//#endregion
